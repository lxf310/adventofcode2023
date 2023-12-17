namespace Event2023.Puzzles.DaySeventeen
{
    public class Step
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Direction { get; set; }
        public int Cnt { get; set; }
        public int Cost { get; set; }
        public string Key
        {
            get
            {
                return $"{Row}_{Col}_{Direction}_{Cnt}";
            }
        }
    }
}
