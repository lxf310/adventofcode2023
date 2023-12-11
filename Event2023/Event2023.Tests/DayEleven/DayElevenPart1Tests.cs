using Event2023.Puzzles.DayEleven;

namespace Event2023.Tests.DayEleven
{
    public class DayElevenPart1Tests
    {
        private DayElevenPart1 _solver = new DayElevenPart1();

        [Fact]
        public void Total_ReturnsDistances()
        {
            Assert.Equal(374, _solver.Total(new List<string>
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            }));
        }
    }
}
