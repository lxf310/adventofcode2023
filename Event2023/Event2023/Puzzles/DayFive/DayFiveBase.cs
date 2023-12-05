namespace Event2023.Puzzles.DayFive
{
    public abstract class DayFiveBase
    {
        public List<List<List<long>>> ConvertToMaps(List<string> inputs)
        {
            var maps = new List<List<List<long>>>();
            var pos = -1;
            for (int i = 1; i < inputs.Count; i++)
            {
                if (inputs[i].EndsWith("map:"))
                {
                    maps.Add(new List<List<long>>());
                    ++pos;
                }
                else
                {
                    maps[pos].Add(inputs[i].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x.Trim())).Select(x => long.Parse(x.Trim())).ToList());
                }
            }

            return maps;
        }
    }
}
