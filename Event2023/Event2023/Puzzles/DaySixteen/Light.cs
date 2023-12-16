namespace Event2023.Puzzles.DaySixteen
{
    public class Light
    {
        // U: up
        // D: down
        // L: left
        // R: right
        public char Direction { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public string Key1
        {
            get
            {
                return $"{Row}_{Col}";
            }
        }

        public string Key2
        {
            get
            {
                return $"{Row}_{Col}_{Direction}";
            }
        }
    }
}
