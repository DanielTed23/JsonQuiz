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
            Console.WriteLine("");
            int valg;

            // Fortsætter med at bede brugeren om input, indtil inputtet kan parses til en int og er inden for den tilladte rækkevidde (1-4).
            while (!int.TryParse(Console.ReadLine(), out valg) || valg < 1 || valg > 4)
            {
                Console.WriteLine("Ugyldigt valg. Skriv et af de tal, der står øverst.");
                Console.Write("Indtast dit valg (nummer): ");
            }

            // Afhængigt af brugerens valg, sættes stien til den relevante quiz-fil.
            string path = "";
            switch (valg)
            {
                case 1:
                    path = "SQLQuiz.json"; 
                    break;
                case 2:
                    path = "OOPSpg.json"; 
                    break;
                case 3:
                    path = "WaterQuiz.json"; 
                    break;
                case 4:
                    Api api = new Api(); // Opretter en ny instans af Api klassen.
                    api.Apirun(); // Udfører Apirun metoden i Api klassen.
                    return; 
                default:
                    Console.WriteLine("Ugyldigt valg"); 
                    return;
            }

            // Loader quiz data fra filen og behandler hvert quiz spørgsmål.
            if (!string.IsNullOrEmpty(path))
            {
                string json = File.ReadAllText(path); // Læser den komplette JSON fil til en string.
                List<QuizData> sporgsmalListe = JsonConvert.DeserializeObject<List<QuizData>>(json); // Deserialiserer JSON til en liste af QuizData objekter.

                foreach (var spg in sporgsmalListe) // Behandler hvert spørgsmål i listen.
                {
                    Console.WriteLine(spg.sporgsmol); // Viser spørgsmålet til brugeren.
                    for (int i = 0; i < spg.svarmulighed1.Count; i++) // Viser hver svarmulighed for det aktuelle spørgsmål.
                    {
                        Console.WriteLine($"{i + 1}. {spg.svarmulighed1[i]}");
                    }

                    Console.Write("Indtast dit svar (nummer): ");
                    int brugerSvar;
                    // Validerer brugerens svar indtil det er et gyldigt heltal og inden for gyldige svarmuligheder.
                    while (!int.TryParse(Console.ReadLine(), out brugerSvar) || brugerSvar < 1 || brugerSvar > spg.svarmulighed1.Count)
                    {
                        Console.WriteLine("Ugyldigt svar. Skriv et af de tal, der står øverst.");
                        Console.Write("Indtast dit svar (nummer): ");
                    }
                    int indeksSvar = brugerSvar - 1; // Beregner indexet til det valgte svar.

                    // Tjekker om det valgte svar er det korrekte svar.
                    if (indeksSvar == spg.korrektsvar)
                    {
                        Console.WriteLine("Korrekt!");
                    }
                    else
                    {
                        Console.WriteLine("Forkert.");
                    }

                    Console.WriteLine(spg.infoText); // Viser yderligere information eller feedback om spørgsmålet.
                }
                Console.WriteLine("Tryk 'Enter' for at fortsætte..."); 
                Console.ReadLine(); // Venter på brugerens input.
                Console.Clear(); // Renser konsolens skærm.
            }
        }
    }
}
