using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById  =>ErrorXmlRepository
    public sealed class ErrorXmlRepository : IDisposable
    {
        private ErrorXmlRepository(STEInterfacesEntities context)
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

        public ErrorXml SelectById(Guid Id)
        {
            ErrorXml retVal = null;
            try
            {
                retVal = this.db.ErrorXmls.FirstOrDefault(ex => ex.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ErrorXml> SelectAll()
        {
            List<ErrorXml> retVal = null;
            try
            {
                retVal = this.db.ErrorXmls.ToList<ErrorXml>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ErrorXml obj)
        {
            try
            {
                db.AddToErrorXmls(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ErrorXml obj)
        {
            try
            {
                ErrorXml exObject = this.db.ErrorXmls.FirstOrDefault(es => es.Id == obj.Id);
                exObject = obj;
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


