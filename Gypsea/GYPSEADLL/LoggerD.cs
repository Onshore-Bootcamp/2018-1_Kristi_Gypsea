using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL
{
    public class LoggerD
    {
        private readonly string LogPath = ConfigurationManager.AppSettings["LogPathD"];

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
                writer.WriteLine("\n");
                writer.WriteLine(" [{0}] - {1} - {2} - {3} - {4} ",
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
