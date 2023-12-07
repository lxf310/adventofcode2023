namespace Event2023.Puzzles.DaySeven
{
    public class Hand : IComparable<Hand>
    {
        public Hand(Dictionary<char, int> orders)
        {
            Orders = orders;
        }

        public string Card { get; set; }
        public int Bid { get; set; }
        public Label Label { get; set; }

        public Dictionary<char, int> Orders { get; init; }

        int IComparable<Hand>.CompareTo(Hand? second)
        {
            if (Label != second.Label)
            {
                return second.Label - Label;
            }

            for (int i = 0; i < 5; i++)
            {
                if (Card[i] != second.Card[i])
                {
                    return Orders[Card[i]] - Orders[second.Card[i]];
                }
            }

            return 0;
        }
    }
}
