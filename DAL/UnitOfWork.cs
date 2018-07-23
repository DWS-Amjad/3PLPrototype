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
        #endregion

        #region public members
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

            public void Save()
            {
                context.SaveChanges();
            }
        #endregion

        private bool disposed = false;

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
