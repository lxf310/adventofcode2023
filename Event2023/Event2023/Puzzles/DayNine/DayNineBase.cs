namespace Event2023.Puzzles.DayNine
{
    public abstract class DayNineBase
    {
        protected List<List<int>> GetMemo(List<int> history)
        {
            var memo = new List<List<int>>();
            var pre = history;
            while (pre.Any(x => x != 0))
            {
                memo.Add(pre);
                var cur = new List<int>();
                for (int i = 0; i < pre.Count - 1; i++)
                {
                    cur.Add(pre[i + 1] - pre[i]);
                }
                pre = cur;
            }

            memo.Add(pre);

            return memo;
        }

        public abstract int Next(List<int> history);

        public int Total(List<string> lines)
        {
            var numbers = lines.Select(x => x.Trim().Split(' ').Where(y => !string.IsNullOrWhiteSpace(y)).Select(z => int.Parse(z)).ToList()).ToList();
            var ret = 0;
            foreach (var number in numbers)
            {
                var next = Next(number);
                // Console.WriteLine($"next = {next}");
                ret += next;
            }

            return ret;
        }
    }
}
