namespace Event2023.Puzzles.DayFive
{
    public class DayFivePart2 : DayFiveBase
    {
        public long Total(List<string> inputs)
        {
            var seeds = inputs[0].Substring(7).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x.Trim())).Select(x => long.Parse(x.Trim())).ToList();

            var maps = ConvertToMaps(inputs);
            var ret = new List<long>();
            int tmp = 0;
            foreach (var map in maps)
            {
                tmp++;
                var newSeeds = new List<long>();
                var i = 0;
                while (true)
                {
                    if (i >= seeds.Count) break;
                    var flag = false; //Suppose that every step, we only store the minimum range for the next step.
                    foreach (var subMap in map)
                    {

                        if (seeds[i] + seeds[i + 1] <= subMap[1] || seeds[i] >= subMap[1] + subMap[2])
                        {
                            continue;
                        }
                        else
                        {
                            flag = true;
                            var left = Math.Max(seeds[i], subMap[1]);
                            var right = Math.Min(seeds[i] + seeds[i + 1] - 1, subMap[1] + subMap[2] - 1);

                            // we need to add the missing part back
                            var sleft = seeds[i];
                            var sright = seeds[i] + seeds[i + 1] - 1;
                            if (left > sleft)
                            {
                                seeds.Add(seeds[i]);
                                seeds.Add(left - seeds[i]);
                            }

                            if (right < sright)
                            {
                                seeds.Add(right + 1);
                                seeds.Add(sright - right);
                            }

                            newSeeds.Add(subMap[0] + (left - subMap[1]));
                            newSeeds.Add(right - left + 1);
                        }
                    }

                    if (!flag)
                    {
                        newSeeds.Add(seeds[i]);
                        newSeeds.Add(seeds[i + 1]);
                    }
                    i += 2;
                }
                seeds = newSeeds;

                //foreach (var n in seeds)
                //{
                //    Console.Write($", {n}");
                //}
                //Console.WriteLine();
            }

            return seeds.Where((item, index) => index % 2 == 0).Min();
        }
    }
}
