namespace Event2023.Puzzles.DayFour
{
    public class DayFourPart1 : DayFourBase
    {
        public int Calculate(string line)
        {
            var input = line.Substring(line.IndexOf(':') + 1).Trim().Split('|');
            var winNumbers = fillList(input[0]);
            var myNumbers = fillList(input[1]);

            var flag = false;
            var ret = 1;
            foreach (var number in myNumbers)
            {
                if (winNumbers.Contains(number))
                {
                    if (!flag)
                    {
                        flag = true;
                    }
                    else
                    {
                        ret *= 2;
                    }
                }
            }

            return flag ? ret : 0;
        }


        public int Total(List<string> lines)
        {
            int ret = 0;
            foreach (var line in lines)
            {
                ret += Calculate(line);
            }

            return ret;
        }
    }
}
