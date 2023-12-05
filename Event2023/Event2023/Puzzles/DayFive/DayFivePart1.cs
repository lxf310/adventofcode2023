namespace Event2023.Puzzles.DayFive
{
    public class DayFivePart1 : DayFiveBase
    {
        public long Next(long current, List<List<List<long>>> maps, int pos)
        {
            if (pos >= maps.Count)
            {
                return current;
            }

            foreach (var item in maps[pos])
            {
                if (current >= item[1] && current < item[1] + item[2])
                {
                    return Next(item[0] + (current - item[1]), maps, pos + 1);
                }
            }

            return Next(current, maps, pos + 1);
        }


        public long Total(List<string> inputs)
        {
            var seeds = inputs[0].Substring(7).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x.Trim())).Select(x => long.Parse(x.Trim())).ToList();

            var maps = ConvertToMaps(inputs);
            var ret = new List<long>();
            foreach (var seed in seeds)
            {
                var location = Next(seed, maps, 0);
                ret.Add(location);
            }

            return ret.Min();
        }
    }
}
