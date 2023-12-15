namespace Event2023.Puzzles.DayFifteen
{
    public class DayFifteenPart1 : DayFifteenBase
    {
        public int Total(List<string> inputs)
        {
            var steps = inputs[0].Split(',').Where(x => !string.IsNullOrWhiteSpace(x));
            var ret = 0;
            foreach (var step in steps)
            {
                ret += hash(step);
            }

            return ret;
        }
    }
}
