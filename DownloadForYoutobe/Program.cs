using System;

namespace DownloadForYoutobe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //new RestSharpHelper().getVideos("1");
            //1
            LogHelper.INFO("Start");
           Google.Apis.YouTube.Samples.Search.Main1(null);
            Console.WriteLine("Hello World!");
        }
    }
}
