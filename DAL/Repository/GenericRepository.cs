using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private STEInterfacesEntities db = null;
        private DbSet<T> table = null;

        /// <summary>
        /// 
        /// </summary>
        public GenericRepository()
        {
            try
            {
                this.db = new STEInterfacesEntities();
                table = db.Set<T>();
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public GenericRepository(STEInterfacesEntities db)
        {
            try
            {
                this.db = db;
                table = db.Set<T>();
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }
        
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T SelectByID(object id)
        {
            return table.Find(id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(int id, T obj)
        {
            try
            {
                table.Attach(obj);
                db.Entry(obj).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                if (!Exists(id))
                {
                    return false;
                }
                else
                {
                    Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(dbEx));
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        //public void Save()
        //{
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
        //        throw ex;
        //    }

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(object id)
        {
            return (table.Find(id) != null);
            //return table.Count(e => e.PID == id) > 0;
        }
    }
}
