namespace VandQuizJson
{
    internal class Format
    {
        public int id { get; set; }

        public string? question { get; set; }

        public string? description { get; set; }

        public string? explanation { get; set; }

        public string? category { get; set; }

        public Dictionary<string, string>? answers { get; set; }

        public Dictionary<string, string>? correct_answers { get; set; }
    }
}
