using System;
using Serilog;
namespace DownloadForYoutobe
{
    public class LogHelper
    {
        public LogHelper()
        {
        }

        public static void Info(string msg) {

            try
            {
            string logFile = "logs/" + DateTime.Now.ToString("yyyy-MM-dd")+ ".txt";
            Log.Logger = new LoggerConfiguration()
               //.WriteTo.File("logs/myapp.txt")
               .WriteTo.File(logFile)
               .CreateLogger();

            Log.Information(msg);


            Log.CloseAndFlush();
            }
            catch (Exception ex)
            {

            }
        }
        public static void Error(string msg) {

            string logFile = "logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(logFile)
               .CreateLogger();

            Log.Error(msg);
            Log.CloseAndFlush();
        }
    }
}
