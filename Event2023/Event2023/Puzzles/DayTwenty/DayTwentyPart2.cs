namespace Event2023.Puzzles.DayTwenty
{
    public class DayTwentyPart2
    {
        public long Total(List<string> inputs)
        {
            var modules = new Dictionary<string, Module>();
            IEnumerable<string> starts = null;
            string feedName = null;
            foreach (var input in inputs)
            {
                var temp = input.Split("->").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var from = temp[0].Trim();
                var tos = temp[1].Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                if (tos.Contains("rx"))
                {
                    if (feedName != null) throw new ArgumentException();
                    feedName = from.Substring(1);
                }

                if (from.StartsWith('%'))
                {
                    var m = new FlipFlopModule(from.Substring(1))
                    {
                        NextModuleName = tos
                    };

                    modules.Add(m.Name, m);
                }
                else if (from.StartsWith('&'))
                {
                    var m = new ConjuctionModule(from.Substring(1))
                    {
                        NextModuleName = tos
                    };

                    modules.Add(m.Name, m);
                }
                else if (from == "broadcaster")
                {
                    starts = tos;
                }
            }

            // update pre
            var seen = new Dictionary<string, int>();
            foreach (var fromName in modules.Keys)
            {
                foreach (var toName in modules[fromName].NextModuleName)
                {
                    if (modules.ContainsKey(toName) && modules[toName].Type == ModuleType.Conjunction)
                    {
                        modules[toName].PreModules.Add(fromName, PulseType.Low);
                    }

                    if (toName == feedName)
                    {
                        seen.Add(fromName, 0);
                    }
                }
            }

            // init
            var froms = new Queue<Item>();
            long cnt = 0;
            var circles = new Dictionary<string, long>();

            while (true)
            {
                cnt++;
                foreach (var start in starts)
                {
                    if (modules.ContainsKey(start))
                    {
                        froms.Enqueue(new Item
                        {
                            Cur = start,
                            Received = PulseType.Low,
                        });
                    }
                }

                // mimic one push
                while (froms.Any())
                {
                    var from = froms.Dequeue();

                    if (from.Cur == feedName && from.Received == PulseType.High)
                    {
                        seen[from.Pre]++;

                        if (!circles.ContainsKey(from.Pre))
                        {
                            circles.Add(from.Pre, cnt);
                        }

                        if (seen.Values.All(x => x > 0))
                        {
                            cnt = 1;
                            foreach (var circle in circles.Values)
                            {
                                cnt = cnt * circle / Helper.GCD(cnt, circle);
                            }
                            return cnt;
                        }
                    }

                    var pulseRet = modules[from.Cur].Action(from.Pre, from.Received, modules);
                    if (pulseRet == PulseType.None) continue;

                    foreach (var name in modules[from.Cur].NextModuleName)
                    {
                        if (modules.ContainsKey(name))
                        {
                            froms.Enqueue(new Item
                            {
                                Pre = from.Cur,
                                Cur = name,
                                Received = pulseRet
                            });
                        }
                    }
                }
            }
        }
    }
}
