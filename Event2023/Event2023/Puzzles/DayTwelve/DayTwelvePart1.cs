namespace Event2023.Puzzles.DayTwelve
{
    public class DayTwelvePart1
    {
        private bool possible(string candidates, int pos0, int pos1, int cnt, List<int> numbers, ref int possibilities, List<char> cur)
        {
            if (pos0 >= candidates.Length)
            {
                if (pos1 == numbers.Count - 1 && cnt == numbers[pos1] || pos1 == numbers.Count)
                {
                    //Console.WriteLine(string.Join("", cur));
                    possibilities++;
                    return true;
                }

                return false;
            }

            if (pos1 >= numbers.Count)
            {
                if (candidates.Substring(pos0).Contains('#'))
                {
                    // too many #
                    return false;
                }

                //Console.WriteLine(string.Join("", cur));
                possibilities++;
                return true;
            }

            var ch = candidates[pos0];
            if (ch == '.')
            {
                if (cnt != 0 && cnt != numbers[pos1])
                {
                    return false;
                }

                return (cnt == numbers[pos1]) ? possible(candidates, pos0 + 1, pos1 + 1, 0, numbers, ref possibilities, cur) : possible(candidates, pos0 + 1, pos1, cnt, numbers, ref possibilities, cur);
            }

            if (ch == '#')
            {
                if (cnt >= numbers[pos1])
                {
                    return false;
                }

                return possible(candidates, pos0 + 1, pos1, cnt + 1, numbers, ref possibilities, cur);
            }

            cur[pos0] = '.';
            var operational = false;
            if (cnt == 0)
            {
                operational = possible(candidates, pos0 + 1, pos1, cnt, numbers, ref possibilities, cur);
            }
            else if (cnt == numbers[pos1])
            {
                operational = possible(candidates, pos0 + 1, pos1 + 1, 0, numbers, ref possibilities, cur);
            }

            if (cnt >= numbers[pos1])
            {
                cur[pos0] = ch;
                return operational;
            }

            cur[pos0] = '#';
            var damadged = possible(candidates, pos0 + 1, pos1, cnt + 1, numbers, ref possibilities, cur);

            cur[pos0] = ch;
            return operational || damadged;
        }

        public int Total(List<string> lines)
        {
            var ret = 0;
            foreach (var line in lines)
            {
                // ???.### 1,1,3
                var input = line.Split(' ');
                var numbers = input[1].Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => int.Parse(x)).ToList();
                var curCnt = 0;
                possible(input[0], 0, 0, 0, numbers, ref curCnt, input[0].Select(x => x).ToList());
                Console.WriteLine($"cnt = {curCnt}");
                ret += curCnt;
            }

            return ret;
        }
    }
}
