namespace Event2023.Puzzles.DayNineteen
{
    public class DayNineteenPart1
    {
        private bool accespted(Dictionary<string, int> rating, Dictionary<string, List<string>> workflows)
        {
            string cur = "in";
            while (cur != "A" && cur != "R")
            {
                foreach (var workflow in workflows[cur])
                {
                    if (workflow.Contains(':'))
                    {
                        var temp1 = workflow.Split(':');
                        string category;
                        int value;
                        if (temp1[0].Contains('>'))
                        {
                            category = temp1[0].Split('>')[0];
                            value = int.Parse(temp1[0].Split('>')[1]);
                            if (rating.ContainsKey(category) && rating[category] > value)
                            {
                                cur = temp1[1];
                                break;
                            }
                        }
                        else if (temp1[0].Contains('<'))
                        {
                            category = temp1[0].Split('<')[0];
                            value = int.Parse(temp1[0].Split('<')[1]);
                            if (rating.ContainsKey(category) && rating[category] < value)
                            {
                                cur = temp1[1];
                                break;
                            }
                        }
                    }
                    else
                    {
                        cur = workflow;
                        break;
                    }
                }
            }

            return cur == "A";
        }

        public int Total(List<string> inputs)
        {
            // rfg{s<537:gd,x>2440:R,A}
            var workflows = new Dictionary<string, List<string>>();
            int i = 0;
            for (; i < inputs.Count; i++)
            {
                if (string.IsNullOrEmpty(inputs[i]))
                {
                    break;
                }

                workflows.Add(inputs[i].Substring(0, inputs[i].IndexOf('{')), inputs[i].Substring(inputs[i].IndexOf('{') + 1, inputs[i].Length - inputs[i].IndexOf('{') - 2).Split(',').ToList());
            }
            i++;

            var ret = 0;

            // {x=787,m=2655,a=1222,s=2876}
            for (; i < inputs.Count; i++)
            {
                var dict = new Dictionary<string, int>();
                foreach (var item in inputs[i].Substring(1, inputs[i].Length - 2).Split(','))
                {
                    var temp = item.Split('=');
                    dict.Add(temp[0], int.Parse(temp[1]));
                }

                if (accespted(dict, workflows))
                {
                    //Console.WriteLine(inputs[i]);
                    foreach (var v in dict.Values)
                    {
                        ret += v;
                    }
                }
            }

            return ret;
        }
    }
}
