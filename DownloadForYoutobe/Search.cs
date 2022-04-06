/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using static Google.Apis.YouTube.v3.CommentThreadsResource.ListRequest;

namespace Google.Apis.YouTube.Samples
{
  /// <summary>
  /// YouTube Data API v3 sample: search by keyword.
  /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
  /// See https://code.google.com/p/google-api-dotnet-client/wiki/GettingStarted
  ///
  /// Set ApiKey to the API key value from the APIs & auth > Registered apps tab of
  ///   https://cloud.google.com/console
  /// Please ensure that you have enabled the YouTube Data API for your project.
  /// </summary>
  internal class Search
  {
    [STAThread]
    public static void Main1(string[] args)
    {
      Console.WriteLine("YouTube Data API: Search");
      Console.WriteLine("========================");

      try
      {
        new Search().Run().Wait();
      }
      catch (AggregateException ex)
      {
        foreach (var e in ex.InnerExceptions)
        {
          Console.WriteLine("Error: " + e.Message);
        }
      }

      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    private async Task Run()
    {
      var youtubeService = new YouTubeService(new BaseClientService.Initializer()
      {
        ApiKey = "AIzaSyB50KpMyD05DXAKZ_4UhHponSsfBT2FjAs",
        ApplicationName = this.GetType().ToString()
      });

            //var searchListRequest = youtubeService.Search.List("snippet");
            //searchListRequest.Q = "Google"; // Replace with your search term.
            //searchListRequest.Q = "Multi Tech Media"; 
            //searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            //add by myb  根据ID搜索
            var searchListRequest = youtubeService.Search.List("id,snippet");
            //searchListRequest.Q = "Multi Tech Media"; 
            searchListRequest.ChannelId = "UCXAhMulAxc_TOhkCeq06rwQ";//Multi Tech Media
            searchListRequest.Type = "video";
            searchListRequest.MaxResults = 100;
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
            //end
            /*try
            {
                var searchListR= await searchListRequest.ExecuteAsync();
            }
            catch (Exception ex)
            {
                DownloadForYoutobe.LogHelper.Info(ex.Message+ex.StackTrace);
            }
            */
            var searchListResponse = await searchListRequest.ExecuteAsync();
            List<string> videos = new List<string>();
      List<string> channels = new List<string>();
      List<string> playlists = new List<string>();

      // Add each result to the appropriate list, and then display the lists of
      // matching videos, channels, and playlists.
      foreach (var searchResult in searchListResponse.Items)
      {
        switch (searchResult.Id.Kind)
        {
          case "youtube#video":
            videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
            break;

          case "youtube#channel":
            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
            break;

          case "youtube#playlist":
            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
            break;
        }
      }

      Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
      Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
      Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

            //title="GEM鄧紫棋" href="/channel/UCsLWG2t7n9LFsvH0wR2rtpw">
            //"Multi Tech Media (UCXAhMulAxc_TOhkCeq06rwQ)"  //ok 
            //"Multi Tech Media (UCu46Y_hK2oRmSO6afGZAUuA)"
            // "Samsung Galaxy S21 WORLD&#39;S FIRST? Price, Camera, Launch Date, Features, Trailer, Leaks, Concept (1oWq1P_1tCY)"
            //播放地址： https://www.youtube.com/watch?v=1oWq1P_1tCY
            DownloadForYoutobe.LogHelper.Info(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
        }
    }
}
