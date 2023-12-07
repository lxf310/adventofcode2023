namespace Event2023.Puzzles.DaySeven
{
    public abstract class DaySevenBase
    {
        public abstract Label GetLabel(string card);

        protected int Total(List<string> lines, Dictionary<char, int> orders)
        {
            var inputs = new List<Hand>();
            foreach (var line in lines)
            {
                var l = line.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                inputs.Add(new Hand(orders)
                {
                    Card = l[0],
                    Bid = int.Parse(l[1]),
                    Label = GetLabel(l[0])
                });
            }

            inputs.Sort();
            var ret = 0;
            for (int i = inputs.Count - 1; i >= 0; i--)
            {
                ret += (i + 1) * inputs[i].Bid;
            }
            return ret;
        }
    }
}
