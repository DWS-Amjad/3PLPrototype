using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationRuleEngine.Interfaces;
using ValidationRuleEngine.Implementations;

namespace CustomValidatorUnitTest
{
    [TestClass]
    public class UTXSDValidator
    {
        [TestMethod]
        public void TestXsdValidation()
        {
            IEngine validatorEngine = new ValidatorEngine();
            validatorEngine.Configure();
            validatorEngine.Start();
            validatorEngine.Stop();
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
