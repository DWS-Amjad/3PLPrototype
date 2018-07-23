using Microsoft.VisualStudio.TestTools.UnitTesting;
using Customizations;

namespace UnitTest
{
    [TestClass]
    public class UTAddressValidator
    {
        [TestMethod]
        public void TestInternationalCodeScenario()
        {
            /*
             Testcase Scenarios:
             1). International Post Codes => 
                    Location:"", PostCode:"9999", state:""
             */
            AddressValidator val = new AddressValidator("", "9999", "");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestAllEmptyVariableScenario()
        {
            /*
             2). all variables are empty => 
                    Location:"", PostCode:"", state:""
             */
            AddressValidator val = new AddressValidator("", "", "");
            try
            {
                Assert.AreEqual(false, val.ValidateAddressFields());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }

        [TestMethod]
        public void TestAllVariableExistsScenario()
        {
            /* Error Suggestion: Unable to match: One or more of the values(suburb, postcode, state) invalid
             3). all variables exists in database => 
                    Location:"AGNES WATER", PostCode:"4677", state:"QLD"
             */
            AddressValidator val = new AddressValidator("AGNES WATER", "4677", "QLD");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestAllVariableMatcheswithDB_LocationStrippedParenthesisPartScenario()
        {
            /* Error Suggestion: Unable to match: 
             4). all variables matches with a entry in DB if db.location is strip of the parenthesis part
                    Location:"AGNES BANKS", PostCode:"2750", state:"NSW"
             */
            AddressValidator val = new AddressValidator("AGNES BANKS", "2750", "NSW");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioWhenAllVariableMatchesIfStateIsStrippedFromLocation()
        {
            /* Error Suggestion: Unable to match: 
             5). all variables matches with an entry in DB if varLocation is strip of state which is in parenthesis
                    Location:"AGNES BANKS (NSW)", PostCode: "2750", state: ""
            */
            AddressValidator val = new AddressValidator("AGNES BANKS (NSW)", "2750", "");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioWhenAllVariablesMatchesIfLocationIsStrippedOutOfPartAfterSpace()
        {
            /*Error Suggestion: Unable to match: Invalid state value
             6). all variables matches with an entry in DB if varLocation is strip of state which is follows location after space
                    Location:"AGNES BANKS NSW", PostCode:"2750", state:""
            */
            AddressValidator val = new AddressValidator("AGNES BANKS (NSW)", "2750", "");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioAllVariablesMatchesWhenDB_Location_ParenthesisPartStripped()
        {
            /*Error Suggestion: Unable to match: Invalid suburb value
                  7). all variables matches if parenthesis part is stripped from DB.Location
                    Location:"ASCOT", PostCode:"4359", state:"QLD"	
            */
            AddressValidator val = new AddressValidator("ASCOT", "4359", "QLD");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioWhenLocationPostCodeMatchesStateMissingIfDb_LocationStrippedOfParenthesisPart()
        {
            /*Error Suggestion: Unable to match: Invalid state value
             8). location and postcode matches and state is missing and if DB.Location stripped out of parenthesis part
                    Location:"ASCOT", PostCode:"3551", state:""
            */
            AddressValidator val = new AddressValidator("ASCOT", "3551", "");
            Assert.AreEqual(true, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioWhenLocationStateMatchesPostCodeEitherEmptyNotExistInDBIfLocationStrippedOutOfParenthesisPart()
        {
            /*   Error Suggestion: Unable to match: Invalid postcode value
               9). location and state matches but postcode does not match and location matches only after stripping parenthesis part
                      Location & State matches => 
                      Location:"ASCOT", PostCode:"1111", State:"VIC"
            */
            AddressValidator val = new AddressValidator("ASCOT", "1111", "VIC");
            //because there are more than 1 value of ascot under state victoria
            Assert.AreEqual(false, val.ValidateAddressFields());
        }

        [TestMethod]
        public void TestScenarioWhenAllVariableMatchesIfFirst5CharactersOfDB_LocationIsConsidered()
        {
            /*   Error Suggestion: Unable to match: Invalid suburb value
             10). first 5 characters and post matches => 
                    Location:"ASCOTabcd", PostCode:"3032", State:"VIC"
            */
            AddressValidator val = new AddressValidator("ASCOT", "3032", "VIC");
            //more than 1 value if we consider first 5 characters and match postcode and state
            Assert.AreEqual(false, val.ValidateAddressFields());
        }

    }
}
