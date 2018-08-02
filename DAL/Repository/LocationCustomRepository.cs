using DAL.Models;
using Newtonsoft.Json;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public LocationCustomRepository(STEInterfacesEntities db)
        {
            try
            {
                this.db = db;
                table = db.Set<Location_SYD>();
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationArg"></param>
        /// <param name="exclusionFlag"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationArg"></param>
        /// <param name="postCodeArg"></param>
        /// <param name="stateArg"></param>
        /// <param name="exclusionFlag">
        ///     0 means nothing to exclude;
        ///     1 for excluding value in parenthesis
        ///     2 for excluding value after space
        /// </param>
        /// <returns></returns>
        public List<Location_SYD> SelectByLocationPostCodeAndState(string locationArg, 
            string postCodeArg, string stateArg, int exclusionFlag)
        {
            List<Location_SYD> locations = new List<Location_SYD>();
            try
            {
                locations = (from l in db.Location_SYD
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
                
            }
            catch (Exception ex)
            {
                Logger.Instance.GetLogInstance().Error(JsonConvert.SerializeObject(ex));
            }
            return locations;
        }

        /*
            
            
            
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationArg"></param>
        /// <param name="postCodeArg"></param>
        /// <param name="exclusionFlag">
        /// 0 means nothing to exclude;
        /// 1 for excluding value in parenthesis
        /// 2 for excluding value after space
        /// </param>
        /// <returns></returns>
        public List<Location_SYD> SelectByLocationAndPostCode(string locationArg, string postCodeArg, int exclusionFlag){
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
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationArg"></param>
        /// <param name="stateArg"></param>
        /// <param name="exclusionFlag">
        /// 0 means nothing to exclude
        /// 1 for excluding value in parenthesis
        /// 2 for excluding value after space
        /// </param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postCodeArg"></param>
        /// <returns></returns>
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
