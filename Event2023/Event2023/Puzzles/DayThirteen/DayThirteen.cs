namespace Event2023.Puzzles.DayThirteen
{
    public class DayThirteen
    {
        private long segragation(List<string> map, bool isPart2)
        {
            var m = map.Count;
            var n = map[0].Length;
            long cnt = 0;

            // horizental
            for (int i = 0; i < m - 1; i++)
            {
                var bad = 0;
                for (int ii = 0; ii < m; ii++)
                {
                    var up = i - ii;
                    var down = i + 1 + ii;
                    if (up >= 0 && up < down && down < m)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (map[up][j] != map[down][j])
                            {
                                bad++;
                            }
                        }
                    }
                }

                if (bad == (isPart2 ? 1 : 0))
                {
                    cnt += 100 * (i + 1);
                }
            }

            // vertical
            for (int j = 0; j < n - 1; j++)
            {
                var bad = 0;
                for (int jj = 0; jj < n; jj++)
                {
                    var left = j - jj;
                    var right = j + 1 + jj;
                    if (left >= 0 && left < right && right < n)
                    {
                        for (int i = 0; i < m; i++)
                        {
                            if (map[i][left] != map[i][right])
                            {
                                bad++;
                            }
                        }
                    }
                }

                if (bad == (isPart2 ? 1 : 0))
                {
                    cnt += (j + 1);
                }
            }

            return cnt;
        }

        public long Total(List<string> lines, bool isPart2)
        {
            var maps = new List<List<string>>
            {
                new List<string>()
            };

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    maps.Add(new List<string>());
                }
                else
                {
                    maps.Last().Add(lines[i]);
                }
            }

            long ret = 0;
            foreach (var map in maps)
            {
                var cnt = segragation(map, isPart2);
                Console.WriteLine($"cnt = {cnt}");
                ret += cnt;
            }

            return ret;
        }
    }
}
