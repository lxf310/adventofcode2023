using System.Diagnostics.CodeAnalysis;

namespace Event2023.Puzzles.DayFourteen
{
    public class MyComparer : IEqualityComparer<List<List<char>>>
    {
        public bool Equals(List<List<char>>? x, List<List<char>>? y)
        {
            var m = x.Count;
            if (y.Count != m)
            {
                return false;
            }

            if (m > 0)
            {
                var n = x[0].Count;
                if (y[0].Count != n)
                {
                    return false;
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (x[i][j] != y[i][j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] List<List<char>> obj)
        {
            return 0;
        }
    }
}
