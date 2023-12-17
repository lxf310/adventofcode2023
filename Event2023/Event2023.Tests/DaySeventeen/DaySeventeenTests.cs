using Event2023.Puzzles.DaySeventeen;

namespace Event2023.Tests.DaySeventeen
{
    public class DaySeventeenTests
    {
        private DaySeventeenPart1 _solver = new DaySeventeenPart1();
        private List<string> _inputs = new List<string>
        {
            "2413432311323",
            "3215453535623",
            "3255245654254",
            "3446585845452",
            "4546657867536",
            "1438598798454",
            "4457876987766",
            "3637877979653",
            "4654967986887",
            "4564679986453",
            "1224686865563",
            "2546548887735",
            "4322674655533"
        };

        [Fact]
        public void Total_Part1()
        {
            Assert.Equal(102, _solver.Total(_inputs));
        }

        [Fact]
        public void Total_Part2()
        {
            Assert.Equal(94, _solver.Total(_inputs, true));
        }
    }
}
