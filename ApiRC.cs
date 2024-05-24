using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace VandQuizJson
{
    internal class ApiRC
    {
        private  string GetApiResponse(string difficulty, string limit)
        {
            // Sæt URL for API, som vi vil kalde
            RestClient client = new("https://quizapi.io/api/v1/questions");
            // Opret en anmodning til API'en
            RestRequest request = new();

            // Tilføj parametre til anmodningen
            request.AddParameter("apiKey", "5WSuwStMLRtsTBirMAQP9ZJhU0zpIFwisu3Ok4El"); // Tilføj min API-nøgle
            request.AddParameter("limit", limit); // Sæt antallet af spørgsmål
            request.AddParameter("difficulty", difficulty); // Sæt sværhedsgraden
            request.AddParameter("category", "Code"); // Sæt kategorien til 'Code' som standard og uden brugerindgriben

            return client.Execute(request).Content; // Returner svaret fra API'en
        }

        public  List<Format> ConvertApi()
        {
            // Spørger brugeren om at vælge sværhedsgrad og antal spørgsmål
            Console.WriteLine("Indtast sværhedsgrad (Easy, Medium, Hard):");
            string difficulty = Console.ReadLine();
            Console.WriteLine("Indtast antallet af spørgsmål:");
            string limit = Console.ReadLine();

            // Konverter svaret til en liste af Format objekter ved at deserialize JSON-svaret
            return JsonConvert.DeserializeObject<List<Format>>(GetApiResponse(difficulty, limit));
        }
    }
}
