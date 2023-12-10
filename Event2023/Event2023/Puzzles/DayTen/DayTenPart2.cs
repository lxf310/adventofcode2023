namespace Event2023.Puzzles.DayTen
{
    public class DayTenPart2 : DayTenBase
    {
        public int Total(List<string> inputs)
        {
            var maps = inputs.Select(x => x.Select(y => y).ToList()).ToList();

            var m = maps.Count;
            var n = maps[0].Count;

            var start = findStart(maps, m, n);
            var loop = new List<string> { $"{start.Item1}_{start.Item2}" };
            var help = new Queue<Tuple<int, int>>();

            var possibleS = new List<char> { '|', '-', 'J', 'L', '7', 'F' };

            help.Enqueue(start);
            while (help.Any())
            {
                var cur = help.Dequeue();
                var ch = maps[cur.Item1][cur.Item2];
                if (cur.Item1 > 0 && "S|JL".Contains(ch) && "|7F".Contains(maps[cur.Item1 - 1][cur.Item2]) && !loop.Contains($"{cur.Item1 - 1}_{cur.Item2}"))
                {
                    loop.Add($"{cur.Item1 - 1}_{cur.Item2}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1 - 1, cur.Item2));
                    if (ch == 'S')
                    {
                        possibleS = possibleS.Where(x => "|JL".Contains(x)).ToList();
                    }
                }

                if (cur.Item1 + 1 < m && "S|7F".Contains(ch) && "|JL".Contains(maps[cur.Item1 + 1][cur.Item2]) && !loop.Contains($"{cur.Item1 + 1}_{cur.Item2}"))
                {
                    loop.Add($"{cur.Item1 + 1}_{cur.Item2}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1 + 1, cur.Item2));

                    if (ch == 'S')
                    {
                        possibleS = possibleS.Where(x => "|7F".Contains(x)).ToList();
                    }
                }

                if (cur.Item2 > 0 && "S-J7".Contains(ch) && "-LF".Contains(maps[cur.Item1][cur.Item2 - 1]) && !loop.Contains($"{cur.Item1}_{cur.Item2 - 1}"))
                {
                    loop.Add($"{cur.Item1}_{cur.Item2 - 1}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1, cur.Item2 - 1));

                    if (ch == 'S')
                    {
                        possibleS = possibleS.Where(x => "-J7".Contains(x)).ToList();
                    }
                }

                if (cur.Item2 + 1 < n && "S-LF".Contains(ch) && "-J7".Contains(maps[cur.Item1][cur.Item2 + 1]) && !loop.Contains($"{cur.Item1}_{cur.Item2 + 1}"))
                {
                    loop.Add($"{cur.Item1}_{cur.Item2 + 1}");
                    help.Enqueue(new Tuple<int, int>(cur.Item1, cur.Item2 + 1));

                    if (ch == 'S')
                    {
                        possibleS = possibleS.Where(x => "-LF".Contains(x)).ToList();
                    }
                }
            }

            maps[start.Item1][start.Item2] = possibleS.Single();
            // clean up board
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var key = $"{i}_{j}";
                    if (!loop.Contains(key))
                    {
                        maps[i][j] = '.';
                    }
                }
            }

            var outside = new HashSet<string>();
            for (int i = 0; i < m; i++)
            {
                var flag = false;
                var up = false;
                for (int j = 0; j < n; j++)
                {
                    var ch = maps[i][j];
                    if (ch == '|')
                    {
                        flag = !flag;
                    }
                    else if ("LF".Contains(ch))
                    {
                        up = ch == 'L';
                    }
                    else if ("7J".Contains(ch))
                    {
                        if (ch != (up ? 'J' : '7'))
                        {
                            flag = !flag;
                        }

                        up = false;
                    }

                    if (!flag)
                    {
                        outside.Add($"{i}_{j}");
                    }
                }
            }

            return m * n - (outside.Count + loop.Where(x => !outside.Contains(x)).ToList().Count);
        }
    }
}
