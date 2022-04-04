using System;
using Serilog;
namespace DownloadForYoutobe
{
    public class LogHelper
    {
        public LogHelper()
        {
        }

        public static void INFO(string msg) {

            try
            {

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("logs/myapp.txt")
               .CreateLogger();

            Log.Information(msg);


            Log.CloseAndFlush();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
