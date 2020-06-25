using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static string GET(string queryParams)
        {
            string baseUrl = "https://singlesearch.alk.com/na/api/search?authToken=FD0602B3D94A3748AD70E9ABA8EEC310&include=Meta";
            string url = baseUrl + queryParams;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public static void Main(string[] args)
        {
            bool repeat = false;
            do
            {
                string queryParams = string.Empty;
                Console.WriteLine("Which country ? Press Y to search in USA");
                string isUSA = Console.ReadLine();
                if (isUSA.ToLower() == "y")
                {
                    queryParams += "&countries=US";
                }

                Console.WriteLine("Search in cities only ? Press Y to do that");
                string isCity = Console.ReadLine();
                if (isCity.ToLower() == "y")
                {
                    queryParams += "&includeOnly=City";
                }

                Console.WriteLine("Enter the State Code if you want to limit the search to any state");
                string state = Console.ReadLine();
                if (!(string.IsNullOrEmpty(state)))
                {
                    queryParams += "&states=" + state;
                }

                Console.WriteLine("Enter the Text you want to search");
                string query = Console.ReadLine();
                if (!(string.IsNullOrEmpty(query)))
                {
                    queryParams += "&query=" + query;
                }
                else
                {
                    Console.WriteLine("Quitting!!! query string need to be provided");
                    System.Environment.Exit(0);
                }

                JObject response = JObject.Parse(GET(queryParams));

                JArray locationArr = JArray.Parse(response["Locations"].ToString());
                Console.WriteLine("---------------------------------------------------------------");
                foreach (var item in locationArr)
                {
                    Console.WriteLine(item["ShortString"]);
                }

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("Press Y to see full json response");
                if (Console.ReadLine().ToLower() == "y")
                {

                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine(response);
                    Console.WriteLine("---------------------------------------------------------------");
                }

                Console.WriteLine("Do you want to repeat the Search ?? Press Y , Press any other key to Exit");
                if (Console.ReadLine().ToLower() == "y")
                {
                    repeat = true;
                    Console.Clear();
                }
                else
                {
                    System.Environment.Exit(0);
                }
            } while (repeat);
            
        }
    }
}