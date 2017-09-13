using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc517.Utility
{
    /// <summary>
    /// Logger
    /// </summary>
    public static class LogUtility
    {
        // logger
        public static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log an error message
        /// </summary>
        /// <param name="error">Error message</param>
        public static void LogErrorMsg(String error)
        {
            Logger.Error(error);
        }

        /// <summary>
        /// Log a set of errors
        /// </summary>
        /// <param name="errors">String Enumerable</param>
        public static void LogErrorMsg(IEnumerable<String> errors)
        {
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    Logger.Error(
                        String.Format(error));
                }
            }
        }

    }
}
