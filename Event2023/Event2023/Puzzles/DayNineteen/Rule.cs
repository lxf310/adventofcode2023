namespace Event2023.Puzzles.DayNineteen
{
    public class Rule
    {
        public Rule(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Op { get; set; }
        public long Value { get; set; }
        public string Category { get; set; }
    }
}
