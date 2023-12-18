namespace Event2023.Puzzles.DayEighteen
{
    public class DayEighteenPart2
    {
        private Dictionary<char, int> mapping = new Dictionary<char, int>
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 },
        };

        private Tuple<int, int> dToI(string direction)
        {
            return direction switch
            {
                "U" => new Tuple<int, int>(-1, 0),
                "R" => new Tuple<int, int>(0, 1),
                "D" => new Tuple<int, int>(1, 0),
                "L" => new Tuple<int, int>(0, -1),
            };
        }

        private string iToD(char i)
        {
            return i switch
            {
                '0' => "R",
                '1' => "D",
                '2' => "L",
                '3' => "U"
            };
        }

        public int hexToDec(string src)
        {
            var ret = 0;
            for (int i = 2; i < src.Length - 2; i++)
            {
                ret = (ret * 16) + mapping[src[i]];
            }
            return ret;
        }

        public long Total(List<string> inputs)
        {
            var r = 0;
            var c = 0;
            long boundary = 0;

            var steps = new List<Step> { new Step { Row = 0, Col = 0 } };

            foreach (var line in inputs)
            {
                var l = line.Split(' ');

                var d = iToD(l[2][7]);
                var walk = dToI(d);
                var meters = hexToDec(l[2]);
                boundary += meters;

                r += walk.Item1 * meters;
                c += walk.Item2 * meters;
                steps.Add(new Step { Row = r, Col = c });
            }

            var n = steps.Count;
            long A = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    A += (long)steps[i].Row * ((long)steps[n - 1].Col - (long)steps[(i + 1) % n].Col);
                }
                else
                {
                    A += (long)steps[i].Row * ((long)steps[i - 1].Col - (long)steps[(i + 1) % n].Col);
                }
            }

            var ret = Math.Abs(A) / 2 - boundary / 2 + 1 + boundary;
            return ret;
        }
    }
}
