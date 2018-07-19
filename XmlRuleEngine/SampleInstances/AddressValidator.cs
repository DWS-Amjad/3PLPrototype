using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using ValidationRuleEngine.Interfaces;
using static ValidationRuleEngine.Constants;

namespace SampleInstances
{
    [Serializable]
    [XmlRoot(ElementName = "validation")]
    public class AddressValidator : IValidation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("validator_type")]
        public string validator_type { get; set; }

        [XmlAttribute("enabled")]
        public bool enabled { get; set; }

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

        public AddressValidator()
        {

        }

        public AddressValidator(string location, string postcode, string state)
        {
            this.varLocation = location.Trim();
            this.varPostCode = postcode.Trim();
            this.varState = state.Trim();
        }

        public void LoadVariables(XPathNavigator xpatheNavigator)
        {
            //run the XPath query
            XPathNodeIterator xPathLocation = xpatheNavigator.Select(Location);
            XPathNodeIterator xPathPostCode = xpatheNavigator.Select(postCode);
            XPathNodeIterator xPathState = xpatheNavigator.Select(State);

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
                

        public bool Validate(object obj)
        {
            Console.WriteLine("Stay Tuned Folks: AddressValidator To be implemented soon");
            IValidationContext context = (IValidationContext)obj;
            XDocument CurrentXmlDocument = new XDocument();
            
            if (!String.IsNullOrEmpty(Location))
            {
                XPathDocument xPathDoc = new XPathDocument(context.ParentElement.CreateReader());
                var xpatheNavigator = xPathDoc.CreateNavigator();

                LoadVariables(xpatheNavigator);
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
                        return false;
                    }
                    else                    {
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
