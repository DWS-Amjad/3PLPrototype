
using System.Xml.Serialization;

namespace _3PLPrototype.DataFiles.SalesOrder
{
}

namespace ValidationRuleEngine.DataFiles.SalesOrder
{
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
[XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class SalesOrders {
    
    private OrderHeader[] itemsField;
    
    /// <remarks/>
    [XmlElementAttribute("OrderHeader", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public OrderHeader[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class OrderHeader {
    
    private string hostIDField;
    
    private string companyCodeField;
    
    private string clientCodeField;
    
    private string warehouseCodeField;
    
    private string orderNumberField;
    
    private string origOrderNumberField;
    
    private string accellosOrderNumberField;
    
    private string purchaseOrderNumberField;
    
    private string customerReferenceField;
    
    private string clientASNNumberField;
    
    private string asnIDField;
    
    private string clientEDIAddressField;
    
    private string retailerEDIAddressField;
    
    private string retailerNumberField;
    
    private string promotionNumberField;
    
    private string vendorNumberField;
    
    private string invoiceRequiredField;
    
    private string asnRequiredField;
    
    private string packSlipRequiredField;
    
    private string priceTicketRequiredField;
    
    private string salesOrderAcknowledgementRequiredField;
    
    private string pickConfirmationAcknowledgementRequiredField;
    
    private string asnAcknowledgementRequiredField;
    
    private string orderConfirmedField;
    
    private string despatchEmailNotificationRequiredField;
    
    private string orderTypeField;
    
    private string orderClassField;
    
    private string orderDateField;
    
    private string customerOrderDateField;
    
    private string deliveryDateField;
    
    private string requestedArrivalDateField;
    
    private string deliveryDateBeforeField;
    
    private string deliveryDateAfterField;
    
    private string despatchDateField;
    
    private string shipDateField;
    
    private string earliestShipDateField;
    
    private string latestShipDateField;
    
    private string releaseDateField;
    
    private string cancellationDateField;
    
    private string etaDateField;
    
    private string cutOffTimeField;
    
    private string shipToCodeField;
    
    private string shipToDepartmentField;
    
    private string shipToName1Field;
    
    private string shipToName2Field;
    
    private string shipToAddress1Field;
    
    private string shipToAddress2Field;
    
    private string shipToAddress3Field;
    
    private string shipToLocationField;
    
    private string shipToPostcodeField;
    
    private string shipToStateField;
    
    private string shipToCountryCodeField;
    
    private string shipToCountryNameField;
    
    private string shipToPhoneNumberField;
    
    private string shipToAccountNumberField;
    
    private string shipToEmailAddressField;
    
    private string shipToEmailSalutationField;
    
    private string shipToDepotField;
    
    private string deliverToCodeField;
    
    private string deliverToName1Field;
    
    private string deliverToName2Field;
    
    private string deliverToAddress1Field;
    
    private string deliverToAddress2Field;
    
    private string deliverToAddress3Field;
    
    private string deliverToLocationField;
    
    private string deliverToPostcodeField;
    
    private string deliverToStateField;
    
    private string deliverToCountryCodeField;
    
    private string deliverToCountryNameField;
    
    private string deliverToPhoneNumberField;
    
    private string deliverToAccountNumberField;
    
    private string deliverToEmailAddressField;
    
    private string deliverToEmailSalutationField;
    
    private string billToCodeField;
    
    private string billToName1Field;
    
    private string billToName2Field;
    
    private string billToAddress1Field;
    
    private string billToAddress2Field;
    
    private string billToAddress3Field;
    
    private string billToLocationField;
    
    private string billToPostcodeField;
    
    private string billToStateField;
    
    private string billToCountryCodeField;
    
    private string billToCountryNameField;
    
    private string billToPhoneNumberField;
    
    private string billToAccountNumberField;
    
    private string billToEmailAddressField;
    
    private string billToEmailSalutationField;
    
    private string departmentNumberField;
    
    private string departmentNameField;
    
    private string specialInstructions1Field;
    
    private string specialInstructions2Field;
    
    private string specialInstructions3Field;
    
    private string warehouseInstructions1Field;
    
    private string warehouseInstructions2Field;
    
    private string referenceField1Field;
    
    private string referenceField2Field;
    
    private string referenceField3Field;
    
    private string referenceField4Field;
    
    private string referenceField5Field;
    
    private string labelText1Field;
    
    private string labelText2Field;
    
    private string labelText3Field;
    
    private string sendersReferenceField;
    
    private string labelCodeField;
    
    private string advertisedDateField;
    
    private string abnField;
    
    private string invoiceNumberField;
    
    private string invoiceDateField;
    
    private string invoiceDueDateField;
    
    private string invoiceHeaderTextField;
    
    private string invoiceTermsField;
    
    private string freightDescriptionField;
    
    private string freightTotalField;
    
    private string surchargeTotalField;
    
    private string miscellaneousTotal1Field;
    
    private string miscellaneousTotal2Field;
    
    private string gstTotalField;
    
    private string subTotalField;
    
    private string invoiceTotalField;
    
    private string currencyCodeField;
    
    private string totalWeightField;
    
    private string totalVolumeField;
    
    private string totalQuantityField;
    
    private string totalCartonsField;
    
    private string serviceCodeField;
    
    private string carrierAbbreviationField;
    
    private string useAlternateDespatchIDField;
    
    private string specialServiceFlagField;
    
    private string payerTypeField;
    
    private string payerName1Field;
    
    private string payerName2Field;
    
    private string payerAccountNumberField;
    
    private string userDefinedField1Field;
    
    private string userDefinedField2Field;
    
    private string userDefinedField3Field;
    
    private string userDefinedField4Field;
    
    private string userDefinedField5Field;
    
    private string userDefinedField6Field;
    
    private string userDefinedField7Field;
    
    private string userDefinedField8Field;
    
    private string userDefinedField9Field;
    
    private string userDefinedField10Field;
    
    private string connoteNumberField;
    
    private string originCodeField;
    
    private OrderDetail[] orderDetailField;
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string hostID {
        get {
            return this.hostIDField;
        }
        set {
            this.hostIDField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string companyCode {
        get {
            return this.companyCodeField;
        }
        set {
            this.companyCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clientCode {
        get {
            return this.clientCodeField;
        }
        set {
            this.clientCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string warehouseCode {
        get {
            return this.warehouseCodeField;
        }
        set {
            this.warehouseCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string orderNumber {
        get {
            return this.orderNumberField;
        }
        set {
            this.orderNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string origOrderNumber {
        get {
            return this.origOrderNumberField;
        }
        set {
            this.origOrderNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accellosOrderNumber {
        get {
            return this.accellosOrderNumberField;
        }
        set {
            this.accellosOrderNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string purchaseOrderNumber {
        get {
            return this.purchaseOrderNumberField;
        }
        set {
            this.purchaseOrderNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string customerReference {
        get {
            return this.customerReferenceField;
        }
        set {
            this.customerReferenceField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clientASNNumber {
        get {
            return this.clientASNNumberField;
        }
        set {
            this.clientASNNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string asnID {
        get {
            return this.asnIDField;
        }
        set {
            this.asnIDField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string clientEDIAddress {
        get {
            return this.clientEDIAddressField;
        }
        set {
            this.clientEDIAddressField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string retailerEDIAddress {
        get {
            return this.retailerEDIAddressField;
        }
        set {
            this.retailerEDIAddressField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string retailerNumber {
        get {
            return this.retailerNumberField;
        }
        set {
            this.retailerNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string promotionNumber {
        get {
            return this.promotionNumberField;
        }
        set {
            this.promotionNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string vendorNumber {
        get {
            return this.vendorNumberField;
        }
        set {
            this.vendorNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceRequired {
        get {
            return this.invoiceRequiredField;
        }
        set {
            this.invoiceRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string asnRequired {
        get {
            return this.asnRequiredField;
        }
        set {
            this.asnRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string packSlipRequired {
        get {
            return this.packSlipRequiredField;
        }
        set {
            this.packSlipRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string priceTicketRequired {
        get {
            return this.priceTicketRequiredField;
        }
        set {
            this.priceTicketRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string salesOrderAcknowledgementRequired {
        get {
            return this.salesOrderAcknowledgementRequiredField;
        }
        set {
            this.salesOrderAcknowledgementRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string pickConfirmationAcknowledgementRequired {
        get {
            return this.pickConfirmationAcknowledgementRequiredField;
        }
        set {
            this.pickConfirmationAcknowledgementRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string asnAcknowledgementRequired {
        get {
            return this.asnAcknowledgementRequiredField;
        }
        set {
            this.asnAcknowledgementRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string orderConfirmed {
        get {
            return this.orderConfirmedField;
        }
        set {
            this.orderConfirmedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string despatchEmailNotificationRequired {
        get {
            return this.despatchEmailNotificationRequiredField;
        }
        set {
            this.despatchEmailNotificationRequiredField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string orderType {
        get {
            return this.orderTypeField;
        }
        set {
            this.orderTypeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string orderClass {
        get {
            return this.orderClassField;
        }
        set {
            this.orderClassField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string orderDate {
        get {
            return this.orderDateField;
        }
        set {
            this.orderDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string customerOrderDate {
        get {
            return this.customerOrderDateField;
        }
        set {
            this.customerOrderDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliveryDate {
        get {
            return this.deliveryDateField;
        }
        set {
            this.deliveryDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string requestedArrivalDate {
        get {
            return this.requestedArrivalDateField;
        }
        set {
            this.requestedArrivalDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliveryDateBefore {
        get {
            return this.deliveryDateBeforeField;
        }
        set {
            this.deliveryDateBeforeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliveryDateAfter {
        get {
            return this.deliveryDateAfterField;
        }
        set {
            this.deliveryDateAfterField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string despatchDate {
        get {
            return this.despatchDateField;
        }
        set {
            this.despatchDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipDate {
        get {
            return this.shipDateField;
        }
        set {
            this.shipDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string earliestShipDate {
        get {
            return this.earliestShipDateField;
        }
        set {
            this.earliestShipDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string latestShipDate {
        get {
            return this.latestShipDateField;
        }
        set {
            this.latestShipDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string releaseDate {
        get {
            return this.releaseDateField;
        }
        set {
            this.releaseDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cancellationDate {
        get {
            return this.cancellationDateField;
        }
        set {
            this.cancellationDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string etaDate {
        get {
            return this.etaDateField;
        }
        set {
            this.etaDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string cutOffTime {
        get {
            return this.cutOffTimeField;
        }
        set {
            this.cutOffTimeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToCode {
        get {
            return this.shipToCodeField;
        }
        set {
            this.shipToCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToDepartment {
        get {
            return this.shipToDepartmentField;
        }
        set {
            this.shipToDepartmentField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToName1 {
        get {
            return this.shipToName1Field;
        }
        set {
            this.shipToName1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToName2 {
        get {
            return this.shipToName2Field;
        }
        set {
            this.shipToName2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToAddress1 {
        get {
            return this.shipToAddress1Field;
        }
        set {
            this.shipToAddress1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToAddress2 {
        get {
            return this.shipToAddress2Field;
        }
        set {
            this.shipToAddress2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToAddress3 {
        get {
            return this.shipToAddress3Field;
        }
        set {
            this.shipToAddress3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToLocation {
        get {
            return this.shipToLocationField;
        }
        set {
            this.shipToLocationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToPostcode {
        get {
            return this.shipToPostcodeField;
        }
        set {
            this.shipToPostcodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToState {
        get {
            return this.shipToStateField;
        }
        set {
            this.shipToStateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToCountryCode {
        get {
            return this.shipToCountryCodeField;
        }
        set {
            this.shipToCountryCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToCountryName {
        get {
            return this.shipToCountryNameField;
        }
        set {
            this.shipToCountryNameField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToPhoneNumber {
        get {
            return this.shipToPhoneNumberField;
        }
        set {
            this.shipToPhoneNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToAccountNumber {
        get {
            return this.shipToAccountNumberField;
        }
        set {
            this.shipToAccountNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToEmailAddress {
        get {
            return this.shipToEmailAddressField;
        }
        set {
            this.shipToEmailAddressField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToEmailSalutation {
        get {
            return this.shipToEmailSalutationField;
        }
        set {
            this.shipToEmailSalutationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string shipToDepot {
        get {
            return this.shipToDepotField;
        }
        set {
            this.shipToDepotField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToCode {
        get {
            return this.deliverToCodeField;
        }
        set {
            this.deliverToCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToName1 {
        get {
            return this.deliverToName1Field;
        }
        set {
            this.deliverToName1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToName2 {
        get {
            return this.deliverToName2Field;
        }
        set {
            this.deliverToName2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToAddress1 {
        get {
            return this.deliverToAddress1Field;
        }
        set {
            this.deliverToAddress1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToAddress2 {
        get {
            return this.deliverToAddress2Field;
        }
        set {
            this.deliverToAddress2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToAddress3 {
        get {
            return this.deliverToAddress3Field;
        }
        set {
            this.deliverToAddress3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToLocation {
        get {
            return this.deliverToLocationField;
        }
        set {
            this.deliverToLocationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToPostcode {
        get {
            return this.deliverToPostcodeField;
        }
        set {
            this.deliverToPostcodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToState {
        get {
            return this.deliverToStateField;
        }
        set {
            this.deliverToStateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToCountryCode {
        get {
            return this.deliverToCountryCodeField;
        }
        set {
            this.deliverToCountryCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToCountryName {
        get {
            return this.deliverToCountryNameField;
        }
        set {
            this.deliverToCountryNameField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToPhoneNumber {
        get {
            return this.deliverToPhoneNumberField;
        }
        set {
            this.deliverToPhoneNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToAccountNumber {
        get {
            return this.deliverToAccountNumberField;
        }
        set {
            this.deliverToAccountNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToEmailAddress {
        get {
            return this.deliverToEmailAddressField;
        }
        set {
            this.deliverToEmailAddressField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string deliverToEmailSalutation {
        get {
            return this.deliverToEmailSalutationField;
        }
        set {
            this.deliverToEmailSalutationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToCode {
        get {
            return this.billToCodeField;
        }
        set {
            this.billToCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToName1 {
        get {
            return this.billToName1Field;
        }
        set {
            this.billToName1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToName2 {
        get {
            return this.billToName2Field;
        }
        set {
            this.billToName2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToAddress1 {
        get {
            return this.billToAddress1Field;
        }
        set {
            this.billToAddress1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToAddress2 {
        get {
            return this.billToAddress2Field;
        }
        set {
            this.billToAddress2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToAddress3 {
        get {
            return this.billToAddress3Field;
        }
        set {
            this.billToAddress3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToLocation {
        get {
            return this.billToLocationField;
        }
        set {
            this.billToLocationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToPostcode {
        get {
            return this.billToPostcodeField;
        }
        set {
            this.billToPostcodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToState {
        get {
            return this.billToStateField;
        }
        set {
            this.billToStateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToCountryCode {
        get {
            return this.billToCountryCodeField;
        }
        set {
            this.billToCountryCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToCountryName {
        get {
            return this.billToCountryNameField;
        }
        set {
            this.billToCountryNameField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToPhoneNumber {
        get {
            return this.billToPhoneNumberField;
        }
        set {
            this.billToPhoneNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToAccountNumber {
        get {
            return this.billToAccountNumberField;
        }
        set {
            this.billToAccountNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToEmailAddress {
        get {
            return this.billToEmailAddressField;
        }
        set {
            this.billToEmailAddressField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string billToEmailSalutation {
        get {
            return this.billToEmailSalutationField;
        }
        set {
            this.billToEmailSalutationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string departmentNumber {
        get {
            return this.departmentNumberField;
        }
        set {
            this.departmentNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string departmentName {
        get {
            return this.departmentNameField;
        }
        set {
            this.departmentNameField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string specialInstructions1 {
        get {
            return this.specialInstructions1Field;
        }
        set {
            this.specialInstructions1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string specialInstructions2 {
        get {
            return this.specialInstructions2Field;
        }
        set {
            this.specialInstructions2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string specialInstructions3 {
        get {
            return this.specialInstructions3Field;
        }
        set {
            this.specialInstructions3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string warehouseInstructions1 {
        get {
            return this.warehouseInstructions1Field;
        }
        set {
            this.warehouseInstructions1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string warehouseInstructions2 {
        get {
            return this.warehouseInstructions2Field;
        }
        set {
            this.warehouseInstructions2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string referenceField1 {
        get {
            return this.referenceField1Field;
        }
        set {
            this.referenceField1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string referenceField2 {
        get {
            return this.referenceField2Field;
        }
        set {
            this.referenceField2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string referenceField3 {
        get {
            return this.referenceField3Field;
        }
        set {
            this.referenceField3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string referenceField4 {
        get {
            return this.referenceField4Field;
        }
        set {
            this.referenceField4Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string referenceField5 {
        get {
            return this.referenceField5Field;
        }
        set {
            this.referenceField5Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string labelText1 {
        get {
            return this.labelText1Field;
        }
        set {
            this.labelText1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string labelText2 {
        get {
            return this.labelText2Field;
        }
        set {
            this.labelText2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string labelText3 {
        get {
            return this.labelText3Field;
        }
        set {
            this.labelText3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sendersReference {
        get {
            return this.sendersReferenceField;
        }
        set {
            this.sendersReferenceField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string labelCode {
        get {
            return this.labelCodeField;
        }
        set {
            this.labelCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string advertisedDate {
        get {
            return this.advertisedDateField;
        }
        set {
            this.advertisedDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string abn {
        get {
            return this.abnField;
        }
        set {
            this.abnField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceNumber {
        get {
            return this.invoiceNumberField;
        }
        set {
            this.invoiceNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceDate {
        get {
            return this.invoiceDateField;
        }
        set {
            this.invoiceDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceDueDate {
        get {
            return this.invoiceDueDateField;
        }
        set {
            this.invoiceDueDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceHeaderText {
        get {
            return this.invoiceHeaderTextField;
        }
        set {
            this.invoiceHeaderTextField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceTerms {
        get {
            return this.invoiceTermsField;
        }
        set {
            this.invoiceTermsField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string freightDescription {
        get {
            return this.freightDescriptionField;
        }
        set {
            this.freightDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string freightTotal {
        get {
            return this.freightTotalField;
        }
        set {
            this.freightTotalField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string surchargeTotal {
        get {
            return this.surchargeTotalField;
        }
        set {
            this.surchargeTotalField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string miscellaneousTotal1 {
        get {
            return this.miscellaneousTotal1Field;
        }
        set {
            this.miscellaneousTotal1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string miscellaneousTotal2 {
        get {
            return this.miscellaneousTotal2Field;
        }
        set {
            this.miscellaneousTotal2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string gstTotal {
        get {
            return this.gstTotalField;
        }
        set {
            this.gstTotalField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string subTotal {
        get {
            return this.subTotalField;
        }
        set {
            this.subTotalField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string invoiceTotal {
        get {
            return this.invoiceTotalField;
        }
        set {
            this.invoiceTotalField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string currencyCode {
        get {
            return this.currencyCodeField;
        }
        set {
            this.currencyCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalWeight {
        get {
            return this.totalWeightField;
        }
        set {
            this.totalWeightField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalVolume {
        get {
            return this.totalVolumeField;
        }
        set {
            this.totalVolumeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalQuantity {
        get {
            return this.totalQuantityField;
        }
        set {
            this.totalQuantityField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string totalCartons {
        get {
            return this.totalCartonsField;
        }
        set {
            this.totalCartonsField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string serviceCode {
        get {
            return this.serviceCodeField;
        }
        set {
            this.serviceCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string carrierAbbreviation {
        get {
            return this.carrierAbbreviationField;
        }
        set {
            this.carrierAbbreviationField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string useAlternateDespatchID {
        get {
            return this.useAlternateDespatchIDField;
        }
        set {
            this.useAlternateDespatchIDField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string specialServiceFlag {
        get {
            return this.specialServiceFlagField;
        }
        set {
            this.specialServiceFlagField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string payerType {
        get {
            return this.payerTypeField;
        }
        set {
            this.payerTypeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string payerName1 {
        get {
            return this.payerName1Field;
        }
        set {
            this.payerName1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string payerName2 {
        get {
            return this.payerName2Field;
        }
        set {
            this.payerName2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string payerAccountNumber {
        get {
            return this.payerAccountNumberField;
        }
        set {
            this.payerAccountNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField1 {
        get {
            return this.userDefinedField1Field;
        }
        set {
            this.userDefinedField1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField2 {
        get {
            return this.userDefinedField2Field;
        }
        set {
            this.userDefinedField2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField3 {
        get {
            return this.userDefinedField3Field;
        }
        set {
            this.userDefinedField3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField4 {
        get {
            return this.userDefinedField4Field;
        }
        set {
            this.userDefinedField4Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField5 {
        get {
            return this.userDefinedField5Field;
        }
        set {
            this.userDefinedField5Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField6 {
        get {
            return this.userDefinedField6Field;
        }
        set {
            this.userDefinedField6Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField7 {
        get {
            return this.userDefinedField7Field;
        }
        set {
            this.userDefinedField7Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField8 {
        get {
            return this.userDefinedField8Field;
        }
        set {
            this.userDefinedField8Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField9 {
        get {
            return this.userDefinedField9Field;
        }
        set {
            this.userDefinedField9Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField10 {
        get {
            return this.userDefinedField10Field;
        }
        set {
            this.userDefinedField10Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string connoteNumber {
        get {
            return this.connoteNumberField;
        }
        set {
            this.connoteNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string originCode {
        get {
            return this.originCodeField;
        }
        set {
            this.originCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute("OrderDetail", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public OrderDetail[] OrderDetail {
        get {
            return this.orderDetailField;
        }
        set {
            this.orderDetailField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class OrderDetail {
    
    private string lineNumberField;
    
    private string customerLineNumberField;
    
    private string parentLineNumberField;
    
    private string productCodeField;
    
    private string upcCodeField;
    
    private string productDescriptionField;
    
    private string sizeField;
    
    private string styleField;
    
    private string colorField;
    
    private string category1Field;
    
    private string category2Field;
    
    private string category3Field;
    
    private string category4Field;
    
    private string ageCodeField;
    
    private string seasonCodeField;
    
    private string packingQuantityField;
    
    private string quantityOrderedField;
    
    private string quantityShippedField;
    
    private string quantityBackOrderedField;
    
    private string originalQuantityOrderedField;
    
    private string originalQuantityBackOrderedField;
    
    private string unitOfMeasureField;
    
    private string serialNumberField;
    
    private string lotNumberField;
    
    private string expiryDateField;
    
    private string unitPriceExTaxField;
    
    private string unitPriceIncTaxField;
    
    private string taxAmountField;
    
    private string gstField;
    
    private string extendedExTaxField;
    
    private string extendedIncTaxField;
    
    private string miscellaneousCharge1Field;
    
    private string miscellaneousCharge2Field;
    
    private string discountField;
    
    private string lineTotalExcTaxField;
    
    private string lineTotalIncTaxField;
    
    private string recommendedRetailPriceField;
    
    private string weightField;
    
    private string volumeField;
    
    private string userDefinedField1Field;
    
    private string userDefinedField2Field;
    
    private string userDefinedField3Field;
    
    private string userDefinedField4Field;
    
    private string userDefinedField5Field;
    
    private string userDefinedField6Field;
    
    private string userDefinedField7Field;
    
    private string userDefinedField8Field;
    
    private string userDefinedField9Field;
    
    private string userDefinedField10Field;
    
    private string nonStockItemField;
    
    private string holdCodeField;
    
    private string kitFlagField;
    
    private CustomerProductCode[] customerProductCodeField;
    
    private OrderLotSerial[] orderLotSerialField;
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string lineNumber {
        get {
            return this.lineNumberField;
        }
        set {
            this.lineNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string customerLineNumber {
        get {
            return this.customerLineNumberField;
        }
        set {
            this.customerLineNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string parentLineNumber {
        get {
            return this.parentLineNumberField;
        }
        set {
            this.parentLineNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string productCode {
        get {
            return this.productCodeField;
        }
        set {
            this.productCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string upcCode {
        get {
            return this.upcCodeField;
        }
        set {
            this.upcCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string productDescription {
        get {
            return this.productDescriptionField;
        }
        set {
            this.productDescriptionField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string size {
        get {
            return this.sizeField;
        }
        set {
            this.sizeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string style {
        get {
            return this.styleField;
        }
        set {
            this.styleField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string color {
        get {
            return this.colorField;
        }
        set {
            this.colorField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string category1 {
        get {
            return this.category1Field;
        }
        set {
            this.category1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string category2 {
        get {
            return this.category2Field;
        }
        set {
            this.category2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string category3 {
        get {
            return this.category3Field;
        }
        set {
            this.category3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string category4 {
        get {
            return this.category4Field;
        }
        set {
            this.category4Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string ageCode {
        get {
            return this.ageCodeField;
        }
        set {
            this.ageCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string seasonCode {
        get {
            return this.seasonCodeField;
        }
        set {
            this.seasonCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string packingQuantity {
        get {
            return this.packingQuantityField;
        }
        set {
            this.packingQuantityField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantityOrdered {
        get {
            return this.quantityOrderedField;
        }
        set {
            this.quantityOrderedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantityShipped {
        get {
            return this.quantityShippedField;
        }
        set {
            this.quantityShippedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantityBackOrdered {
        get {
            return this.quantityBackOrderedField;
        }
        set {
            this.quantityBackOrderedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string originalQuantityOrdered {
        get {
            return this.originalQuantityOrderedField;
        }
        set {
            this.originalQuantityOrderedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string originalQuantityBackOrdered {
        get {
            return this.originalQuantityBackOrderedField;
        }
        set {
            this.originalQuantityBackOrderedField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unitOfMeasure {
        get {
            return this.unitOfMeasureField;
        }
        set {
            this.unitOfMeasureField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string serialNumber {
        get {
            return this.serialNumberField;
        }
        set {
            this.serialNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string lotNumber {
        get {
            return this.lotNumberField;
        }
        set {
            this.lotNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string expiryDate {
        get {
            return this.expiryDateField;
        }
        set {
            this.expiryDateField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unitPriceExTax {
        get {
            return this.unitPriceExTaxField;
        }
        set {
            this.unitPriceExTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string unitPriceIncTax {
        get {
            return this.unitPriceIncTaxField;
        }
        set {
            this.unitPriceIncTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string taxAmount {
        get {
            return this.taxAmountField;
        }
        set {
            this.taxAmountField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string gst {
        get {
            return this.gstField;
        }
        set {
            this.gstField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string extendedExTax {
        get {
            return this.extendedExTaxField;
        }
        set {
            this.extendedExTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string extendedIncTax {
        get {
            return this.extendedIncTaxField;
        }
        set {
            this.extendedIncTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string miscellaneousCharge1 {
        get {
            return this.miscellaneousCharge1Field;
        }
        set {
            this.miscellaneousCharge1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string miscellaneousCharge2 {
        get {
            return this.miscellaneousCharge2Field;
        }
        set {
            this.miscellaneousCharge2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string discount {
        get {
            return this.discountField;
        }
        set {
            this.discountField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string lineTotalExcTax {
        get {
            return this.lineTotalExcTaxField;
        }
        set {
            this.lineTotalExcTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string lineTotalIncTax {
        get {
            return this.lineTotalIncTaxField;
        }
        set {
            this.lineTotalIncTaxField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string recommendedRetailPrice {
        get {
            return this.recommendedRetailPriceField;
        }
        set {
            this.recommendedRetailPriceField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string weight {
        get {
            return this.weightField;
        }
        set {
            this.weightField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string volume {
        get {
            return this.volumeField;
        }
        set {
            this.volumeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField1 {
        get {
            return this.userDefinedField1Field;
        }
        set {
            this.userDefinedField1Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField2 {
        get {
            return this.userDefinedField2Field;
        }
        set {
            this.userDefinedField2Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField3 {
        get {
            return this.userDefinedField3Field;
        }
        set {
            this.userDefinedField3Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField4 {
        get {
            return this.userDefinedField4Field;
        }
        set {
            this.userDefinedField4Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField5 {
        get {
            return this.userDefinedField5Field;
        }
        set {
            this.userDefinedField5Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField6 {
        get {
            return this.userDefinedField6Field;
        }
        set {
            this.userDefinedField6Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField7 {
        get {
            return this.userDefinedField7Field;
        }
        set {
            this.userDefinedField7Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField8 {
        get {
            return this.userDefinedField8Field;
        }
        set {
            this.userDefinedField8Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField9 {
        get {
            return this.userDefinedField9Field;
        }
        set {
            this.userDefinedField9Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string userDefinedField10 {
        get {
            return this.userDefinedField10Field;
        }
        set {
            this.userDefinedField10Field = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string nonStockItem {
        get {
            return this.nonStockItemField;
        }
        set {
            this.nonStockItemField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string holdCode {
        get {
            return this.holdCodeField;
        }
        set {
            this.holdCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string kitFlag {
        get {
            return this.kitFlagField;
        }
        set {
            this.kitFlagField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute("customerProductCode", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public CustomerProductCode[] customerProductCode {
        get {
            return this.customerProductCodeField;
        }
        set {
            this.customerProductCodeField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute("OrderLotSerial", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public OrderLotSerial[] OrderLotSerial {
        get {
            return this.orderLotSerialField;
        }
        set {
            this.orderLotSerialField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class CustomerProductCode {
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.7.2558.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class OrderLotSerial {
    
    private string lotSerialNumberField;
    
    private string quantityOrderedField;
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string lotSerialNumber {
        get {
            return this.lotSerialNumberField;
        }
        set {
            this.lotSerialNumberField = value;
        }
    }
    
    /// <remarks/>
    [XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string quantityOrdered {
        get {
            return this.quantityOrderedField;
        }
        set {
            this.quantityOrderedField = value;
        }
    }
}
