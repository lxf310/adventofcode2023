using System.Text.RegularExpressions;

namespace Event2023.Puzzles.DayEight
{
    public class DayEightPart1
    {
        public int Total(List<string> lines)
        {
            var indexMap = new Dictionary<char, int>
            {
                { 'L', 0 },
                { 'R', 1 }
            };

            var directions = lines[0];

            var maps = new Dictionary<string, List<string>>();
            var pattern = new Regex(@"^(\w\w\w) = \((\w\w\w), (\w\w\w)\)$");
            for (int i = 1; i < lines.Count; i++)
            {
                // AAA = (BBB, CCC)
                var match = pattern.Match(lines[i]);
                maps.Add(match.Groups[1].Value, new List<string> { match.Groups[2].Value, match.Groups[3].Value });
            }

            var src = "AAA";
            var des = "ZZZ";
            var ret = 0;
            var pos = 0;
            while (src != des)
            {
                ret++;
                src = maps[src][indexMap[directions[pos % directions.Length]]];
                pos++;
            }

            return ret;
        }
    }
}
