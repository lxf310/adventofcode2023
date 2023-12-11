namespace Event2023.Puzzles.DayEleven
{
    public class DayElevenPart1 : DayElevenBase
    {
        protected List<List<char>> expand(List<List<char>> original)
        {
            var m = original.Count;
            var n = original[0].Count;

            var rows = new List<int>();
            for (var i = 0; i < m; i++)
            {
                var contains = false;
                for (var j = 0; j < n; j++)
                {
                    if (original[i][j] == '#')
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
                    if (original[j][i] == '#')
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

            var expanded1 = new List<List<char>>();
            for (var i = 0; i < m; i++)
            {
                var cur = new List<char>();
                for (var j = 0; j < n; j++)
                {
                    cur.Add(original[i][j]);
                    if (cols.Contains(j))
                    {
                        cur.Add('.');
                    }
                }
                expanded1.Add(cur);
            }

            var expanded2 = new List<List<char>>();
            for (var i = 0; i < m; i++)
            {
                expanded2.Add(expanded1[i].Select(x => x).ToList());
                if (rows.Contains(i))
                {
                    expanded2.Add(expanded1[i].Select(x => x).ToList());
                }
            }

            return expanded2;
        }


        public int Total(List<string> inputs)
        {
            var original = inputs.Select(x => x.Select(y => y).ToList()).ToList();
            var expanded = expand(original);
            var pairs = findGalaxies(expanded);

            var ret = 0;
            Console.WriteLine($"Galaxies number: {pairs.Count}");
            for (int i = 0; i < pairs.Count; i++)
            {
                for (int j = i + 1; j < pairs.Count; j++)
                {
                    var distance = Math.Abs(pairs[j].Item1 - pairs[i].Item1) + Math.Abs(pairs[j].Item2 - pairs[i].Item2);
                    //Console.WriteLine($"({pairs[j].Item1}, {pairs[j].Item2}) & ({pairs[i].Item1}, {pairs[i].Item2}) => {distance}");
                    ret += distance;
                }
            }

            return ret;
        }
    }
}
