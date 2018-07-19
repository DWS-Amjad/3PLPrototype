using DAL.Models;
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

        public GenericRepository()
        {
            try
            {
                this.db = new STEInterfacesEntities();
                table = db.Set<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenericRepository(STEInterfacesEntities db)
        {
            try
            {
                this.db = db;
                table = db.Set<T>();
            }
            catch (Exception ex)
            {
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                throw ex;
            }
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }
        
        //public IEnumerable<Event> SelectAllActiveEvents()
        //{
        //    return (from el in db.Events
        //            where el.IsActive == true
        //            select el
        //            ).ToList();
        //}
        
        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        //public IEnumerable<EventLog> SelectByEventTypeID(int id)
        //{
        //    return (from el in db.EventLogs
        //            join e in db.Events on el.EventTypeID equals e.PID
        //            where el.EventTypeID == id
        //            select el).ToList();
        //}

        //public IEnumerable<Participant> SelectByIDAndFlag(object id, bool flag)
        //{
        //    var eventLogs = (from el in db.EventLogs
        //                     join e in db.Events on el.EventTypeID equals e.PID
        //                     where el.EventTypeID == 1
        //                     select el).ToList();
        //    var eventLogsParticipantIds = eventLogs.Select(e => e.Participant_PID).ToArray();

        //    if (flag)
        //    {
        //        return table
        //            .Where(p => eventLogsParticipantIds.Contains(p.PID))
        //            .ToList();
        //    }
        //    else
        //    {
        //        return table
        //            .Where(p => !eventLogsParticipantIds.Contains(p.PID))
        //            .ToList();
        //    }
        //}

        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                throw ex;
            }
        }

        public bool Update(int id, T obj)
        {
            try
            {
                table.Attach(obj);
                db.Entry(obj).State = EntityState.Modified;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                throw ex;
            }
            return true;
        }

        public void Delete(object id)
        {
            try
            {
                T existing = table.Find(id);
                table.Remove(existing);
            }
            catch (Exception ex)
            {
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                throw ex;
            }
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
                throw ex;
            }

        }

        public bool Exists(object id)
        {
            return (table.Find(id) != null);
            //return table.Count(e => e.PID == id) > 0;
        }
    }
}
