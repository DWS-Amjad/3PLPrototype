using DAL;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine;
using ValidationRuleEngine.Interfaces;
using static ValidationRuleEngine.Constants;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AddressValidator : ValidationRuleEngine.Implementations.Validation
    {
        #region Custom Properties
            [XmlElement("post_code")]
            public string postCode { get; set; }

            [XmlElement("location")]
            public string Location { get; set; }

            [XmlElement("state")]
            public string State { get; set; }
        #endregion

        #region Local Variables

            private string varLocation;
            private string varState;
            private string varPostCode;

        #endregion

        #region RepositoryObjectDeclaration
            private UnitOfWork unitOfWork = new UnitOfWork();
        #endregion

        public AddressValidator()
        {

        }

        public AddressValidator(string location, string postcode, string state)
        {
            this.varLocation = location.Trim();
            this.varPostCode = postcode.Trim();
            this.varState = state.Trim();
        }

        public void LoadVariables(XPathNavigator xpathNavigator)
        {
            //run the XPath query
            XPathNodeIterator xPathLocation = xpathNavigator.Select(Location);
            XPathNodeIterator xPathPostCode = xpathNavigator.Select(postCode);
            XPathNodeIterator xPathState = xpathNavigator.Select(State);

            //use the XPathNodeIterator to display the results
            if (xPathLocation.Count > 0)
            {
                while (xPathLocation.MoveNext())
                {
                    varLocation = xPathLocation.Current.Value.Trim();
                    Console.WriteLine(xPathLocation.Current.Value.Trim());
                }
            }
            else
            {
                Console.WriteLine("No Location found in Sales Order.");
            }

            //use the XPathNodeIterator to display the results
            if (xPathPostCode.Count > 0)
            {
                while (xPathPostCode.MoveNext())
                {
                    varPostCode = xPathPostCode.Current.Value.Trim();
                    Console.WriteLine(xPathPostCode.Current.Value.Trim());
                }
            }
            else
            {
                Console.WriteLine("No PostCode found in Sales Order.");
            }

            //use the XPathNodeIterator to display the results
            if (xPathState.Count > 0)
            {
                while (xPathState.MoveNext())
                {
                    varState = xPathState.Current.Value.Trim();
                    Console.WriteLine(xPathState.Current.Value.Trim());
                }
            }
            else
            {
                Console.WriteLine("No State found in Sales Order.");
            }
        }
        
        public override bool Validate(object obj, XDocument currXDocument, string DocumentType, string orderNumber, string orderDate)
        {
            base.Validate(obj, currXDocument, DocumentType, orderNumber, orderDate);
            Console.WriteLine("Stay Tuned Folks: AddressValidator To be implemented soon");
            IValidationContext context = (IValidationContext)obj;
            XDocument CurrentXmlDocument = new XDocument();
            
            if (!String.IsNullOrEmpty(Location))
            {
                XPathDocument xPathDoc = new XPathDocument(context.ParentElement.CreateReader());
                var xpathNavigator = xPathDoc.CreateNavigator();

                LoadVariables(xpathNavigator);
            }

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
                if (this.varPostCode.Trim().Equals("9999"))
                {
                    this.varState = "ITL";
                    return true;
                }

                // If String.IsNullorEmpty(varLocation) == true
                // Then return -1;
                // Else If select row in Location_Syd 
                // Where (Location_Syd.postCode == varPostCode) 
                // && (Location_Syd.location == varLocation)
                // && (Location_Syd.state == varState)
                // Then return 0;
                if (String.IsNullOrEmpty(varLocation))
                {
                    // Make entry in ErrorXML, ErrorInboundData & ErrorSuggestion
                    #region ErrorXml
                        ErrorXml objErrorXml = new ErrorXml();
                        objErrorXml.Id = Guid.NewGuid();
                        objErrorXml.TimeStamp = DateTime.Now;
                        objErrorXml.Warehouse_Code = "dummyWHCode";
                        objErrorXml.XmlContent = String.IsNullOrEmpty(this.inProcessXML) ? "test xml" : this.inProcessXML;
                        objErrorXml.Client_Code = "dummyClientCode";
                        objErrorXml.DocumentUniqueId = "dummy doc unique field";
                        objErrorXml.OrderDate = DateTime.ParseExact(String.IsNullOrEmpty(varOrderDate) ? "20180503" : varOrderDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                        objErrorXml.DocumentType = varDocumentType;
                        unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                        unitOfWork.Save();
                    #endregion

                    #region ErrorInboundData
                        ErrorInboundData errInboundData = new ErrorInboundData();
                        errInboundData.Id = Guid.NewGuid();
                        errInboundData.CustomErrorMsg = "";
                        errInboundData.DataPath = "dummy value";
                        errInboundData.DataKey = "suburb";
                        errInboundData.DataValue = "";
                        errInboundData.DataType = "suburb";
                        errInboundData.ErrorType = "";
                        errInboundData.ErrorXmlId = objErrorXml.Id;
                        errInboundData.SysErrorMsg = "Suburb value is either null/empty or invalid";
                        errInboundData.TimeStamp = DateTime.Now;
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
                    locations = locationCustomRepository.SelectByLocationPostCodeAndState(varLocation, varPostCode, varState, LocationMatch.WithoutModification);

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
                locations = locationCustomRepository.SelectByLocationPostCodeAndState(varLocation, varPostCode, varState, LocationMatch.StripParenthesis);
                if (locations.Count == 1)
                {
                    return true;
                }

                // If ((Location_Syd.location == varLocation) && (Location_Syd.postcode == varPostCode))
                // set varState = Location_Syd.state;
                locations = locationCustomRepository.SelectByLocationAndPostCode(varLocation, varPostCode, LocationMatch.WithoutModification);
                if (locations.Count > 0)
                {
                    if(locations.Count == 1)
                    {
                        varState = locations[0].state;
                        return true;
                    }
                }

                // If ((Location_Syd.location == varLocation.strip parenthesis part) && (Location_Syd.state == varState)
                // && (String.IsNullorEmptyString(varPostCode)||varPostCode does not exist in DB)
                // set varPostCode = Location_Syd.postcode;
                locations = locationCustomRepository.SelectByLocationAndPostCode(varLocation, varPostCode, LocationMatch.StripParenthesis);
                if (locations.Count > 0)
                {
                    if (locations.Count == 1)
                    {
                        varState = locations[0].state;
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
                    !String.IsNullOrEmpty(varState) 
                    && (
                            (!locationCustomRepository.DoesPostCodeExist(varPostCode))
                            || String.IsNullOrEmpty(varPostCode) 
                        )
                   )
                {
                    var Locations = locationCustomRepository.GetLocationByLocation(varLocation, LocationMatch.StripParenthesis);
                    if (Locations.Count > 0)
                    {
                        if (Locations.Count > 1)
                        {
                            #region ErrorXml
                                ErrorXml objErrorXml = new ErrorXml();
                                objErrorXml.Id = Guid.NewGuid();
                                objErrorXml.TimeStamp = DateTime.Now;
                                objErrorXml.Warehouse_Code = "dummyWHCode";
                                objErrorXml.XmlContent = String.IsNullOrEmpty(this.inProcessXML) ? "test xml" : this.inProcessXML;
                                objErrorXml.Client_Code = "dummyClientCode";
                                objErrorXml.DocumentUniqueId = "dummy doc unique field";
                                objErrorXml.OrderDate = DateTime.ParseExact(String.IsNullOrEmpty(varOrderDate) ? "20180503" : varOrderDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                                objErrorXml.DocumentType = varDocumentType;
                                unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                                unitOfWork.Save();
                            #endregion

                            #region ErrorInboundData
                                ErrorInboundData errInboundData = new ErrorInboundData();
                                errInboundData.Id = Guid.NewGuid();
                                errInboundData.CustomErrorMsg = "";
                                errInboundData.DataPath = "dummy value";
                                errInboundData.DataKey = "suburb";
                                errInboundData.DataValue = "";
                                errInboundData.DataType = "suburb";
                                errInboundData.ErrorType = "";
                                errInboundData.ErrorXmlId = objErrorXml.Id;
                                errInboundData.SysErrorMsg = "Suburb value is either null/empty or invalid";
                                errInboundData.TimeStamp = DateTime.Now;
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
                            varState = Locations[0].state;
                            varPostCode = Locations[0].postcode;
                        }
                    }
                }

                // If ( (varPostCode == Location_Syd.postcode) 
                // && (Location_Syd.location.substring(0,5) == varlocation.substring(0,5)))
                // set varPostCode = Location_Syd.postcode;
                // set varState = Location_Syd.state;
                // set varLocation = Location_Syd.location;
                locations = locationCustomRepository.SelectByLocationAndPostCode(varLocation, varPostCode, LocationMatch.MatchFirst5Chars);
                if (locations.Count > 0)
                {
                    if (locations.Count == 1)
                    {
                        varState = locations[0].state;
                        varPostCode = locations[0].postcode;
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
                    var tempLocations = locationCustomRepository.SelectByLocationPostCodeAndState(LocationTemp, varPostCode, stateTemp, LocationMatch.StripParenthesis);
                    if (tempLocations.Count > 1 || tempLocations.Count == 0)
                    {
                        #region ErrorXml
                            ErrorXml objErrorXml = new ErrorXml();
                            objErrorXml.Id = Guid.NewGuid();
                            objErrorXml.TimeStamp = DateTime.Now;
                            objErrorXml.Warehouse_Code = "dummyWHCode";
                            objErrorXml.XmlContent = String.IsNullOrEmpty(this.inProcessXML) ? "test xml" : this.inProcessXML;
                            objErrorXml.Client_Code = "dummyClientCode";
                            objErrorXml.DocumentUniqueId = "dummy doc unique field";
                            objErrorXml.OrderDate = DateTime.ParseExact(String.IsNullOrEmpty(varOrderDate) ? "20180503" : varOrderDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                            objErrorXml.DocumentType = varDocumentType;
                            unitOfWork.ErrorXmlRepository.Insert(objErrorXml);
                            unitOfWork.Save();
                        #endregion

                        #region ErrorInboundData
                            ErrorInboundData errInboundData = new ErrorInboundData();
                            errInboundData.Id = Guid.NewGuid();
                            errInboundData.CustomErrorMsg = "";
                            errInboundData.DataPath = "dummy value";
                            errInboundData.DataKey = "(Suburb / Postcode / State) invalid";
                            errInboundData.DataValue = "";
                            errInboundData.DataType = "(Suburb / Postcode / State) invalid";
                            errInboundData.ErrorType = "";
                            errInboundData.ErrorXmlId = objErrorXml.Id;
                            errInboundData.SysErrorMsg = "One of the field(Suburb / Postcode / State) value is either null/empty or invalid";
                            errInboundData.TimeStamp = DateTime.Now;
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
                        varLocation = tempLocations[0].location;
                        varState = tempLocations[0].state;
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
                if (varLocation.LastIndexOf(")") > 0)
                {
                    stateIndex = varLocation.LastIndexOf(")");
                    stateIndex -= 3;
                }
                else if (varLocation.LastIndexOf(" ") > 0)
                {
                    stateIndex = varLocation.LastIndexOf(" ");
                    stateIndex += 1;
                }
                if (stateIndex > 0)
                {
                    returnVal = varLocation.Substring(stateIndex, 3);
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
                if (varLocation.LastIndexOf("(") > 0)
                {
                    Index = varLocation.LastIndexOf("(");
                }
                else if (varLocation.LastIndexOf(" ") > 0)
                {
                    Index = varLocation.LastIndexOf(" ");
                }
                if (Index > 0)
                {
                    returnVal = varLocation.Substring(0, Index);
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
