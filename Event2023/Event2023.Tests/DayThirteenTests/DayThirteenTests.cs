using Event2023.Puzzles.DayThirteen;

namespace Event2023.Tests.DayThirteenTests
{
    public class DayThirteenTests
    {
        private DayThirteen _solver = new DayThirteen();
        private List<string> _inputs = new List<string>
        {
            "#.##..##.",
            "..#.##.#.",
            "##......#",
            "##......#",
            "..#.##.#.",
            "..##..##.",
            "#.#.##.#.",
            "",
            "#...##..#",
            "#....#..#",
            "..##..###",
            "#####.##.",
            "#####.##.",
            "..##..###",
            "#....#..#"
        };

        [Fact]
        public void Total_Part1_ReturnsResult()
        {
            Assert.Equal(405, _solver.Total(_inputs, false));
        }

        [Fact]
        public void Total_Part2_ReturnsResult()
        {
            Assert.Equal(400, _solver.Total(_inputs, true));
        }
    }
}
