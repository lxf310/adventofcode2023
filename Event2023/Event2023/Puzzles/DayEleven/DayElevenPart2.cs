namespace Event2023.Puzzles.DayEleven
{
    public class DayElevenPart2 : DayElevenBase
    {
        public long Total(List<string> inputs, long times)
        {
            var map = inputs.Select(x => x.Select(y => y).ToList()).ToList();

            var m = map.Count;
            var n = map[0].Count;

            var rows = new List<int>();
            for (var i = 0; i < m; i++)
            {
                var contains = false;
                for (var j = 0; j < n; j++)
                {
                    if (map[i][j] == '#')
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    rows.Add(i);
                }
            }

            var cols = new List<int>();
            for (var i = 0; i < n; i++)
            {
                var contains = false;
                for (var j = 0; j < m; j++)
                {
                    if (map[j][i] == '#')
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    cols.Add(i);
                }
            }

            var pairs = findGalaxies(map);
            long ret = 0;
            Console.WriteLine($"Galaxies number: {pairs.Count}");
            for (int i = 0; i < pairs.Count; i++)
            {
                for (int j = i + 1; j < pairs.Count; j++)
                {
                    var x1 = Math.Min(pairs[i].Item1, pairs[j].Item1);
                    var x2 = Math.Max(pairs[i].Item1, pairs[j].Item1);
                    var y1 = Math.Min(pairs[i].Item2, pairs[j].Item2);
                    var y2 = Math.Max(pairs[i].Item2, pairs[j].Item2);

                    int cx = rows.Where(x => x >= x1 && x < x2).Count();
                    int cy = cols.Where(y => y >= y1 && y < y2).Count();

                    var distance = x2 - x1 + y2 - y1 + times * (cx + cy) - cx - cy;
                    //Console.WriteLine($"({pairs[j].Item1}, {pairs[j].Item2}) & ({pairs[i].Item1}, {pairs[i].Item2}) => {distance}");
                    ret += distance;
                }
            }

            return ret;
        }
    }
}
