namespace Event2023.Puzzles.DayThree
{
    public class DayThreePart1
    {
        private List<List<int>> _directions = new List<List<int>>
        {
            new List<int> { -1, 0 },
            new List<int> { -1, -1 },
            new List<int> { -1, 1 },
            new List<int> { 0, -1 },
            new List<int> { 0, 1 },
            new List<int> { 1, -1 },
            new List<int> { 1, 0 },
            new List<int> { 1, 1 },
        };

        public int Total(List<string> inputs)
        {
            int n = inputs.Count();
            int m = inputs[0].Length;
            int ret = 0;
            for (int i = 0; i < n; i++)
            {
                var positions = new List<List<int>>();
                var cur = "";
                for (int j = 0; j < m; j++)
                {
                    if (char.IsDigit(inputs[i][j]))
                    {
                        cur += inputs[i][j];
                        positions.Add(new List<int> { i, j });
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cur))
                        {
                            //Console.WriteLine($"number: {cur}");
                            if (isNumber(positions, inputs, n, m))
                            {
                                //Console.WriteLine(cur);
                                ret += int.Parse(cur);
                            }
                            cur = "";
                            positions = new List<List<int>>();
                        }
                    }
                }

                if (!string.IsNullOrEmpty(cur))
                {
                    if (isNumber(positions, inputs, n, m))
                    {
                        //Console.WriteLine(cur);
                        ret += int.Parse(cur);
                    }
                }
            }

            return ret;
        }

        private bool isNumber(List<List<int>> positions, List<string> inputs, int n, int m)
        {
            foreach (var pair in positions)
            {
                foreach (var direction in _directions)
                {
                    int r = pair[0] + direction[0];
                    int c = pair[1] + direction[1];
                    if (r >= 0 && r < n && c >= 0 && c < m && !char.IsDigit(inputs[r][c]) && inputs[r][c] != '.')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
