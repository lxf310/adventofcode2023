namespace Event2023.Puzzles.DaySix
{
    public class DaySixPart2
    {
        private long convert(string line)
            => long.Parse(line.Split(':')[1].Replace(" ", ""));
        public long Possibility(List<string> inputs)
        {
            var time = convert(inputs[0]);
            var distance = convert(inputs[1]);

            var cnt = 0;
            for (int i = 0; i <= time / 2; i++)
            {
                if (distance < i * (time - i))
                {
                    cnt += 2;
                }
            }

            return time % 2 == 0 ? cnt - 1 : cnt;
        }
    }
}
