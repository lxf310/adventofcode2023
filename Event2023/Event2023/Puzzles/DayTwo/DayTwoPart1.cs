namespace Event2023.Puzzles.DayTwo
{
    public class DayTwoPart1
    {
        private readonly Dictionary<string, int> _configuration;

        public DayTwoPart1(Dictionary<string, int> configuration = null)
        {
            _configuration = configuration ?? new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13},
            { "blue", 14 }
        };
        }

        public int PossibleId(string line)
        {
            //Game 7: 3 blue, 1 red; 3 blue, 10 green; 4 green, 5 blue
            int id = int.Parse(line.Substring(5, line.IndexOf(':') - 5));
            var itemStrs = line.Substring(line.IndexOf(':') + 1).Split(';');
            foreach (var itemStr in itemStrs)
            {
                var cubeStrs = itemStr.Split(',');
                foreach (var cubeStr in cubeStrs)
                {
                    var cube = cubeStr.Trim().Split(' ');
                    if (int.Parse(cube[0]) > _configuration[cube[1]])
                    {
                        //Console.WriteLine($"Impossible: {id}");
                        return -1;
                    }
                }
            }

            return id;
        }

        public int Total(List<string> lines)
        {
            var ret = 0;
            foreach (var line in lines)
            {
                var id = PossibleId(line);
                if (id != -1)
                {
                    ret += id;
                }
            }

            return ret;
        }
    }
}
