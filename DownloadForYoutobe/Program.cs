using System;

namespace DownloadForYoutobe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //new RestSharpHelper().getVideos("1");
            //1
            LogHelper.Info("Main Start");
           // CmdHelper.Execute("youtube-dl -f ' bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best ' https://www.youtube.com/watch?v=P0iXry6vrfQ");
            Google.Apis.YouTube.Samples.Search.Main1(null);
            LogHelper.Info("Main End");
            Console.WriteLine("Hello World!");
        }
    }
}
