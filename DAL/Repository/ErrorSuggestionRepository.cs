using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    //CRUD
    // SelectAll; SelectAllActive; Insert, Update, Delete, SelectById =>ErrorSuggestionRepository
    public sealed class ErrorSuggestionRepository : IDisposable
    {
        public ErrorSuggestionRepository(STEInterfacesEntities context)
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

        public ErrorSuggestion SelectById(Guid Id)
        {
            ErrorSuggestion retVal = null;
            try
            {
                retVal = this.db.ErrorSuggestions.FirstOrDefault(es => es.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<ErrorSuggestion> SelectAll()
        {
            List<ErrorSuggestion> retVal = null;
            try
            {
                retVal = this.db.ErrorSuggestions.ToList<ErrorSuggestion>();
                //retVal = this.db.ApplicationEventMasters.ToList<ApplicationEventMaster>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(ErrorSuggestion obj)
        {
            try
            {
                db.ErrorSuggestions.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ErrorSuggestion obj)
        {
            try
            {
                ErrorSuggestion aemObject = this.db.ErrorSuggestions.FirstOrDefault(es => es.Id == obj.Id);
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
