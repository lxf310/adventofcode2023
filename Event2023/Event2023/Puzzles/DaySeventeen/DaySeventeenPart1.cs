namespace Event2023.Puzzles.DaySeventeen
{
    public class DaySeventeenPart1
    {
        public int Total(List<string> inputs, bool isPart2 = false)
        {
            int m = inputs.Count;
            int n = inputs[0].Length;
            var directions = new List<List<int>> // 顺时针旋转
            {
                new List<int>{ -1, 0 },
                new List<int>{ 0, 1 },
                new List<int>{ 1, 0 },
                new List<int>{ 0, -1 },
            };

            var visited = new Dictionary<string, int>();
            var walk = new PriorityQueue<Step, int>();
            walk.Enqueue(new Step
            {
                Row = 0,
                Col = 0,
                Direction = -1,
                Cnt = -1,
                Cost = 0
            }, 0);

            while (walk.Count > 0)
            {
                var cur = walk.Dequeue();
                if (visited.ContainsKey(cur.Key))
                {
                    if (cur.Cost < visited[cur.Key]) throw new Exception();
                    continue;
                }

                visited.Add(cur.Key, cur.Cost);
                for (int i = 0; i < 4; i++)
                {
                    var r = cur.Row + directions[i][0];
                    var c = cur.Col + directions[i][1];

                    var notReverse = (i + 2) % 4 != cur.Direction;
                    var newCnt = i == cur.Direction ? cur.Cnt + 1 : 1;

                    if (r >= 0 && r < m && c >= 0 && c < n && notReverse &&
                        (!isPart2 && newCnt <= 3 ||
                        isPart2 && newCnt <= 10 && (cur.Direction == -1 || cur.Direction == i || cur.Cnt >= 4)))
                    {
                        var cost = cur.Cost + (int)inputs[r][c] - 48;
                        walk.Enqueue(new Step
                        {
                            Row = r,
                            Col = c,
                            Cost = cost,
                            Direction = i,
                            Cnt = newCnt
                        }, cost);
                    }
                }
            }

            var ret = int.MaxValue;
            foreach (var key in visited.Keys)
            {
                if (key.StartsWith($"{m - 1}_{n - 1}_"))
                {
                    ret = Math.Min(ret, visited[key]);
                }
            }

            return ret;
        }
    }
}
