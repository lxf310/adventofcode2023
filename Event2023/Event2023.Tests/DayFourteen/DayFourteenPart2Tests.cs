using Event2023.Puzzles.DayFourteen;

namespace Event2023.Tests.DayFourteen
{
    public class DayFourteenPart2Tests
    {
        private DayFourteenPart2 _solver = new DayFourteenPart2();

        [Fact]
        public void Total_ReturnsLoad()
        {
            Assert.Equal(64, _solver.Total(new List<string>
            {
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            }));
        }
    }
}
