using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class LocationRepository: IDisposable
    {
        private STEInterfacesEntities db = null;

        public LocationRepository(STEInterfacesEntities context)
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
         
        public Location_SYD SelectById(int Id)
        {
            Location_SYD retVal = null;
            try
            {
                retVal = this.db.Location_SYD.FirstOrDefault(al => al.location_id == Id);
            }
            catch (Exception)
            {
                throw;
            }

            return (retVal);
        }

        public List<Location_SYD> SelectAll()
        {
            List<Location_SYD> retVal = null;
            try
            {
                retVal = this.db.Location_SYD.ToList<Location_SYD>();
            }
            catch (Exception)
            {
                throw;
            }
            return (retVal);
        }

        public void Create(Location_SYD obj)
        {
            try
            {
                db.Location_SYD.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Location_SYD obj)
        {
            try
            {
                Location_SYD locObject = this.db.Location_SYD.FirstOrDefault(loc => loc.location_id == obj.location_id);
                locObject = obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Location_SYD> GetLocation(string postCode, string location, string state)
        {
            List<Location_SYD> retVal = new List<Location_SYD>();
            //retVal = this.db.Location_SYD.Where("postcode = @PostCode and location = @Location and state = @State",
            //    new ObjectParameter("PostCode", postCode),
            //    new ObjectParameter("Location", location),
            //    new ObjectParameter("State", state))
            //    .ToList<Location_SYD>();
            return (retVal);
        }
        //"it.LastName==@ln", 
       

        public List<Location_SYD> getLocationByPostCode(string postCode)
        {
            List<Location_SYD> retVal = new List<Location_SYD>();

            return (retVal);
        }

        public List<Location_SYD> getLocationByLocation(string location)
        {
            List<Location_SYD> retVal = new List<Location_SYD>();
            return (retVal);
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
            throw new NotImplementedException();
        }
    }
}
