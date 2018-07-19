using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById
    public sealed class ApplicationEventMasterRepository : IDisposable
    {
        public ApplicationEventMasterRepository(STEInterfacesEntities context)
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

        public ApplicationEventMaster SelectById(int Id)
        {
            ApplicationEventMaster retVal = null;
            try
            {
                retVal = this.db.ApplicationEventMasters.FirstOrDefault(aem => aem.Id == Id && aem.IsActive);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ApplicationEventMaster> SelectAll()
        {
            List<ApplicationEventMaster> retVal = null;
            try
            {
                retVal = this.db.ApplicationEventMasters.Where<ApplicationEventMaster>(aem => aem.IsActive).ToList<ApplicationEventMaster>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ApplicationEventMaster obj)
        {
            try
            {
                db.ApplicationEventMasters.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ApplicationEventMaster obj)
        {
            try
            {
                ApplicationEventMaster aemObject = this.db.ApplicationEventMasters.FirstOrDefault(aem => aem.Id == obj.Id && aem.IsActive);
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
                ApplicationEventMaster aemObject = this.db.ApplicationEventMasters.FirstOrDefault(aem => aem.Id == Id);
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
