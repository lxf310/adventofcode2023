using Event2023.Puzzles.DaySeven;

namespace Event2023.Tests.DaySeven
{
    public class DaySevenPart2Tests
    {
        private DaySevenPart1 _solver = new DaySevenPart1();

        [Fact]
        public void GetLabel_ReturnsLabel()
        {
            Assert.Equal(Label.FiveOfAKind, _solver.GetLabel("AAAAJ"));
            Assert.Equal(Label.FiveOfAKind, _solver.GetLabel("AJJJJ"));
            Assert.Equal(Label.FourOfAKind, _solver.GetLabel("AAAJB"));
            Assert.Equal(Label.FourOfAKind, _solver.GetLabel("AJJJB"));
            Assert.Equal(Label.FiveOfAKind, _solver.GetLabel("AJJJA"));
            Assert.Equal(Label.FullHouse, _solver.GetLabel("AABBA"));
            Assert.Equal(Label.ThreeOfAKind, _solver.GetLabel("AABBC"));
            Assert.Equal(Label.FiveOfAKind, _solver.GetLabel("AAAJJ"));
            Assert.Equal(Label.FourOfAKind, _solver.GetLabel("AABJJ"));
            Assert.Equal(Label.FullHouse, _solver.GetLabel("AABBJ"));
            Assert.Equal(Label.TwoPair, _solver.GetLabel("AABBC"));
            Assert.Equal(Label.ThreeOfAKind, _solver.GetLabel("CABJJ"));
            Assert.Equal(Label.ThreeOfAKind, _solver.GetLabel("CAJAB"));
            Assert.Equal(Label.OnePair, _solver.GetLabel("ABCDJ"));
            Assert.Equal(Label.HighCard, _solver.GetLabel("ABCDE"));
        }

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(5905, _solver.Total(new List<string>
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
