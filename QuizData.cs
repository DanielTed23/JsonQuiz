﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VandQuizJson
{
    public class QuizData
    {
        public string sporgsmol { get; set; }
        public List<string> svarmulighed1 { get; set; }
        public int korrektsvar { get; set; }
        public string infoText { get; set; }
    }
}
