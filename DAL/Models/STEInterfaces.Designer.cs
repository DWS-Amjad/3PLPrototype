using System.Xml.Serialization;

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DAL.Models.ApplicationEventMaster), "ApplicationLog", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DAL.Models.ApplicationLog))]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationMaster", "ApplicationMaster", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DAL.Models.ApplicationMaster), "ApplicationLog", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DAL.Models.ApplicationLog))]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("STEInterfacesModel", "FK_ErrorInboundData_ErrorXml", "ErrorXml", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DAL.Models.ErrorXml), "ErrorInboundData", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DAL.Models.ErrorInboundData))]
[assembly: global::System.Data.Objects.DataClasses.EdmRelationshipAttribute("STEInterfacesModel", "FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData", global::System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DAL.Models.ErrorInboundData), "ErrorSuggestion", global::System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DAL.Models.ErrorSuggestion))]



namespace DAL.Models
{
    
    /// <summary>
    /// There are no comments for STEInterfacesModel.ApplicationEventMaster in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ApplicationEventMaster")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ApplicationEventMaster : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ApplicationEventMaster object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="eventName">Initial value of EventName.</param>
        /// <param name="createdBy">Initial value of CreatedBy.</param>
        /// <param name="createdDate">Initial value of CreatedDate.</param>
        /// <param name="lastUpdatedBy">Initial value of LastUpdatedBy.</param>
        /// <param name="lastUpdatedDate">Initial value of LastUpdatedDate.</param>
        /// <param name="isActive">Initial value of IsActive.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ApplicationEventMaster CreateApplicationEventMaster(int id, string eventName, string createdBy, global::System.DateTime createdDate, string lastUpdatedBy, global::System.DateTime lastUpdatedDate, bool isActive)
        {
            ApplicationEventMaster applicationEventMaster = new ApplicationEventMaster();
            applicationEventMaster.Id = id;
            applicationEventMaster.EventName = eventName;
            applicationEventMaster.CreatedBy = createdBy;
            applicationEventMaster.CreatedDate = createdDate;
            applicationEventMaster.LastUpdatedBy = lastUpdatedBy;
            applicationEventMaster.LastUpdatedDate = lastUpdatedDate;
            applicationEventMaster.IsActive = isActive;
            return applicationEventMaster;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property EventName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string EventName
        {
            get
            {
                return this._EventName;
            }
            set
            {
                this.OnEventNameChanging(value);
                this.ReportPropertyChanging("EventName");
                this._EventName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("EventName");
                this.OnEventNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _EventName;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnEventNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnEventNameChanged();
        /// <summary>
        /// There are no comments for property CreatedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this.OnCreatedByChanging(value);
                this.ReportPropertyChanging("CreatedBy");
                this._CreatedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("CreatedBy");
                this.OnCreatedByChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CreatedBy;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedByChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedByChanged();
        /// <summary>
        /// There are no comments for property CreatedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnCreatedDateChanging(value);
                this.ReportPropertyChanging("CreatedDate");
                this._CreatedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CreatedDate");
                this.OnCreatedDateChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _CreatedDate;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedDateChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedDateChanged();
        /// <summary>
        /// There are no comments for property LastUpdatedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string LastUpdatedBy
        {
            get
            {
                return this._LastUpdatedBy;
            }
            set
            {
                this.OnLastUpdatedByChanging(value);
                this.ReportPropertyChanging("LastUpdatedBy");
                this._LastUpdatedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("LastUpdatedBy");
                this.OnLastUpdatedByChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _LastUpdatedBy;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedByChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedByChanged();
        /// <summary>
        /// There are no comments for property LastUpdatedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime LastUpdatedDate
        {
            get
            {
                return this._LastUpdatedDate;
            }
            set
            {
                this.OnLastUpdatedDateChanging(value);
                this.ReportPropertyChanging("LastUpdatedDate");
                this._LastUpdatedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("LastUpdatedDate");
                this.OnLastUpdatedDateChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _LastUpdatedDate;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedDateChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedDateChanged();
        /// <summary>
        /// There are no comments for property IsActive in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this.OnIsActiveChanging(value);
                this.ReportPropertyChanging("IsActive");
                this._IsActive = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IsActive");
                this.OnIsActiveChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _IsActive;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsActiveChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsActiveChanged();
        /// <summary>
        /// There are no comments for ApplicationLogs in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationEventMaster", "ApplicationLog")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<ApplicationLog> ApplicationLogs
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<ApplicationLog>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationLog");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<ApplicationLog>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationLog", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesModel.ApplicationLog in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ApplicationLog")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ApplicationLog : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ApplicationLog object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="userId">Initial value of UserId.</param>
        /// <param name="message">Initial value of Message.</param>
        /// <param name="timeStamp">Initial value of TimeStamp.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ApplicationLog CreateApplicationLog(global::System.Guid id, string userId, string message, global::System.DateTime timeStamp)
        {
            ApplicationLog applicationLog = new ApplicationLog();
            applicationLog.Id = id;
            applicationLog.UserId = userId;
            applicationLog.Message = message;
            applicationLog.TimeStamp = timeStamp;
            return applicationLog;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Guid Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Guid _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(global::System.Guid value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property UserId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this.OnUserIdChanging(value);
                this.ReportPropertyChanging("UserId");
                this._UserId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("UserId");
                this.OnUserIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _UserId;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnUserIdChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnUserIdChanged();
        /// <summary>
        /// There are no comments for property Message in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this.OnMessageChanging(value);
                this.ReportPropertyChanging("Message");
                this._Message = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Message");
                this.OnMessageChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Message;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMessageChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnMessageChanged();
        /// <summary>
        /// There are no comments for property TimeStamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime TimeStamp
        {
            get
            {
                return this._TimeStamp;
            }
            set
            {
                this.OnTimeStampChanging(value);
                this.ReportPropertyChanging("TimeStamp");
                this._TimeStamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TimeStamp");
                this.OnTimeStampChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _TimeStamp;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanged();
        /// <summary>
        /// There are no comments for ApplicationEventMaster in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public ApplicationEventMaster ApplicationEventMaster
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationEventMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationEventMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for ApplicationEventMaster in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<ApplicationEventMaster> ApplicationEventMasterReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationEventMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<ApplicationEventMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationEventMaster", "ApplicationEventMaster", value);
                }
            }
        }
        /// <summary>
        /// There are no comments for ApplicationMaster in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationMaster", "ApplicationMaster")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public ApplicationMaster ApplicationMaster
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationMaster").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationMaster").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for ApplicationMaster in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<ApplicationMaster> ApplicationMasterReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ApplicationMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationMaster");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<ApplicationMaster>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationMaster", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesModel.ApplicationMaster in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ApplicationMaster")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ApplicationMaster : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ApplicationMaster object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="name">Initial value of Name.</param>
        /// <param name="createdBy">Initial value of CreatedBy.</param>
        /// <param name="createdDate">Initial value of CreatedDate.</param>
        /// <param name="lastUpdatedBy">Initial value of LastUpdatedBy.</param>
        /// <param name="lastUpdatedDate">Initial value of LastUpdatedDate.</param>
        /// <param name="isActive">Initial value of IsActive.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ApplicationMaster CreateApplicationMaster(int id, string name, string createdBy, global::System.DateTime createdDate, string lastUpdatedBy, global::System.DateTime lastUpdatedDate, bool isActive)
        {
            ApplicationMaster applicationMaster = new ApplicationMaster();
            applicationMaster.Id = id;
            applicationMaster.Name = name;
            applicationMaster.CreatedBy = createdBy;
            applicationMaster.CreatedDate = createdDate;
            applicationMaster.LastUpdatedBy = lastUpdatedBy;
            applicationMaster.LastUpdatedDate = lastUpdatedDate;
            applicationMaster.IsActive = isActive;
            return applicationMaster;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private int _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(int value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this.ReportPropertyChanging("Name");
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Name;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for property CreatedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this.OnCreatedByChanging(value);
                this.ReportPropertyChanging("CreatedBy");
                this._CreatedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("CreatedBy");
                this.OnCreatedByChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CreatedBy;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedByChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedByChanged();
        /// <summary>
        /// There are no comments for property CreatedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnCreatedDateChanging(value);
                this.ReportPropertyChanging("CreatedDate");
                this._CreatedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CreatedDate");
                this.OnCreatedDateChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _CreatedDate;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedDateChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCreatedDateChanged();
        /// <summary>
        /// There are no comments for property LastUpdatedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string LastUpdatedBy
        {
            get
            {
                return this._LastUpdatedBy;
            }
            set
            {
                this.OnLastUpdatedByChanging(value);
                this.ReportPropertyChanging("LastUpdatedBy");
                this._LastUpdatedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("LastUpdatedBy");
                this.OnLastUpdatedByChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _LastUpdatedBy;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedByChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedByChanged();
        /// <summary>
        /// There are no comments for property LastUpdatedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime LastUpdatedDate
        {
            get
            {
                return this._LastUpdatedDate;
            }
            set
            {
                this.OnLastUpdatedDateChanging(value);
                this.ReportPropertyChanging("LastUpdatedDate");
                this._LastUpdatedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("LastUpdatedDate");
                this.OnLastUpdatedDateChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _LastUpdatedDate;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedDateChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnLastUpdatedDateChanged();
        /// <summary>
        /// There are no comments for property IsActive in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this.OnIsActiveChanging(value);
                this.ReportPropertyChanging("IsActive");
                this._IsActive = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IsActive");
                this.OnIsActiveChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _IsActive;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsActiveChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsActiveChanged();
        /// <summary>
        /// There are no comments for ApplicationLogs in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ApplicationLog_ApplicationMaster", "ApplicationLog")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<ApplicationLog> ApplicationLogs
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<ApplicationLog>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationLog");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<ApplicationLog>("STEInterfacesModel.FK_ApplicationLog_ApplicationMaster", "ApplicationLog", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesModel.ErrorInboundData in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ErrorInboundData")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ErrorInboundData : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ErrorInboundData object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="errorType">Initial value of ErrorType.</param>
        /// <param name="dataType">Initial value of DataType.</param>
        /// <param name="dataKey">Initial value of DataKey.</param>
        /// <param name="dataValue">Initial value of DataValue.</param>
        /// <param name="dataPath">Initial value of DataPath.</param>
        /// <param name="sysErrorMsg">Initial value of SysErrorMsg.</param>
        /// <param name="customErrorMsg">Initial value of CustomErrorMsg.</param>
        /// <param name="isRectifiable">Initial value of IsRectifiable.</param>
        /// <param name="timeStamp">Initial value of TimeStamp.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ErrorInboundData CreateErrorInboundData(global::System.Guid id, string errorType, string dataType, string dataKey, string dataValue, string dataPath, string sysErrorMsg, string customErrorMsg, bool isRectifiable, global::System.DateTime timeStamp)
        {
            ErrorInboundData errorInboundData = new ErrorInboundData();
            errorInboundData.Id = id;
            errorInboundData.ErrorType = errorType;
            errorInboundData.DataType = dataType;
            errorInboundData.DataKey = dataKey;
            errorInboundData.DataValue = dataValue;
            errorInboundData.DataPath = dataPath;
            errorInboundData.SysErrorMsg = sysErrorMsg;
            errorInboundData.CustomErrorMsg = customErrorMsg;
            errorInboundData.IsRectifiable = isRectifiable;
            errorInboundData.TimeStamp = timeStamp;
            return errorInboundData;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Guid Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Guid _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(global::System.Guid value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property ErrorType in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string ErrorType
        {
            get
            {
                return this._ErrorType;
            }
            set
            {
                this.OnErrorTypeChanging(value);
                this.ReportPropertyChanging("ErrorType");
                this._ErrorType = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("ErrorType");
                this.OnErrorTypeChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _ErrorType;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnErrorTypeChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnErrorTypeChanged();
        /// <summary>
        /// There are no comments for property DataType in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string DataType
        {
            get
            {
                return this._DataType;
            }
            set
            {
                this.OnDataTypeChanging(value);
                this.ReportPropertyChanging("DataType");
                this._DataType = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DataType");
                this.OnDataTypeChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DataType;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataTypeChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataTypeChanged();
        /// <summary>
        /// There are no comments for property DataKey in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string DataKey
        {
            get
            {
                return this._DataKey;
            }
            set
            {
                this.OnDataKeyChanging(value);
                this.ReportPropertyChanging("DataKey");
                this._DataKey = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DataKey");
                this.OnDataKeyChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DataKey;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataKeyChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataKeyChanged();
        /// <summary>
        /// There are no comments for property DataValue in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string DataValue
        {
            get
            {
                return this._DataValue;
            }
            set
            {
                this.OnDataValueChanging(value);
                this.ReportPropertyChanging("DataValue");
                this._DataValue = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DataValue");
                this.OnDataValueChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DataValue;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataValueChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataValueChanged();
        /// <summary>
        /// There are no comments for property DataPath in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string DataPath
        {
            get
            {
                return this._DataPath;
            }
            set
            {
                this.OnDataPathChanging(value);
                this.ReportPropertyChanging("DataPath");
                this._DataPath = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DataPath");
                this.OnDataPathChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DataPath;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataPathChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDataPathChanged();
        /// <summary>
        /// There are no comments for property SysErrorMsg in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string SysErrorMsg
        {
            get
            {
                return this._SysErrorMsg;
            }
            set
            {
                this.OnSysErrorMsgChanging(value);
                this.ReportPropertyChanging("SysErrorMsg");
                this._SysErrorMsg = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("SysErrorMsg");
                this.OnSysErrorMsgChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _SysErrorMsg;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSysErrorMsgChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSysErrorMsgChanged();
        /// <summary>
        /// There are no comments for property CustomErrorMsg in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string CustomErrorMsg
        {
            get
            {
                return this._CustomErrorMsg;
            }
            set
            {
                this.OnCustomErrorMsgChanging(value);
                this.ReportPropertyChanging("CustomErrorMsg");
                this._CustomErrorMsg = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("CustomErrorMsg");
                this.OnCustomErrorMsgChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _CustomErrorMsg;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCustomErrorMsgChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnCustomErrorMsgChanged();
        /// <summary>
        /// There are no comments for property IsRectifiable in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public bool IsRectifiable
        {
            get
            {
                return this._IsRectifiable;
            }
            set
            {
                this.OnIsRectifiableChanging(value);
                this.ReportPropertyChanging("IsRectifiable");
                this._IsRectifiable = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("IsRectifiable");
                this.OnIsRectifiableChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private bool _IsRectifiable;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsRectifiableChanging(bool value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIsRectifiableChanged();
        /// <summary>
        /// There are no comments for property TimeStamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime TimeStamp
        {
            get
            {
                return this._TimeStamp;
            }
            set
            {
                this.OnTimeStampChanging(value);
                this.ReportPropertyChanging("TimeStamp");
                this._TimeStamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TimeStamp");
                this.OnTimeStampChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _TimeStamp;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanged();
        /// <summary>
        /// There are no comments for ErrorXml in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ErrorInboundData_ErrorXml", "ErrorXml")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public ErrorXml ErrorXml
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorXml>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorXml").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorXml>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorXml").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for ErrorXml in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<ErrorXml> ErrorXmlReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorXml>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorXml");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<ErrorXml>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorXml", value);
                }
            }
        }
        /// <summary>
        /// There are no comments for ErrorSuggestions in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ErrorSuggestion_ErrorInboundData", "ErrorSuggestion")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<ErrorSuggestion> ErrorSuggestions
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<ErrorSuggestion>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorSuggestion");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<ErrorSuggestion>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorSuggestion", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesModel.ErrorSuggestion in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ErrorSuggestion")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ErrorSuggestion : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ErrorSuggestion object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="suggestion">Initial value of Suggestion.</param>
        /// <param name="timeStamp">Initial value of TimeStamp.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ErrorSuggestion CreateErrorSuggestion(global::System.Guid id, string suggestion, global::System.DateTime timeStamp)
        {
            ErrorSuggestion errorSuggestion = new ErrorSuggestion();
            errorSuggestion.Id = id;
            errorSuggestion.Suggestion = suggestion;
            errorSuggestion.TimeStamp = timeStamp;
            return errorSuggestion;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Guid Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Guid _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(global::System.Guid value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property Suggestion in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Suggestion
        {
            get
            {
                return this._Suggestion;
            }
            set
            {
                this.OnSuggestionChanging(value);
                this.ReportPropertyChanging("Suggestion");
                this._Suggestion = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Suggestion");
                this.OnSuggestionChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Suggestion;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSuggestionChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnSuggestionChanged();
        /// <summary>
        /// There are no comments for property TimeStamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime TimeStamp
        {
            get
            {
                return this._TimeStamp;
            }
            set
            {
                this.OnTimeStampChanging(value);
                this.ReportPropertyChanging("TimeStamp");
                this._TimeStamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TimeStamp");
                this.OnTimeStampChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _TimeStamp;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanged();
        /// <summary>
        /// There are no comments for ErrorInboundData in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public ErrorInboundData ErrorInboundData
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorInboundData>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData").Value;
            }
            set
            {
                ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorInboundData>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData").Value = value;
            }
        }
        /// <summary>
        /// There are no comments for ErrorInboundData in the schema.
        /// </summary>
        [global::System.ComponentModel.BrowsableAttribute(false)]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityReference<ErrorInboundData> ErrorInboundDataReference
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedReference<ErrorInboundData>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedReference<ErrorInboundData>("STEInterfacesModel.FK_ErrorSuggestion_ErrorInboundData", "ErrorInboundData", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesModel.ErrorXml in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="STEInterfacesModel", Name="ErrorXml")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class ErrorXml : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new ErrorXml object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="client_Code">Initial value of Client_Code.</param>
        /// <param name="warehouse_Code">Initial value of Warehouse_Code.</param>
        /// <param name="xmlContent">Initial value of XmlContent.</param>
        /// <param name="documentUniqueId">Initial value of DocumentUniqueId.</param>
        /// <param name="timeStamp">Initial value of TimeStamp.</param>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public static ErrorXml CreateErrorXml(global::System.Guid id, string client_Code, string warehouse_Code, string xmlContent, string documentUniqueId, global::System.DateTime timeStamp)
        {
            ErrorXml errorXml = new ErrorXml();
            errorXml.Id = id;
            errorXml.Client_Code = client_Code;
            errorXml.Warehouse_Code = warehouse_Code;
            errorXml.XmlContent = xmlContent;
            errorXml.DocumentUniqueId = documentUniqueId;
            errorXml.TimeStamp = timeStamp;
            return errorXml;
        }
        /// <summary>
        /// There are no comments for property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Guid Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Guid _Id;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanging(global::System.Guid value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for property Client_Code in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Client_Code
        {
            get
            {
                return this._Client_Code;
            }
            set
            {
                this.OnClient_CodeChanging(value);
                this.ReportPropertyChanging("Client_Code");
                this._Client_Code = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Client_Code");
                this.OnClient_CodeChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Client_Code;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnClient_CodeChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnClient_CodeChanged();
        /// <summary>
        /// There are no comments for property Warehouse_Code in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string Warehouse_Code
        {
            get
            {
                return this._Warehouse_Code;
            }
            set
            {
                this.OnWarehouse_CodeChanging(value);
                this.ReportPropertyChanging("Warehouse_Code");
                this._Warehouse_Code = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Warehouse_Code");
                this.OnWarehouse_CodeChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _Warehouse_Code;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnWarehouse_CodeChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnWarehouse_CodeChanged();
        /// <summary>
        /// There are no comments for property XmlContent in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string XmlContent
        {
            get
            {
                return this._XmlContent;
            }
            set
            {
                this.OnXmlContentChanging(value);
                this.ReportPropertyChanging("XmlContent");
                this._XmlContent = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("XmlContent");
                this.OnXmlContentChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _XmlContent;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnXmlContentChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnXmlContentChanged();
        /// <summary>
        /// There are no comments for property DocumentUniqueId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public string DocumentUniqueId
        {
            get
            {
                return this._DocumentUniqueId;
            }
            set
            {
                this.OnDocumentUniqueIdChanging(value);
                this.ReportPropertyChanging("DocumentUniqueId");
                this._DocumentUniqueId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("DocumentUniqueId");
                this.OnDocumentUniqueIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private string _DocumentUniqueId;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDocumentUniqueIdChanging(string value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnDocumentUniqueIdChanged();
        /// <summary>
        /// There are no comments for property TimeStamp in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.DateTime TimeStamp
        {
            get
            {
                return this._TimeStamp;
            }
            set
            {
                this.OnTimeStampChanging(value);
                this.ReportPropertyChanging("TimeStamp");
                this._TimeStamp = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("TimeStamp");
                this.OnTimeStampChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.DateTime _TimeStamp;
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanging(global::System.DateTime value);
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        partial void OnTimeStampChanged();
        /// <summary>
        /// There are no comments for ErrorInboundDatas in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmRelationshipNavigationPropertyAttribute("STEInterfacesModel", "FK_ErrorInboundData_ErrorXml", "ErrorInboundData")]
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        [global::System.Xml.Serialization.XmlIgnoreAttribute()]
        [global::System.Xml.Serialization.SoapIgnoreAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Data.Objects.DataClasses.EntityCollection<ErrorInboundData> ErrorInboundDatas
        {
            get
            {
                return ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.GetRelatedCollection<ErrorInboundData>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorInboundData");
            }
            set
            {
                if ((value != null))
                {
                    ((global::System.Data.Objects.DataClasses.IEntityWithRelationships)(this)).RelationshipManager.InitializeRelatedCollection<ErrorInboundData>("STEInterfacesModel.FK_ErrorInboundData_ErrorXml", "ErrorInboundData", value);
                }
            }
        }
    }
    /// <summary>
    /// There are no comments for STEInterfacesEntities in the schema.
    /// </summary>
    public partial class STEInterfacesEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new STEInterfacesEntities object using the connection string found in the 'STEInterfacesEntities' section of the application configuration file.
        /// </summary>
        public STEInterfacesEntities() : 
                base("name=STEInterfacesEntities", "STEInterfacesEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new STEInterfacesEntities object.
        /// </summary>
        public STEInterfacesEntities(string connectionString) : 
                base(connectionString, "STEInterfacesEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new STEInterfacesEntities object.
        /// </summary>
        public STEInterfacesEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "STEInterfacesEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for ApplicationEventMasters in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ApplicationEventMaster> ApplicationEventMasters
        {
            get
            {
                if ((this._ApplicationEventMasters == null))
                {
                    this._ApplicationEventMasters = base.CreateQuery<ApplicationEventMaster>("[ApplicationEventMasters]");
                }
                return this._ApplicationEventMasters;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ApplicationEventMaster> _ApplicationEventMasters;
        /// <summary>
        /// There are no comments for ApplicationLogs in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ApplicationLog> ApplicationLogs
        {
            get
            {
                if ((this._ApplicationLogs == null))
                {
                    this._ApplicationLogs = base.CreateQuery<ApplicationLog>("[ApplicationLogs]");
                }
                return this._ApplicationLogs;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ApplicationLog> _ApplicationLogs;
        /// <summary>
        /// There are no comments for ApplicationMasters in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ApplicationMaster> ApplicationMasters
        {
            get
            {
                if ((this._ApplicationMasters == null))
                {
                    this._ApplicationMasters = base.CreateQuery<ApplicationMaster>("[ApplicationMasters]");
                }
                return this._ApplicationMasters;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ApplicationMaster> _ApplicationMasters;
        /// <summary>
        /// There are no comments for ErrorInboundDatas in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ErrorInboundData> ErrorInboundDatas
        {
            get
            {
                if ((this._ErrorInboundDatas == null))
                {
                    this._ErrorInboundDatas = base.CreateQuery<ErrorInboundData>("[ErrorInboundDatas]");
                }
                return this._ErrorInboundDatas;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ErrorInboundData> _ErrorInboundDatas;
        /// <summary>
        /// There are no comments for ErrorSuggestions in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ErrorSuggestion> ErrorSuggestions
        {
            get
            {
                if ((this._ErrorSuggestions == null))
                {
                    this._ErrorSuggestions = base.CreateQuery<ErrorSuggestion>("[ErrorSuggestions]");
                }
                return this._ErrorSuggestions;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ErrorSuggestion> _ErrorSuggestions;
        /// <summary>
        /// There are no comments for ErrorXmls in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public global::System.Data.Objects.ObjectQuery<ErrorXml> ErrorXmls
        {
            get
            {
                if ((this._ErrorXmls == null))
                {
                    this._ErrorXmls = base.CreateQuery<ErrorXml>("[ErrorXmls]");
                }
                return this._ErrorXmls;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        private global::System.Data.Objects.ObjectQuery<ErrorXml> _ErrorXmls;
        /// <summary>
        /// There are no comments for ApplicationEventMasters in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToApplicationEventMasters(ApplicationEventMaster applicationEventMaster)
        {
            base.AddObject("ApplicationEventMasters", applicationEventMaster);
        }
        /// <summary>
        /// There are no comments for ApplicationLogs in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToApplicationLogs(ApplicationLog applicationLog)
        {
            base.AddObject("ApplicationLogs", applicationLog);
        }
        /// <summary>
        /// There are no comments for ApplicationMasters in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToApplicationMasters(ApplicationMaster applicationMaster)
        {
            base.AddObject("ApplicationMasters", applicationMaster);
        }
        /// <summary>
        /// There are no comments for ErrorInboundDatas in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToErrorInboundDatas(ErrorInboundData errorInboundData)
        {
            base.AddObject("ErrorInboundDatas", errorInboundData);
        }
        /// <summary>
        /// There are no comments for ErrorSuggestions in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToErrorSuggestions(ErrorSuggestion errorSuggestion)
        {
            base.AddObject("ErrorSuggestions", errorSuggestion);
        }
        /// <summary>
        /// There are no comments for ErrorXmls in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("System.Data.Entity.Design.EntityClassGenerator", "4.0.0.0")]
        public void AddToErrorXmls(ErrorXml errorXml)
        {
            base.AddObject("ErrorXmls", errorXml);
        }
    }
}
