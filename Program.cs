using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace VandQuizJson
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Json Quiz vælg en af de nederstående");

            while (true)
            {
              
                Console.WriteLine("1. VandQuiz");
                Console.WriteLine("2. OOPSpgQuiz");
                Console.WriteLine("3. SqlQuiz");
                Console.WriteLine("4. Aslut");
                
                if (int.TryParse(Console.ReadLine(),out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                        VandSpg vandSpg = new VandSpg();
                        break;

                        case 2:
                        OOPSpg oOPSpg = new OOPSpg();
                        break;

                        case 3:
                        SqlSpg sqlSpg = new SqlSpg();   
                        break;

                        case 4:
                        Console.WriteLine("Ses");
                        return; 
                    }
                }
            }
        }
    }
}
