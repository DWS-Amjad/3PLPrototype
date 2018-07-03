using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById
    public sealed class ApplicationLogRepository : IDisposable
    {
        public ApplicationLogRepository(STEInterfacesEntities context)
        {
            try
            {
                this.db = context;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private STEInterfacesEntities db = null;

        public ApplicationLog SelectById(Guid Id)
        {
            ApplicationLog retVal = null;
            try
            {
                retVal = this.db.ApplicationLogs.FirstOrDefault(al => al.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ApplicationLog> SelectAll()
        {
            List<ApplicationLog> retVal = null;
            try
            {
                retVal = this.db.ApplicationLogs.ToList<ApplicationLog>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ApplicationLog obj)
        {
            try
            {
                db.AddToApplicationLogs(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ApplicationLog obj)
        {
            try
            {
                ApplicationLog aemObject = this.db.ApplicationLogs.FirstOrDefault(aem => aem.Id == obj.Id);
                aemObject = obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }
    }

}
