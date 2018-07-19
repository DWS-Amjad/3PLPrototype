using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    public class LocationCustomRepository
    {
        private STEInterfacesEntities db = null;
        private DbSet<Location_SYD> table = null;

        public LocationCustomRepository()
        {
            try
            {
                this.db = new STEInterfacesEntities();
                table = db.Set<Location_SYD>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Location_SYD> GetLocationByLocation(string locationArg, int exclusionFlag)
        {
            var locations = (from l in db.Location_SYD
                             where (
                                        (exclusionFlag > 0)
                                        ?
                                        (exclusionFlag > 1)
                                            ? l.location.Substring(0,
                                                        (l.location.IndexOf(" ") == -1)
                                                            ? 0
                                                            : l.location.IndexOf(" ")
                                                    ).Trim().ToLower() == locationArg.ToLower()
                                            : l.location.Substring(0,
                                                        (l.location.IndexOf("(") == -1)
                                                            ? 0
                                                            : l.location.IndexOf("(")
                                                    ).Trim().ToLower() == locationArg.ToLower()
                                        : l.location.Trim().ToLower() == locationArg.ToLower()
                                )
                             select l).ToList();

            return (locations);
        }
        /*
            0 means nothing to exclude;
            1 for excluding value in parenthesis
            2 for excluding value after space
        */
        public List<Location_SYD> SelectByLocationPostCodeAndState(string locationArg, 
            string postCodeArg, string stateArg, int exclusionFlag)
        {
            try
            {
                var locations = (from l in db.Location_SYD
                                 where  (
                                             (exclusionFlag > 0) 
                                             ?
                                                (exclusionFlag > 1)
                                                    ? l.location.Substring(0,
                                                                (l.location.IndexOf(" ") == -1)
                                                                    ? 0
                                                                    : l.location.IndexOf(" ")
                                                            ).Trim().ToLower() == locationArg.ToLower()
                                                    : l.location.Substring(0, 
                                                                (l.location.IndexOf("(") == -1) 
                                                                    ? 0 
                                                                    : l.location.IndexOf("(")
                                                            ).Trim().ToLower() == locationArg.ToLower()
                                             : l.location.Trim().ToLower() == locationArg.ToLower()
                                        )
                                        && l.postcode.Trim().ToLower() == postCodeArg.ToLower()
                                        && l.state.Trim().ToLower() == stateArg.ToLower()
                                 select l).ToList();
                return locations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
            0 means nothing to exclude;
            1 for excluding value in parenthesis
            2 for excluding value after space
        */
        public List<Location_SYD> SelectByLocationAndPostCode(string locationArg, string postCodeArg, int exclusionFlag){
            //Location_SYD returnVal = null;
            var locations = (from l in db.Location_SYD
                             where  (
                                        (exclusionFlag > 0)
                                         ?
                                            (exclusionFlag > 1)
                                            ? (exclusionFlag > 2)
                                                ? l.location.Substring(0, 5).Trim().ToLower() == locationArg.ToLower()
                                                : l.location.Substring(0, 
                                                        (l.location.IndexOf(" ") == -1)
                                                        ? 0
                                                        : l.location.IndexOf(" ")
                                                    ).Trim().ToLower() == locationArg.ToLower()
                                            : l.location.Substring(0, 
                                                                        (l.location.IndexOf("(") == -1)
                                                                        ? 0
                                                                        : l.location.IndexOf("(")
                                                                  ).Trim().ToLower() == locationArg.ToLower()
                                         : l.location.Trim().ToLower() == locationArg.ToLower()
                                    )
                                    && l.postcode.Trim().ToLower() == postCodeArg.Trim().ToLower()
                             select l).ToList();
            //returnVal = locations.FirstOrDefault<Location_SYD>();
            return locations;
        }
        
        /*
         0 means nothing to exclude
         1 for excluding value in parenthesis
         2 for excluding value after space
        */
        public List<Location_SYD> SelectByLocationAndState(string locationArg, string stateArg, int exclusionFlag)
        {
            //Location_SYD returnVal = null;
            var locations = (from l in db.Location_SYD
                             where (
                                        (exclusionFlag > 0)
                                        ?
                                        (exclusionFlag > 1)
                                            ? l.location.Substring(0,
                                                        (l.location.IndexOf(" ") == -1)
                                                            ? 0
                                                            : l.location.IndexOf(" ")
                                                    ).Trim().ToLower() == locationArg.ToLower()
                                            : l.location.Substring(0,
                                                        (l.location.IndexOf("(") == -1)
                                                            ? 0
                                                            : l.location.IndexOf("(")
                                                    ).Trim().ToLower() == locationArg.ToLower()
                                        : l.location.Trim().ToLower() == locationArg.ToLower()
                                )
                             && l.state.Trim().ToLower() == stateArg.ToLower()
                             select l).ToList();
            //returnVal = locations.FirstOrDefault<Location_SYD>();
            return locations;
        }

        public bool DoesPostCodeExist(string postCodeArg)
        {
            bool returnVal = true;

            var locations = (from l in db.Location_SYD
                             where l.state.Trim().ToLower() == postCodeArg.ToLower()
                             select l).ToList();

            if (locations.Count() == 0)
                returnVal = false;

            return returnVal;
        }
    }
}
