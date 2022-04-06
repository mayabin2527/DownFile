using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DownloadForYoutobe
{
    public class CmdHelper
    {
        public CmdHelper()
        {
        }
        public static void Execute(string cmdtext) {

            /*System.Diagnostics.Process proc = System.Diagnostics.Process.Start("/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal cd /Users/ma_yabin" + cmdtext);
            proc.WaitForExit();
            */
            // Run "csc.exe /r:System.dll /out:sample.exe stdstr.cs". UseShellExecute is false because we're specifying
            // an executable directly and in this case depending on it being in a PATH folder. By setting
            // RedirectStandardOutput to true, the output of csc.exe is directed to the Process.StandardOutput stream
            // which is then displayed in this console window directly.

            //命令行执行命令下载
            //https://cloud.tencent.com/developer/ask/sof/1216437
            try
            {

             DownloadForYoutobe.LogHelper.Info("Execute Cmd:"+ cmdtext);


            using (Process compiler = new Process())
             {
                 compiler.StartInfo.FileName = "/bin/bash";
                 //compiler.StartInfo.Arguments = "-c \"cd /Users/ma_yabin;ls\"";
                compiler.StartInfo.Arguments = "-c \"cd /Users/ma_yabin;ls;"+ cmdtext + "\"";
                compiler.StartInfo.UseShellExecute = false;
                 compiler.StartInfo.RedirectStandardOutput = true;
                 compiler.Start();

                 Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                 compiler.WaitForExit();
             }

            }
            catch (Exception ex)
            {
                DownloadForYoutobe.LogHelper.Error(ex.Message + ex.StackTrace);
            }
        }
        public static void ExecuteCMDWithVideos(Dictionary<string, string> videoList) {
            try
            {

            Dictionary<string, string> videos = videoList;
            foreach (string key in videoList.Keys)
            {
                string videoName = videos["key"];
                string videoUrl = "https://www.youtube.com/watch?v=" + key;
                string cmd = "youtube-dl -f ' bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best ' " + videoUrl;
                    DownloadForYoutobe.LogHelper.Info("Video ID:" + key+"-->"+ videoName);
                    Execute(cmd);
            }

            }
            catch (Exception ex)
            {
                DownloadForYoutobe.LogHelper.Error(ex.Message + ex.StackTrace);
            }
        }
    }
}
