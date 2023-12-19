namespace Event2023.Puzzles.DayNineteen
{
    public class DayNineteenPart2
    {
        private Dictionary<string, List<long>> copy(Dictionary<string, List<long>> src)
        {
            var des = new Dictionary<string, List<long>>();
            foreach (var key in src.Keys)
            {
                var temp = new List<long>();
                foreach (var v in src[key])
                {
                    temp.Add(v);
                }
                des.Add(key, temp);
            }
            return des;
        }

        private long cal(Dictionary<string, List<long>> categories, Dictionary<string, List<Rule>> workflows, string name = "in")
        {
            if (name == "R")
            {
                return 0;
            }

            if (name == "A")
            {
                long ret = 1;
                foreach (var c in categories.Values)
                {
                    ret *= (c[1] - c[0] + 1);
                }

                return ret;
            }

            long total = 0;
            foreach (var rule in workflows[name])
            {
                if (string.IsNullOrEmpty(rule.Op))
                {
                    total += cal(categories, workflows, rule.Name);
                    break;
                }
                else
                {
                    long ll, lr, hl, hr;
                    if (rule.Op == ">")
                    {
                        ll = rule.Value + 1;
                        lr = categories[rule.Category][1];

                        hl = categories[rule.Category][0];
                        hr = rule.Value;
                    }
                    else
                    {
                        ll = categories[rule.Category][0];
                        lr = rule.Value - 1;

                        hl = rule.Value;
                        hr = categories[rule.Category][1];
                    }

                    if (ll <= lr)
                    {
                        var cc = copy(categories);
                        cc[rule.Category] = new List<long> { ll, lr };
                        total += cal(cc, workflows, rule.Name);
                    }

                    if (hl <= hr)
                    {
                        categories[rule.Category] = new List<long> { hl, hr };
                    }
                }
            }

            return total;
        }

        public long Total(List<string> inputs)
        {
            // rfg{s<537:gd,x>2440:R,A}
            var workflows = new Dictionary<string, List<Rule>>();
            for (int i = 0; i < inputs.Count; i++)
            {
                if (string.IsNullOrEmpty(inputs[i]))
                {
                    break;
                }

                var key = inputs[i].Substring(0, inputs[i].IndexOf('{'));
                var rules = new List<Rule>();
                foreach (var workflow in inputs[i].Substring(inputs[i].IndexOf('{') + 1, inputs[i].Length - inputs[i].IndexOf('{') - 2).Split(','))
                {
                    if (workflow.Contains(':'))
                    {
                        var temp1 = workflow.Split(':');
                        if (temp1[0].Contains('>'))
                        {
                            rules.Add(new Rule(temp1[1])
                            {
                                Category = temp1[0].Split('>')[0],
                                Op = ">",
                                Value = long.Parse(temp1[0].Split('>')[1])
                            });
                        }
                        else if (temp1[0].Contains('<'))
                        {
                            rules.Add(new Rule(temp1[1])
                            {
                                Category = temp1[0].Split('<')[0],
                                Op = "<",
                                Value = long.Parse(temp1[0].Split('<')[1])
                            });
                        }
                    }
                    else
                    {
                        rules.Add(new Rule(workflow));
                    }
                }

                workflows.Add(key, rules);
            }

            var ret = cal(new Dictionary<string, List<long>>
            {
                { "x", new List<long> { 1, 4000 } },
                { "m", new List<long> { 1, 4000 } },
                { "a", new List<long> { 1, 4000 } },
                { "s", new List<long> { 1, 4000 } },
            }, workflows);

            return ret;
        }
    }
}
