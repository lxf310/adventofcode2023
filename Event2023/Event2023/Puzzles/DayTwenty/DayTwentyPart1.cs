namespace Event2023.Puzzles.DayTwenty
{
    public class DayTwentyPart1
    {
        public long Total(List<string> inputs)
        {
            var modules = new Dictionary<string, Module>();
            IEnumerable<string> starts = null;
            foreach (var input in inputs)
            {
                var temp = input.Split("->").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var from = temp[0].Trim();
                var tos = temp[1].Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

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
            foreach (var fromName in modules.Keys)
            {
                foreach (var toName in modules[fromName].NextModuleName)
                {
                    if (modules.ContainsKey(toName) && modules[toName].Type == ModuleType.Conjunction)
                    {
                        modules[toName].PreModules.Add(fromName, PulseType.Low);
                    }
                }
            }

            long low = 0;
            long high = 0;
            // init
            var froms = new Queue<Item>();

            for (int i = 0; i < 1000; i++)
            {
                low++; // caused by pushing button
                foreach (var start in starts)
                {
                    if (modules.ContainsKey(start))
                    {
                        low++; // caused by broadcaster
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

                    var pulseRet = modules[from.Cur].Action(from.Pre, from.Received, modules);
                    if (pulseRet == PulseType.None) continue;

                    foreach (var name in modules[from.Cur].NextModuleName)
                    {
                        if (pulseRet == PulseType.Low) low++;
                        if (pulseRet == PulseType.High) high++;

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

            Console.WriteLine($"low={low}, high={high}");
            return low * high;
        }
    }
}
