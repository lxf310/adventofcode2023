namespace Event2023.Puzzles.DayTwo
{
    public class DayTwoPart2
    {
        public int MinCubeMultiply(string line)
        {
            //Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            var itemStrs = line.Substring(line.IndexOf(':') + 1).Split(';');
            var cubes = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };

            foreach (var itemStr in itemStrs)
            {
                var cubeStrs = itemStr.Split(',');
                foreach (var cubeStr in cubeStrs)
                {
                    var cube = cubeStr.Trim().Split(' ');
                    var required = int.Parse(cube[0]);
                    if (cubes[cube[1]] < required)
                    {
                        cubes[cube[1]] = required;
                    }
                }
            }

            int ret = 1;
            foreach (var value in cubes.Values)
            {
                if (value != 0)
                {
                    ret *= value;
                }
            }

            return ret;
        }

        public int Total(List<string> lines)
        {
            int ret = 0;
            foreach (var line in lines)
            {
                ret += MinCubeMultiply(line);
            }

            return ret;
        }
    }
}
