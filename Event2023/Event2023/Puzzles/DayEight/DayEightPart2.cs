using System.Text.RegularExpressions;

namespace Event2023.Puzzles.DayEight
{
    public class DayEightPart2
    {
        public long Total(List<string> lines)
        {
            var indexMap = new Dictionary<char, int>
            {
                { 'L', 0 },
                { 'R', 1 }
            };

            var directions = lines[0];

            var maps = new Dictionary<string, List<string>>();
            var pattern = new Regex(@"^([\d|\w]{3}) = \(([\d|\w]{3}), ([\d|\w]{3})\)$");
            var starts = new List<string>();
            for (int i = 1; i < lines.Count; i++)
            {
                // AAA = (BBB, CCC)
                var match = pattern.Match(lines[i]);
                maps.Add(match.Groups[1].Value, new List<string> { match.Groups[2].Value, match.Groups[3].Value });
                if (match.Groups[1].Value.EndsWith('A'))
                {
                    starts.Add(match.Groups[1].Value);
                }
            }

            var cycles = new List<List<long>>();
            foreach (var start in starts)
            {
                var current = start;
                var cycle = new List<long>();
                var steps = 0;
                var pos = 0;
                var z = "";
                while (true)
                {
                    while (!current.EndsWith('Z'))
                    {
                        steps++;
                        current = maps[current][indexMap[directions[pos % directions.Length]]];
                        pos++;
                    }

                    cycle.Add(steps);

                    if (string.IsNullOrWhiteSpace(z))
                    {
                        z = current;
                    }
                    else if (current == z)
                    {
                        break;
                    }
                }

                cycles.Add(cycle);
            }

            var ret = cycles[0][0];
            foreach (var cycle in cycles)
            {
                foreach (var step in cycle)
                {
                    ret = ret * (step / Helper.GCD(ret, step));
                }
            }

            return ret;
        }
    }
}
