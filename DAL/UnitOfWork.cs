using DAL.Models;
using DAL.Repository;
using System;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        #region private Members

            private STEInterfacesEntities context = new STEInterfacesEntities();
            private IGenericRepository<ApplicationLog> repoAppLog;
            private IGenericRepository<ApplicationEventMaster> repoEventMaster;
            private IGenericRepository<ApplicationMaster> repoApplicationMaster;
            private IGenericRepository<ErrorInboundData> repoErrInbound;
            private IGenericRepository<ErrorXml> repoErrorXml;
            private IGenericRepository<ErrorSuggestion> repoErrSuggestion;
            private IGenericRepository<Error_Suggestion_InboundData_Mapper> repoErrSuggestionInboundData_Map;
            private LocationCustomRepository repoLocation;

        #endregion

        #region public members

        /// <summary>
        /// 
        /// </summary>
            public LocationCustomRepository LocationRepository
            {
                get
                {
                    if (this.repoLocation == null)
                    {
                        this.repoLocation = new LocationCustomRepository(this.context);
                    }
                    return this.repoLocation;
                }
            }

        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ApplicationLog> ApplicationLogRepository
                {
                    get
                    {
                        if (this.repoAppLog == null)
                        {
                            this.repoAppLog = new GenericRepository<ApplicationLog>(this.context);
                        }
                        return this.repoAppLog;
                    }
                }
    
        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ApplicationEventMaster> ApplicationEventMasterRepository
            {
                get
                {
                    if (this.repoEventMaster == null)
                    {
                        this.repoEventMaster = new GenericRepository<ApplicationEventMaster>(this.context);
                    }
                    return this.repoEventMaster;
                }
            }
        
        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ApplicationMaster> ApplicationMasterRepository
            {
                get
                {
                    if (this.repoApplicationMaster == null)
                    {
                        this.repoApplicationMaster = new GenericRepository<ApplicationMaster>(this.context);
                    }
                    return this.repoApplicationMaster;
                }
            }

        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ErrorInboundData> ErrorInboundRepository
            {
                get
                {
                    if (this.repoErrInbound == null)
                    {
                        this.repoErrInbound = new GenericRepository<ErrorInboundData>(this.context);
                    }
                    return this.repoErrInbound;
                }
            }

        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ErrorXml> ErrorXmlRepository
            {
                get
                {
                    if (this.repoErrorXml == null)
                    {
                        this.repoErrorXml = new GenericRepository<ErrorXml>(this.context);
                    }
                    return this.repoErrorXml;
                }
            }

        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<ErrorSuggestion> ErrorSuggestionRepository
            {
                get
                {
                    if (this.repoErrSuggestion == null)
                    {
                        this.repoErrSuggestion = new GenericRepository<ErrorSuggestion>(this.context);
                    }
                    return this.repoErrSuggestion;
                }
            }

        /// <summary>
        /// 
        /// </summary>
            public IGenericRepository<Error_Suggestion_InboundData_Mapper> ErrorSuggestion_InboundDataRepository
            {
                get
                {
                    if (this.repoErrSuggestionInboundData_Map == null)
                    {
                        this.repoErrSuggestionInboundData_Map = new GenericRepository<Error_Suggestion_InboundData_Mapper>(this.context);
                    }
                    return this.repoErrSuggestionInboundData_Map;
                }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Event"></param>
        /// <param name="Application"></param>
        /// <param name="message"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
            public ApplicationLog CreateApplicationLogObject(ApplicationEventMaster Event, ApplicationMaster Application,
                    string message, string userId)
            {
                ApplicationLog obj = new ApplicationLog();
                obj.Id = Guid.NewGuid();
                obj.ApplicationEventMaster = Event;
                obj.ApplicationMaster = Application;
                obj.Message = message;
                obj.TimeStamp = DateTime.Now;
                obj.UserId = userId;
                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="createdBy"></param>
        /// <param name="LastUpdatedBy"></param>
        /// <returns></returns>
            public ApplicationEventMaster CreateApplicationEventMaster(string eventName,
                string createdBy, string LastUpdatedBy)
            {
                ApplicationEventMaster obj = new ApplicationEventMaster();
                obj.EventName = eventName;
                obj.CreatedBy = createdBy;
                obj.CreatedDate = DateTime.Now;
                obj.LastUpdatedBy = LastUpdatedBy;
                obj.LastUpdatedDate = DateTime.Now;
                obj.IsActive = true;
                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="configFilePath"></param>
        /// <param name="createdBy"></param>
        /// <param name="LastUpdatedBy"></param>
        /// <returns></returns>
            public ApplicationMaster CreateApplicationMaster(string Name, string configFilePath,
                string createdBy, string LastUpdatedBy)
            {
                ApplicationMaster obj = new ApplicationMaster();
                obj.Name = Name;
                obj.ConfigFilePath = configFilePath;
                obj.CreatedBy = createdBy;
                obj.CreatedDate = DateTime.Now;
                obj.LastUpdatedBy = LastUpdatedBy;
                obj.LastUpdatedDate = DateTime.Now;
                obj.IsActive = true;
                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataKey"></param>
        /// <param name="dataPath"></param>
        /// <param name="dataType"></param>
        /// <param name="dataValue"></param>
        /// <param name="errorType"></param>
        /// <param name="sysErrorMsg"></param>
        /// <param name="customErrorMsg"></param>
        /// <param name="errorXml"></param>
        /// <param name="isRectifiable"></param>
        /// <returns></returns>
            public ErrorInboundData CreateErrorInboundData(string dataKey, string dataPath,
                string dataType, string dataValue, string errorType, string sysErrorMsg,
                string customErrorMsg, ErrorXml errorXml, Boolean isRectifiable)
            {
                ErrorInboundData obj = new ErrorInboundData();
                obj.Id = Guid.NewGuid();
                obj.DataKey = dataKey;
                obj.DataPath = dataPath;
                obj.DataType = dataType;
                obj.DataValue = dataValue;
                obj.ErrorType = errorType;
                obj.SysErrorMsg = sysErrorMsg;
                obj.CustomErrorMsg = customErrorMsg;
                obj.ErrorXml = errorXml;
                obj.IsRectifiable = isRectifiable;
                obj.TimeStamp = DateTime.Now;
                return (obj);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientCode"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="docUniqueId"></param>
        /// <param name="docType"></param>
        /// <param name="orderDate"></param>
        /// <param name="TimeStamp"></param>
        /// <param name="XmlContent"></param>
        /// <returns></returns>
            public ErrorXml CreateErrorXml(string clientCode, string warehouseCode,
                string docUniqueId, string docType, DateTime orderDate, DateTime TimeStamp,
                string XmlContent)
            {
                ErrorXml obj = new ErrorXml();
                obj.Id = Guid.NewGuid();
                obj.Client_Code = clientCode;
                obj.Warehouse_Code = warehouseCode;
                obj.DocumentUniqueId = docUniqueId;
                obj.DocumentType = docType;
                obj.OrderDate = orderDate;
                obj.TimeStamp = TimeStamp;
                obj.XmlContent = XmlContent;
                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Suggestion"></param>
        /// <param name="createdBy"></param>
        /// <param name="lastUpdatedBy"></param>
        /// <returns></returns>
            public ErrorSuggestion CreateErrorSuggestion(string Suggestion, string createdBy,
                string lastUpdatedBy)
            {
                ErrorSuggestion obj = new ErrorSuggestion();
                obj.Id = Guid.NewGuid();
                obj.Suggestion = Suggestion;
                obj.CreatedBy = createdBy;
                obj.CreatedDate = DateTime.Now;
                obj.LastUpdatedBy = lastUpdatedBy;
                obj.LastUpdatedDate = DateTime.Now;
                obj.IsActive = true;
                return obj;
            }

        /// <summary>
        /// 
        /// </summary>
            public void Save()
            {
                context.SaveChanges();
            }
        
        #endregion

        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
}
            this.disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
