using System;
using RestSharp;

namespace DownloadForYoutobe
{
    public class RestSharpHelper
    {
        public RestSharpHelper()
        {
           

        }
        public void getVideos(string str)
        {

            //var client = new RestClient("https://www.xcode.me");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            //var request = new RestRequest("resource/{id}", Method.Get);
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // add parameters for all properties on an object
            //request.AddObject(object);

            // or just whitelisted properties
            // request.AddObject(object, "PersonId", "Name", ...);

            // easily add HTTP Headers
            //  request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile("file", path);

            // execute the request
            // IRestResponse response = client.ExecuteAsync(request);
            // var content = response.Content; // raw content as string

            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //IRestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;

            // or download and save file to disk
            //client.DownloadData(request).SaveAs(path);

            // easy async support
            //await client.ExecuteAsync(request);



            /*var client = new RestClient("https://apis.juhe.cn/simpleWeather/query?city=%E4%B8%8A%E6%B5%B7&key=a3cbeaea2d9e7c7d7680860bb8e34fc5");
            var request = new RestRequest();
           
            IRestResponse respose = client.Execute(request);
            var content = respose.Content.ToString();*/

            var client = new RestClient(@"https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.channels.list?part=snippet,contentDetails&id=UCK8sQmJBp8GCxrOtXWBpyEA");
            var request = new RestRequest();
            request.AddHeader("Authorization", "Bearer oauth2-token");
            IRestResponse respose = client.Execute(request);
            var content = respose.Content.ToString();

            //ttww WW
            for (int i = 0; i < 100; i++) {

             }
        }
    }
}
