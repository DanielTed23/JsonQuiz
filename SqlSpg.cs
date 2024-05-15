using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandQuizJson
{
    public class SqlSpg
    {
        public SqlSpg()
        {
            deez();
        }

        public void deez()
        {

            // Angiver stien til JSON-filen, der skal læses.
            string path = "SqlQuiz.json";
            // Læser hele indholdet af JSON-filen ind i en streng.
            string json = File.ReadAllText(path);
            // Omdanner JSON-strengen til en liste af VandData-objekter.
            List<SqlData> AlleSpg = JsonConvert.DeserializeObject<List<SqlData>>(json);

            // Gennemgår alle spørgsmål i listen.
            for (int i = 0; i < AlleSpg.Count; i++)
            {
                // Udskriver spørgsmålet til konsollen.
                Console.WriteLine(AlleSpg[i].sporgsmol);
                // Udskriver første svarmulighed med nummer foran.
                Console.WriteLine("1. " + AlleSpg[i].svarmulighed1[0]);
                // Udskriver anden svarmulighed med nummer foran.
                Console.WriteLine("2. " + AlleSpg[i].svarmulighed1[1]);
                // Udskriver tredje svarmulighed med nummer foran.
                Console.WriteLine("3. " + AlleSpg[i].svarmulighed1[2]);

                // Bed brugeren om at indtaste et svarnummer.
                Console.Write("Indtast dit svar (nummer): ");
                int brugerSvar = Convert.ToInt32(Console.ReadLine());

                // Justerer brugerens svar fra et et-baseret til et nulbaseret indeks.
                int indeksSvar = brugerSvar - 1;

                // Tjekker om det indtastede svar er korrekt.
                if (indeksSvar == AlleSpg[i].korrektsvar)
                {
                    // Udskriver positiv tilbagemelding, hvis svaret er korrekt.
                    Console.WriteLine("korrekt nice du ikke helt dum");
                }
                else
                {
                    // Udskriver negativ tilbagemelding, hvis svaret er forkert.
                    Console.WriteLine("Forkert du dum LoL");
                }

                // Viser ekstra information om spørgsmålet.
                //Console.WriteLine(AlleSpg[i].infoText);
                // Venter på brugerinput før fortsættelse.
                Console.ReadLine();
                // Rydder konsolvinduet for næste spørgsmål.
                Console.Clear();
            }
        }
    }
}
