using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById->ErrorInboundDataRepository
    public sealed class ErrorInboundDataRepository : IDisposable
    {
        public ErrorInboundDataRepository(STEInterfacesEntities context)
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

        public ErrorInboundData SelectById(Guid Id)
        {
            ErrorInboundData retVal = null;
            try
            {
                retVal = this.db.ErrorInboundDatas.FirstOrDefault(eid => eid.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ErrorInboundData> SelectAll()
        {
            List<ErrorInboundData> retVal = null;
            try
            {
                retVal = this.db.ErrorInboundDatas.ToList<ErrorInboundData>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ErrorInboundData obj)
        {
            try
            {
                db.AddToErrorInboundDatas(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ErrorInboundData obj)
        {
            try
            {
                ErrorInboundData aemObject = this.db.ErrorInboundDatas.FirstOrDefault(aem => aem.Id == obj.Id);
                aemObject = obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public void Delete(Guid Id)
        //{
        //    try
        //    {
        //        ErrorInboundData aemObject = this.db.ErrorInboundDatas.FirstOrDefault(aem => aem.Id == Id);
        //        aemObject.IsActive = false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
