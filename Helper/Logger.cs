using System;
using log4net;

namespace Helper
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> lazy = new Lazy<Logger>(() => new Logger());

        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static Logger Instance { get { return lazy.Value; } }

        /// <summary>
        /// 
        /// </summary>
        private Logger()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ILog GetLogInstance()
        {
            return (Log);
        }



    }
}
