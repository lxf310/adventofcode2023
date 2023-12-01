namespace Event2023.Puzzles.DayOne
{
    public class NumberReaderTwo : INumberReader
    {
        public int Read(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentNullException(nameof(input));

            var dict = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            var numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add((int)char.GetNumericValue(input[i]));
                    continue;
                }

                string cur = "";
                for (int j = i; j < input.Length; j++)
                {
                    cur += input[j];
                    if (dict.TryGetValue(cur, out var value))
                    {
                        numbers.Add(value);
                        break;
                    }
                }
            }

            if (!numbers.Any()) return 0;

            return numbers.First() * 10 + numbers.Last();
        }
    }
}
