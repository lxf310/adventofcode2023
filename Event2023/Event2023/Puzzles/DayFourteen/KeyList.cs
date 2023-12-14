namespace Event2023.Puzzles.DayFourteen
{
    public class KeyList : List<List<char>>, IEquatable<KeyList>
    {
        public bool Equals(KeyList? other)
        {
            var m = Count;
            if (other.Count != m)
            {
                return false;
            }

            if (m > 0)
            {
                var n = this[0].Count;
                if (other[0].Count != n)
                {
                    return false;
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (this[i][j] != other[i][j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
