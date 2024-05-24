using Newtonsoft.Json;
using RestSharp;

namespace VandQuizJson
{
    internal class Api
    {
        public void Apirun()
        {
            string abc = "abcdef";
            // Respons fra api, bliver sat ind i listen questionList
            List<Format> questionList = ConvertApi();

            // Hvert question bliver udskrevet via foreach loop
            foreach (Format question in questionList)
            {
                Console.WriteLine(question.question);

                // Hvert question, har flere svar muligheder, som vi udskriver via foreach loop
                int i = 0;
                foreach (var answer in question.answers)
                {
                    
                    if (answer.Value is not null)
                    {
                       
                        Console.WriteLine(abc[i]+") " + answer.Value);
                        
                    }
                    i++;
                }

                // Tager input fra bruger, og ligger det i en variable
                Console.WriteLine("Indtast dit svar");
                string svar = Console.ReadLine();
                

                // Sammensætter svar til en ny string, som bliver kontrollet, om svaret er korrekt / true
                string svarString = "answer_" + svar + "_correct";

                if (question.correct_answers[svarString] == "true")
                {
                    Console.WriteLine("Korrekt");
                }
                else
                {
                    Console.WriteLine("Ikke korrekt");
                }

            }
        }


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


