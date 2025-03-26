using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Insulin_Converter.Models;
using Newtonsoft.Json;


namespace Insulin_Converter.Services
{
    public static class ApiServices
    {
        //Function Searches for Item input by User
        public static async Task<Root> GetFood(string Item)
        {
            //Sets HttpClient
            var httpClient = new HttpClient();

            //Authorization access using access token
            string username = "db2592b4-191b-4643-a85b-d0dc8d3c73de";
            string password = "";
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            //Get request
            var response = await httpClient.GetStringAsync(string.Format("https://foodapi.calorieking.com/v1/foods?query=region=uk&query={0}&fields=$summary,nutrients", Item));
            return JsonConvert.DeserializeObject<Root>(response);

        }

        public static async Task<Root> GetServing(string Serving)
        {
            //Sets HttpClient
            var httpClient = new HttpClient();

            //Authorization access using access token
            string username = "db2592b4-191b-4643-a85b-d0dc8d3c73de";
            string password = "";
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            //Get request
            var response = await httpClient.GetStringAsync(string.Format("https://foodapi.calorieking.com/v1/foods?query=region=uk&query={0}&fields=$summary,servings", Serving));
            return JsonConvert.DeserializeObject<Root>(response);

        }

    }
}
