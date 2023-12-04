namespace Event2023.Puzzles.DayFour
{
    public class DayFourPart2 : DayFourBase
    {
        public int MatchedAmount(string line)
        {
            var input = line.Substring(line.IndexOf(':') + 1).Trim().Split('|');
            var winNumbers = fillList(input[0]);
            var myNumbers = fillList(input[1]);

            var ret = 0;
            foreach (var number in myNumbers)
            {
                //Console.WriteLine(number);
                if (winNumbers.Contains(number))
                {
                    ++ret;
                }
            }

            return ret;
        }

        public int Total(List<string> lines)
        {
            var n = lines.Count;
            var mem = new List<int>();
            for (int i = 0; i < n; i++)
            {
                mem.Add(1);
            }

            for (int i = 0; i < n; i++)
            {
                var matched = MatchedAmount(lines[i]);

                for (int j = i + 1; j <= i + matched; j++)
                {
                    mem[j] += mem[i];
                }
            }

            return mem.Sum(x => x);
        }
    }
}
