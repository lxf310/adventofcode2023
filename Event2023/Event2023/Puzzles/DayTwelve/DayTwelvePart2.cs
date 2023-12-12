namespace Event2023.Puzzles.DayTwelve
{
    public class DayTwelvePart2
    {
        private long possibilities(string candidates, List<int> numbers, int i, int j, int cnt, Dictionary<string, long> cache)
        {
            var key = $"{i}_{j}_{cnt}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (i == candidates.Length)
            {
                if (j == numbers.Count && cnt == 0 || j == numbers.Count - 1 && cnt == numbers[j])
                {
                    return 1;
                }

                return 0;
            }

            long amount = 0;
            foreach (var ch in ".#")
            {
                if (candidates[i] == ch || candidates[i] == '?')
                {
                    if (ch == '.' && cnt == 0)
                    {
                        amount += possibilities(candidates, numbers, i + 1, j, 0, cache);
                    }
                    else if (ch == '.' && j < numbers.Count && cnt == numbers[j])
                    {
                        amount += possibilities(candidates, numbers, i + 1, j + 1, 0, cache);
                    }
                    else if (ch == '#')
                    {
                        amount += possibilities(candidates, numbers, i + 1, j, cnt + 1, cache);
                    }
                }
            }

            cache.Add(key, amount);
            return amount;
        }

        public long Total(List<string> lines)
        {
            long ret = 0;
            foreach (var line in lines)
            {
                // ???.### 1,1,3
                var input = line.Split(' ');
                var candidates = string.Join("?", new List<string> { input[0], input[0], input[0], input[0], input[0] });
                var numbers = string.Join(",", new List<string> { input[1], input[1], input[1], input[1], input[1] })
                    .Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();

                long curCnt = possibilities(candidates, numbers, 0, 0, 0, new Dictionary<string, long>());
                //Console.WriteLine($"cnt = {curCnt}");
                ret += curCnt;
            }

            return ret;
        }
    }
}
