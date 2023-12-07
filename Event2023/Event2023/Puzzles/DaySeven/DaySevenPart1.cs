namespace Event2023.Puzzles.DaySeven
{
    public class DaySevenPart1 : DaySevenBase
    {
        public override Label GetLabel(string card)
        {
            var cnts = new Dictionary<char, int>();
            foreach (var ch in card)
            {
                if (cnts.ContainsKey(ch))
                {
                    cnts[ch]++;
                }
                else
                {
                    cnts.Add(ch, 1);
                }
            }

            if (cnts.Values.Contains(5))
            {
                return Label.FiveOfAKind;
            }

            if (cnts.Values.Contains(4))
            {
                return Label.FourOfAKind;
            }

            if (cnts.Values.Contains(3))
            {
                if (cnts.Values.Contains(2))
                {
                    return Label.FullHouse;
                }
                return Label.ThreeOfAKind;
            }

            if (cnts.Values.Where(x => x == 2).Count() == 2)
            {
                return Label.TwoPair;
            }

            if (cnts.Values.Where(x => x == 2).Count() == 1)
            {
                return Label.OnePair;
            }

            return Label.HighCard;
        }

        public int Total(List<string> lines)
        {
            return Total(lines, new Dictionary<char, int>
            {
                { 'A', 14 },
                { 'K', 13 },
                { 'Q', 12 },
                { 'J', 11 },
                { 'T', 10 },
                { '9', 9 },
                { '8', 8 },
                { '7', 7 },
                { '6', 6 },
                { '5', 5 },
                { '4', 4 },
                { '3', 3 },
                { '2', 2 },
            });
        }
    }
}
