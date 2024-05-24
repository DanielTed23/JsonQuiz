using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace VandQuizJson
{
    public class QuizManager
    {
        public void Run()
        {
            Console.WriteLine("Vælg quiz-emnet:");
            Console.WriteLine("1. SQL Quiz");
            Console.WriteLine("2. C# Quiz");
            Console.WriteLine("3. Vandforbrug Quiz");
            Console.WriteLine("4. for Api");
            Console.Write("Indtast dit valg (nummer): ");
            int valg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            string path = "";
            switch (valg)
            {
                case 1:
                    path = "SQLQuiz.json"; // Stien til SQL-spørgsmål.
                    break;
                case 2:
                    path = "OOPSpg.json"; // Stien til C#-spørgsmål.
                    break;
                case 3:
                    path = "WaterQuiz.json"; // Stien til Vandforbrugs-spørgsmål.
                    break;
                case 4:
                    Api api = new Api();
                    api.Apirun();
                    return; // Tilføjet 'return' for at undgå yderligere udførelse efter API kaldet.
                default:
                    Console.WriteLine("Ugyldigt valg");
                    return;
            }

            // Denne blok skal udføres, når 'path' ikke er null, og valget ikke er API.
            if (!string.IsNullOrEmpty(path))
            {
                string json = File.ReadAllText(path);
                List<QuizData> sporgsmalListe = JsonConvert.DeserializeObject<List<QuizData>>(json);

                foreach (var spg in sporgsmalListe)
                {
                    Console.WriteLine(spg.sporgsmol);
                    for (int i = 0; i < spg.svarmulighed1.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {spg.svarmulighed1[i]}");
                    }

                    Console.Write("Indtast dit svar (nummer): ");
                    int brugerSvar = Convert.ToInt32(Console.ReadLine());
                    int indeksSvar = brugerSvar - 1;

                    if (indeksSvar >= 0 && indeksSvar < spg.svarmulighed1.Count && indeksSvar == spg.korrektsvar)
                    {
                        Console.WriteLine("Korrekt!");
                    }
                    else
                    {
                        Console.WriteLine("Forkert.");
                    }

                    Console.WriteLine(spg.infoText);
                }
                Console.WriteLine("Tryk 'Enter' for at fortsætte...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
