using DAL;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using ValidationRuleEngine;
using static ValidationRuleEngine.Constants;

namespace Customizations
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AddressValidation : ValidationRuleEngine.Implementations.Validation
    {
        #region Local Variables
        
        //private string varLocation;
        //private string varState;
        //private string varPostCode;

        #endregion

        #region RepositoryObjectDeclaration
        private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        public void setupCustomFields(string location, string postcode, string state)
        {
            Attribute customVariable = new Attribute();
            customVariable.enabled = true;
            customVariable.name = Constants.AddressValidator_CustomFields.location;
            customVariable.path = "";
            customVariable.value = location;
            customVariable.is_rectifiable = false;
            this.LocalAttributes.Add(customVariable);

            customVariable = new Attribute();
            customVariable.enabled = true;
            customVariable.name = Constants.AddressValidator_CustomFields.postCode;
            customVariable.path = "";
            customVariable.value = postcode;
            customVariable.is_rectifiable = false;
            this.LocalAttributes.Add(customVariable);

            customVariable = new Attribute();
            customVariable.enabled = true;
            customVariable.name = Constants.AddressValidator_CustomFields.state;
            customVariable.path = "";
            customVariable.value = state;
            customVariable.is_rectifiable = false;
            this.LocalAttributes.Add(customVariable);
        }

        public void setupAddressValidator(string clientCode, string companyCode, 
            string warehouseCode, string orderNumber, string orderDate, string location,
            string postcode, string state, string documentType)
        {
            base.setupMandatoryFields(clientCode, companyCode, warehouseCode, orderNumber, orderDate, documentType);
            this.setupCustomFields(location, postcode, state);
        }

        public AddressValidation()
        {
        }
        
        public override bool Validate()
        {
            return ValidateAddressFields();
        }

        public bool ValidateAddressFields()
        {
            LocationCustomRepository locationCustomRepository = new LocationCustomRepository();
            List<Location_SYD> locations = null;
            while (true)
            {
                // If postCode is international(9999)
                // Then set state as 'ITL'
                // Return 1;
                if (this.LocalAttributes.Where(item=>item.name==Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value.Equals("9999"))
                {
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value = "ITL";
                    return true;
                }

                // If String.IsNullorEmpty(varLocation) == true
                // Then return -1;
                // Else If select row in Location_Syd 
                // Where (Location_Syd.postCode == varPostCode) 
                // && (Location_Syd.location == varLocation)
                // && (Location_Syd.state == varState)
                // Then return 0;
                if (String.IsNullOrEmpty(this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value))
                {
                    // Make entry in ErrorXML, ErrorInboundData & ErrorSuggestion
                    #region ErrorXml
                        ErrorXml objErrorXml = unitOfWork.CreateErrorXml(
                            clientCode,
                            warehouseCode,
                            orderNumber,
                            varDocumentType, 
                            orderDate,
                            DateTime.Now, String.IsNullOrEmpty(this.inProcessXML) 
                                            ? "empty xml" 
                                            : this.inProcessXML);
                        
                        unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                        unitOfWork.Save();
                    #endregion

                    #region ErrorInboundData
                    bool IsRectifiable = false;
                    IsRectifiable = this.LocalAttributes.Where(attr => attr.name.Equals(Constants.AddressValidator_CustomFields.location)).First().is_rectifiable;
                    ErrorInboundData errInboundData = unitOfWork.CreateErrorInboundData("Suburb",
                                    this.LocalAttributes
                                    .Where(item => item.name == Constants.AddressValidator_CustomFields.location)
                                    .First<Attribute>().path,
                                    "String",
                                    this.LocalAttributes
                                    .Where(item => item.name == Constants.AddressValidator_CustomFields.location)
                                    .First<Attribute>().value, this.validator_type,
                                    "Suburb invalid", "Suburb value is either null/empty or invalid",
                                    objErrorXml, IsRectifiable);

                        unitOfWork.ErrorInboundRepository.Insert(errInboundData);
                        unitOfWork.Save();
                    #endregion

                    #region ErrorSuggestion
                        Error_Suggestion_InboundData_Mapper esidmapObj = new Error_Suggestion_InboundData_Mapper();
                        esidmapObj.Id = Guid.NewGuid();
                        esidmapObj.ErrorSuggestionId = Constants.Suggestions.InvalidSuburb;
                        esidmapObj.ErrorInboundDataId = errInboundData.Id;
                        esidmapObj.DateTime = DateTime.Now;
                        unitOfWork.ErrorSuggestion_InboundDataRepository.Insert(esidmapObj);
                        unitOfWork.Save();
                    #endregion
                    return false;
                }
                else
                {
                    locations = locationCustomRepository.SelectByLocationPostCodeAndState(
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value,
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value,
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value,
                        LocationMatch.WithoutModification);

                    if (locations.Count == 1)
                    {
                        return true;
                    }
                }

                // ElseIf Select row in Location_Syd
                // Where (Location_Syd.location == varLocation after removing () part )
                // && (Location_Syd.state == varState)
                // && (Location_Syd.postCode == varPostCode)
                // Then return 1;
                // e.g if arg.Location == 'ASCOT' && location_Syd.location in 
                // {
                //      'ASCOT (BENDIGO)',
                //      'ASCOT (CRESWICK)',
                //      'ASCOT (CAMBOOYA)'
                // }
                //LocationCustomRepository locationCustomRepository = new LocationCustomRepository();
                locations = locationCustomRepository.SelectByLocationPostCodeAndState(
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First < Attribute >().value,
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value,
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value,
                    LocationMatch.StripParenthesis);
                if (locations.Count == 1)
                {
                    return true;
                }

                // If ((Location_Syd.location == varLocation) && (Location_Syd.postcode == varPostCode))
                // set varState = Location_Syd.state;
                locations = locationCustomRepository.SelectByLocationAndPostCode(
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value,
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value,
                    LocationMatch.WithoutModification);
                if (locations.Count > 0)
                {
                    if(locations.Count == 1)
                    {
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value = locations[0].state;
                        return true;
                    }
                }

                // If ((Location_Syd.location == varLocation.strip parenthesis part) && (Location_Syd.state == varState)
                // && (String.IsNullorEmptyString(varPostCode)||varPostCode does not exist in DB)
                // set varPostCode = Location_Syd.postcode;
                locations = locationCustomRepository.SelectByLocationAndPostCode(
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value,
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value,
                    LocationMatch.StripParenthesis);
                if (locations.Count > 0)
                {
                    if (locations.Count == 1)
                    {
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value = locations[0].state;
                        return true;
                    }
                }

                // If ( (String.IsNullorEmptyString(varPostCode)||(varPostCode does not exist in DB)) 
                // && String.IsNullorEmptyString(varState))
                // && varLocation == Location_Syd.location.strip parenthesis part)
                // set varPostCode = Location_Syd.postcode;
                // set varState = Location_Syd.state;
                // if(rowset>1) return -1
                // else 
                // set varPostCode = Location_Syd.postcode;
                // set varState = Location_Syd.state;
                
                if (
                    !String.IsNullOrEmpty(this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value) 
                    && (
                            (!locationCustomRepository.DoesPostCodeExist(this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value))
                            || String.IsNullOrEmpty(this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value) 
                        )
                   )
                {
                    var Locations = locationCustomRepository.GetLocationByLocation(this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value, LocationMatch.StripParenthesis);
                    if (Locations.Count > 0)
                    {
                        if (Locations.Count > 1)
                        {
                            #region ErrorXml
                                ErrorXml objErrorXml = unitOfWork.CreateErrorXml(
                                    clientCode,
                                    warehouseCode,
                                    orderNumber,
                                    varDocumentType,
                                    orderDate,
                                    DateTime.Now, String.IsNullOrEmpty(this.inProcessXML) ? "test xml" : this.inProcessXML);

                                unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                                unitOfWork.Save();
                            #endregion

                            #region ErrorInboundData
                            bool IsRectifiable = false;
                            IsRectifiable = this.LocalAttributes.Where(attr => attr.name.Equals(Constants.AddressValidator_CustomFields.location)).First().is_rectifiable;

                            ErrorInboundData errInboundData = unitOfWork.CreateErrorInboundData("Suburb",
                                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().path,
                                    "String",
                                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value,
                                    this.validator_type, "Suburb value is either null/empty or invalid",
                                    "", objErrorXml, IsRectifiable);
                                unitOfWork.ErrorInboundRepository.Insert(errInboundData);
                                unitOfWork.Save();
                            #endregion

                            #region ErrorSuggestion
                                Error_Suggestion_InboundData_Mapper esidmapObj = new Error_Suggestion_InboundData_Mapper();
                                esidmapObj.Id = Guid.NewGuid();
                                esidmapObj.ErrorSuggestionId = Constants.Suggestions.InvalidSuburbPostCodeState;
                                esidmapObj.ErrorInboundDataId = errInboundData.Id;
                                esidmapObj.DateTime = DateTime.Now;
                                unitOfWork.ErrorSuggestion_InboundDataRepository.Insert(esidmapObj);
                                unitOfWork.Save();
                            #endregion

                            return false;
                        }
                        else
                        {
                            this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value = Locations[0].state;
                            this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value = Locations[0].postcode;
                        }
                    }
                }

                // If ( (varPostCode == Location_Syd.postcode) 
                // && (Location_Syd.location.substring(0,5) == varlocation.substring(0,5)))
                // set varPostCode = Location_Syd.postcode;
                // set varState = Location_Syd.state;
                // set varLocation = Location_Syd.location;
                locations = locationCustomRepository.SelectByLocationAndPostCode(
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value,
                    this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value, 
                    LocationMatch.MatchFirst5Chars);
                if (locations.Count > 0)
                {
                    if (locations.Count == 1)
                    {
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value = locations[0].state;
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value = locations[0].postcode;
                    }
                }

                // if varLocation has parenthesis then possibility is that there is state in parenthesis.
                // if (varLocation.parenthesis part == state)
                // set varState=Location_Syd.state;
                // rerun all the checks
                // if varLocation spaces state-3chars
                // set varState=Location_Syd.state
                // rerun all the checks

                string stateTemp = ExtractStateFromLocation();
                string LocationTemp = ExtractLocationStrippingParenthesisOrSpaces();
                if (!String.IsNullOrEmpty(stateTemp))
                {
                    var tempLocations = locationCustomRepository.SelectByLocationPostCodeAndState(LocationTemp,
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.postCode).First<Attribute>().value,
                        stateTemp, LocationMatch.StripParenthesis);
                    if (tempLocations.Count > 1 || tempLocations.Count == 0)
                    {
                        #region ErrorXml
                        ErrorXml objErrorXml = unitOfWork.CreateErrorXml(
                            clientCode,
                            warehouseCode,
                            orderNumber,
                            varDocumentType, 
                            orderDate,
                                DateTime.Now, String.IsNullOrEmpty(this.inProcessXML) 
                                                ? "test xml" 
                                                : this.inProcessXML);

                            unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                            unitOfWork.Save();
                        #endregion

                        #region ErrorInboundData
                        bool IsRectifiable = false;
                        IsRectifiable = this.LocalAttributes.Where(attr => attr.name.Equals(Constants.AddressValidator_CustomFields.location)).First().is_rectifiable;

                        ErrorInboundData errInboundData = unitOfWork.CreateErrorInboundData("(Suburb / Postcode / State)",
                                "",
                                "(Suburb / Postcode / State) invalid",
                                "", this.validator_type,
                                "One of the field(Suburb / Postcode / State) value is either null/empty or invalid",
                                "", objErrorXml, IsRectifiable) ;

                            unitOfWork.ErrorInboundRepository.Insert(errInboundData);
                            unitOfWork.Save();
                        #endregion

                        #region ErrorSuggestion
                            Error_Suggestion_InboundData_Mapper esidmapObj = new Error_Suggestion_InboundData_Mapper();
                            esidmapObj.Id = Guid.NewGuid();
                            esidmapObj.ErrorSuggestionId = Constants.Suggestions.InvalidSuburbPostCodeState;
                            esidmapObj.ErrorInboundDataId = errInboundData.Id;
                            esidmapObj.DateTime = DateTime.Now;
                            unitOfWork.ErrorSuggestion_InboundDataRepository.Insert(esidmapObj);
                            unitOfWork.Save();
                        #endregion

                        return false;
                    }
                    else
                    {
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value = tempLocations[0].location;
                        this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.state).First<Attribute>().value = tempLocations[0].state;
                        continue;
                    }
                }
            }
        }

        //Extract State from Location
        private string ExtractStateFromLocation()
        {
            string returnVal = "";
            try
            {
                int stateIndex = 0;
                if (this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(")") > 0)
                {
                    stateIndex = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(")");
                    stateIndex -= 3;
                }
                else if (this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(" ") > 0)
                {
                    stateIndex = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(" ");
                    stateIndex += 1;
                }
                if (stateIndex > 0)
                {
                    returnVal = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.Substring(stateIndex, 3);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnVal.Trim();
        }

        private string ExtractLocationStrippingParenthesisOrSpaces()
        {
            string returnVal = "";
            try
            {
                int Index = 0;
                if (this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf("(") > 0)
                {
                    Index = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf("(");
                }
                else if (this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(" ") > 0)
                {
                    Index = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.LastIndexOf(" ");
                }
                if (Index > 0)
                {
                    returnVal = this.LocalAttributes.Where(item => item.name == Constants.AddressValidator_CustomFields.location).First<Attribute>().value.Substring(0, Index);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnVal.Trim();
        }


    }
}
