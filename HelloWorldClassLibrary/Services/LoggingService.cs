/* This Class Provides Exception logging into log files
 * 
 */

using System;
using System.IO;

namespace HelloWorldClassLibrary.Services
{
    public class LoggingService
    {
        public LoggingService()
        {
        }


        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="method">Method.</param>
        /// <param name="exception">Exception.</param>
		
        public static void WriteLog(string method, Exception exception)
		{
            string location = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			try
			{
				//Opens a new file stream which allows asynchronous reading and writing
				using (StreamWriter sw = new StreamWriter(new FileStream(location + @"log.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
				{
					//Writes the method name with the exception and writes the exception underneath
                    sw.WriteLine(String.Format("{0} ({1}) - Method: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), method));
					sw.WriteLine(exception.ToString()); sw.WriteLine("");
				}
			}
			catch (IOException)
			{
				if (!File.Exists(location + @"log.txt"))
				{
					File.Create(location + @"log.txt");
				}
			}
		}
    }
}
