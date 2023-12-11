namespace Event2023.Puzzles.DayEleven
{
    public abstract class DayElevenBase
    {
        protected List<Tuple<int, int>> findGalaxies(List<List<char>> map)
        {
            var pairs = new List<Tuple<int, int>>();
            for (var i = 0; i < map.Count; i++)
            {
                for (var j = 0; j < map[0].Count; j++)
                {
                    if (map[i][j] == '#')
                    {
                        pairs.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return pairs;
        }
    }
}
