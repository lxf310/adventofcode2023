namespace Event2023.Puzzles.DayFourteen
{
    public class DayFourteenPart1
    {
        public int Total(List<string> inputs)
        {
            var ret = 0;
            var m = inputs.Count;
            var n = inputs[0].Length;
            var memo = new List<int>();
            for (int j = 0; j < n; j++)
            {
                memo.Add(m);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (inputs[i][j] == '#')
                    {
                        memo[j] = m - i - 1;
                    }
                    else if (inputs[i][j] == 'O')
                    {
                        ret += memo[j];
                        --memo[j];
                    }
                }
            }

            return ret;
        }
    }
}
