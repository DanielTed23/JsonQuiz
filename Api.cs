using Newtonsoft.Json;
using RestSharp;


namespace VandQuizJson
{
    internal class Api
    {
        private ApiRC _apiRC;
        public Api()
        {

            _apiRC = new ApiRC();
        }


        public void Apirun()
        {
            string abc = "abcdef";
            // Respons fra api, bliver sat ind i listen questionList
            List<Format> questionList = _apiRC.ConvertApi();

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

                        Console.WriteLine(abc[i] + ") " + answer.Value);

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

    }

}


