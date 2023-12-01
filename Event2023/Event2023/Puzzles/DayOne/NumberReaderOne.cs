namespace Event2023.Puzzles.DayOne
{
    public class NumberReaderOne : INumberReader
    {
        public int Read(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input));

            int first = -1, last = -1;
            foreach (var ch in input)
            {
                if (char.IsDigit(ch))
                {
                    if (first == -1)
                    {
                        first = (int)char.GetNumericValue(ch);
                    }
                    last = (int)char.GetNumericValue(ch);
                }
            }

            if (first == -1) return 0;

            return first * 10 + last;
        }
    }
}
