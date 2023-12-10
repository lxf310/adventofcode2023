namespace Event2023.Puzzles.DayTen
{
    public abstract class DayTenBase
    {
        protected Tuple<int, int> findStart(List<List<char>> maps, int m, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (maps[i][j] == 'S')
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }

            return new Tuple<int, int>(-1, -1);
        }
    }
}
