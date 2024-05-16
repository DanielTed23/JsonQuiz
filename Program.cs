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
            QuizManager quizManager = new QuizManager();
            quizManager.Run();
        }
    }
}
