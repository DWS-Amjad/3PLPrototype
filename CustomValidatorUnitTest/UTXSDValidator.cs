using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationRuleEngine.Interfaces;
using ValidationRuleEngine.Implementations;
using System;
using System.Xml.Linq;

namespace CustomValidatorUnitTest
{
    [TestClass]
    public class UTXSDValidator
    {
        [TestMethod]
        public void TestXsdValidation()
        {
            string source_file_path = "../../DataFiles/SalesOrder/Sample_SO[8303].xml";
            XDocument doc = XDocument.Load(source_file_path);
            IEngine validatorEngine = new ValidatorEngine(doc);
            Assert.AreEqual(false, validatorEngine.Validation());
            // Write ValidatorEngine(XDocument) which will make inline calls
            // configure, start and stop.
            // and returns true/false based on successful validation.   
            // TODO: 1). Implement the logic for IsEditable
            // TODO: 2). Implement the logic for IsViewable
            // TODO: 3). Implement bool ValidationEngine.Validate() method
            // TODO: 4). Implement Validation.onFailureHalt attribute
            // TODO: 5). Save ValidatorType value in ErrorInboundData.errorType
            // TODO: 6). In XSD implement the logic to handle NonPrintableCharacters
            // TODO: 7). Local Custom Attributes should work with both rules, validators & actions level.
            // TODO: 8). Log all errors using Log4net
            // TODO: 9). In ValidationEngine contructor implement xsd validation of the config file.
            // TODO: 10). Unit test all task before commit it to Git.
        }
        //public void TestXsdValidation()
        //{
        //    XsdValidation val = new XsdValidation();
        //    try
        //    {
        //        var source_file_path = "../../../3PLPrototype/DataFiles/SalesOrder/Sample_SO[8303].xml";
        //        var documentType = "sales_order";
        //        var clientCode = "OUP";
        //        var companyCode = "W3";
        //        var warehouseCode = "01";
        //        var orderNumber = "0080000504";
        //        var orderDate = "20180503";
        //        var xsd_ns = "";
        //        var xsd_path = "../../../3PLPrototype/DataFiles/SalesOrder/SalesOrder.xsd";

        //        /**/
        //        UnitOfWork unitOfWork = new UnitOfWork();
        //        var configurationStore = new ConfigurationStore();
        //        ApplicationMaster objApplicationMaster = unitOfWork.ApplicationMasterRepository
        //        .SelectByID(Constants.ApplicationId);
        //        ValidationRuleEngine.Helper.XMLHelper<ConfigurationStore>.Instance
        //            .UnMarshalingFromXML(objApplicationMaster.ConfigFilePath, out configurationStore);
        //        /*--------------------*/

        //        var ConfigXmlDocument = XDocument.Load(objApplicationMaster.ConfigFilePath);
        //        var config = configurationStore.Items[0];
        //        /**/


        //        val.setupXsdValidator(clientCode, companyCode, warehouseCode, orderNumber,
        //            orderDate, documentType, xsd_ns, xsd_path);

        //        var CurrentXmlDocument = XDocument.Load(source_file_path);

        //        val.Validate(null, CurrentXmlDocument, documentType, config.fields);                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
