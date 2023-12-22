namespace Event2023.Puzzles.DayTwentyOne
{
    public class DayTwentyOnePart1
    {
        private List<Tuple<int, int>> _directions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(0, -1),
            };

        public long Total(List<string> inputs, int cnt)
        {
            var memo = new HashSet<Tuple<int, int>>();
            var m = inputs.Count;
            var n = inputs[0].Length;

            Tuple<int, int> start = null;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (inputs[i][j] == 'S')
                    {
                        start = new Tuple<int, int>(i, j);
                        break;
                    }
                }

                if (start != null)
                {
                    break;
                }
            }

            memo.Add(start);

            while (cnt-- > 0 && memo.Any())
            {
                var temp = new HashSet<Tuple<int, int>>();
                foreach (var pos in memo)
                {
                    foreach (var direction in _directions)
                    {
                        var ii = pos.Item1 + direction.Item1;
                        var jj = pos.Item2 + direction.Item2;
                        if (ii >= 0 && ii < m && jj >= 0 && jj < n && inputs[ii][jj] != '#')
                        {
                            temp.Add(new Tuple<int, int>(ii, jj));
                        }
                    }
                }

                memo = temp;
            }

            return memo.LongCount();
        }
    }
}
