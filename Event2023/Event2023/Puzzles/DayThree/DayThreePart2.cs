namespace Event2023.Puzzles.DayThree
{
    public class DayThreePart2
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
            var gears = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (inputs[i][j] == '*')
                    {
                        gears.Add($"{i}_{j}", new List<int>());
                    }
                }
            }

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
                            foreach (var pair in positions)
                            {
                                if (adjacentToGear(gears, pair[0], pair[1], int.Parse(cur)))
                                {
                                    break;
                                }
                            }
                            cur = "";
                            positions = new List<List<int>>();
                        }
                    }
                }

                if (!string.IsNullOrEmpty(cur))
                {
                    foreach (var pair in positions)
                    {
                        if (adjacentToGear(gears, pair[0], pair[1], int.Parse(cur)))
                        {
                            break;
                        }
                    }
                }
            }

            foreach (var value in gears.Values)
            {
                if (value.Count == 2)
                {
                    Console.WriteLine($"{value[0]} * {value[1]}");
                    ret += value[0] * value[1];
                }
            }

            return ret;
        }

        bool adjacentToGear(Dictionary<string, List<int>> gears, int i, int j, int value)
        {
            foreach (var direction in _directions)
            {
                int r = i + direction[0];
                int c = j + direction[1];
                var key = $"{r}_{c}";

                if (gears.ContainsKey(key))
                {
                    gears[key].Add(value);
                    return true;
                }
            }

            return false;
        }
    }
}
