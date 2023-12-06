namespace Event2023.Puzzles.DaySix
{
    public class DaySixPart1
    {
        private List<int> convert(string line)
            => line.Split(':')[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();

        private int possibility(int time, int distance)
        {
            var cnt = 0;
            for (int i = 0; i < time; i++)
            {
                if (distance < i * (time - i))
                {
                    cnt++;
                }
            }

            //Console.WriteLine($"possibility: {cnt}");
            return cnt;
        }

        public int Total(List<string> inputs)
        {
            var times = convert(inputs[0]);
            var distances = convert(inputs[1]);

            var ret = 1;
            for (int i = 0; i < times.Count; i++)
            {
                ret *= possibility(times[i], distances[i]);
            }
            return ret;
        }
    }
}
