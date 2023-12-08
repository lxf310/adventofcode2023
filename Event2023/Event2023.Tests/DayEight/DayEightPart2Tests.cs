using Event2023.Puzzles.DayEight;

namespace Event2023.Tests.DayEight
{
    public class DayEightPart2Tests
    {
        private DayEightPart2 _solver = new DayEightPart2();

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(6, _solver.Total(new List<string>
            {
                "LR",
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)"
            }));
        }
    }
}
