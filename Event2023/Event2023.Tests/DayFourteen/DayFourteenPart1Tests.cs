using Event2023.Puzzles.DayFourteen;

namespace Event2023.Tests.DayFourteen
{
    public class DayFourteenPart1Tests
    {
        private DayFourteenPart1 _solver = new DayFourteenPart1();

        [Fact]
        public void Total_ReturnsLoad()
        {
            Assert.Equal(136, _solver.Total(new List<string>
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
