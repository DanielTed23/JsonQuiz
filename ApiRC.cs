using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandQuizJson
{
    internal class ApiRC
    {
        private static string GetApiResponse(string difficulty = "Easy", string limit = "10", string category = "Code")
        {
            // Set the url for the API that we want to call
            RestClient client = new("https://quizapi.io/api/v1/questions");
            // Create a request to the API
            RestRequest request = new();

            // Add parameters to the request

            request.AddParameter("apiKey", "5WSuwStMLRtsTBirMAQP9ZJhU0zpIFwisu3Ok4El"); // Add my API-Key
            request.AddParameter("limit", limit); // Set the limit of questions
            request.AddParameter("difficulty", difficulty); // Set the difficulty
            request.AddParameter("category", category); // Set the category

            return client.Execute(request).Content; // Return the response content from the API
        }



        public static List<Format> ConvertApi()
        {
            // Convert the response to a list of Format objects by deserializing the JSON-response
            return JsonConvert.DeserializeObject<List<Format>>(GetApiResponse(/*GetDifficulty(), GetLimit(), GetCategory()*/));
        }
    }
}
