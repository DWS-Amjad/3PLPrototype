using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById

    public sealed class ApplicationMasterRepository : IDisposable
    {
        public ApplicationMasterRepository(STEInterfacesEntities context)
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

        public ApplicationMaster SelectById(int Id)
        {
            ApplicationMaster retVal = null;
            try
            {
                retVal = this.db.ApplicationMasters.FirstOrDefault(aem => aem.Id == Id && aem.IsActive);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ApplicationMaster> SelectAll()
        {
            List<ApplicationMaster> retVal = null;
            try
            {
                retVal = this.db.ApplicationMasters.Where<ApplicationMaster>(aem => aem.IsActive).ToList<ApplicationMaster>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ApplicationMaster obj)
        {
            try
            {
                db.AddToApplicationMasters(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ApplicationMaster obj)
        {
            try
            {
                ApplicationMaster aemObject = this.db.ApplicationMasters.FirstOrDefault(aem => aem.Id == obj.Id && aem.IsActive);
                aemObject = obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                ApplicationMaster aemObject = this.db.ApplicationMasters.FirstOrDefault(aem => aem.Id == Id && aem.IsActive);
                aemObject.IsActive = false;
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
