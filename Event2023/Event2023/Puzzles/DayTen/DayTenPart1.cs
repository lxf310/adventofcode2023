namespace Event2023.Puzzles.DayTen
{
    public class DayTenPart1 : DayTenBase
    {
        public int Total(List<string> inputs)
        {
            var maps = inputs.Select(x => x.Select(y => y).ToList()).ToList();

            var m = maps.Count;
            var n = maps[0].Count;

            var start = findStart(maps, m, n);
            var loop = new List<string> { $"{start.Item1}_{start.Item2}" };
            var help = new Queue<Tuple<int, int>>();

            // bfs
            help.Enqueue(start);
            while (help.Any())
            {
                var cur = help.Dequeue();
                var ch = maps[cur.Item1][cur.Item2];
                if (cur.Item1 > 0 && "S|JL".Contains(ch) && "|7F".Contains(maps[cur.Item1 - 1][cur.Item2]) && !loop.Contains($"{cur.Item1 - 1}_{cur.Item2}"))
                {
                    loop.Add($"{cur.Item1 - 1}_{cur.Item2}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1 - 1, cur.Item2));
                }

                if (cur.Item1 + 1 < m && "S|7F".Contains(ch) && "|JL".Contains(maps[cur.Item1 + 1][cur.Item2]) && !loop.Contains($"{cur.Item1 + 1}_{cur.Item2}"))
                {
                    loop.Add($"{cur.Item1 + 1}_{cur.Item2}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1 + 1, cur.Item2));
                }

                if (cur.Item2 > 0 && "S-J7".Contains(ch) && "-LF".Contains(maps[cur.Item1][cur.Item2 - 1]) && !loop.Contains($"{cur.Item1}_{cur.Item2 - 1}"))
                {
                    loop.Add($"{cur.Item1}_{cur.Item2 - 1}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1, cur.Item2 - 1));
                }

                if (cur.Item2 + 1 < n && "S-LF".Contains(ch) && "-J7".Contains(maps[cur.Item1][cur.Item2 + 1]) && !loop.Contains($"{cur.Item1}_{cur.Item2 + 1}"))
                {
                    loop.Add($"{cur.Item1}_{cur.Item2 + 1}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1, cur.Item2 + 1));
                }
            }

            return (loop.Count % 2 == 0) ? (loop.Count / 2) : (loop.Count / 2 + 1);
        }
    }
}
