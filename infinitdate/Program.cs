using System;
using System.Threading;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace infinitdate
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                var date = DateTime.Now;
                
                var client = new RestClient("http://test-webapi-bd/");
                var request = new RestRequest("api/produto", Method.GET);
                
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                string valfinal = content.ToString();
                
                Console.WriteLine($"Data Atual: {date}");
                Console.WriteLine($"Result: {valfinal}");
                Thread.Sleep(TimeSpan.FromSeconds(2)); 
            }

        }
    }
}
