using Event2023.Puzzles.DaySeven;

namespace Event2023.Tests.DaySeven
{
    public class DaySeventPart1Tests
    {
        private DaySevenPart1 _solver = new DaySevenPart1();

        [Fact]
        public void GetLabel_ReturnsLabel()
        {
            Assert.Equal(Label.FiveOfAKind, _solver.GetLabel("AAAAA"));
            Assert.Equal(Label.FourOfAKind, _solver.GetLabel("AABAA"));
            Assert.Equal(Label.FullHouse, _solver.GetLabel("AAABB"));
            Assert.Equal(Label.ThreeOfAKind, _solver.GetLabel("AAABC"));
            Assert.Equal(Label.TwoPair, _solver.GetLabel("AACBB"));
            Assert.Equal(Label.OnePair, _solver.GetLabel("AACBD"));
            Assert.Equal(Label.HighCard, _solver.GetLabel("ABCD"));
        }

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(6440, _solver.Total(new List<string>
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "TJJT 220",
                "QQQJA 483"
            }));
        }
    }
}
