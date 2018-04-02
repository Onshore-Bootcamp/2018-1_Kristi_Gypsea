using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace GYPSEA
{
    public class LoggerP
    {
        private readonly string LogPath = ConfigurationManager.AppSettings["LogPathP"];

        public void Log(string level,
                        string source,
                        string target,
                        string message,
                        string stackTrace = null)
        {
            string timeStamp = DateTime.Now.ToString();
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(LogPath, true);
                writer.WriteLine("[{0}] - {1} - {2} - {3} - {4}",
                    timeStamp, level, source, target, message);
                if (stackTrace != null)
                {
                    writer.WriteLine(stackTrace);
                }
            }
            catch (Exception)
            { }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
}