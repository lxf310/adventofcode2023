using Event2023.Puzzles.DayTen;

namespace Event2023.Tests.DayTen
{
    public class DayTenPart1Tests
    {
        private DayTenPart1 _solver = new DayTenPart1();

        [Fact]
        public void Total_Case1()
        {
            Assert.Equal(4, _solver.Total(new List<string>
            {
                ".....",
                ".S-7.",
                ".|.|.",
                ".L-J.",
                "....."
            }));
        }


        [Fact]
        public void Total_Case2()
        {
            Assert.Equal(8, _solver.Total(new List<string>
            {
                "..F7.",
                ".FJ|.",
                "SJ.L7",
                "|F--J",
                "LJ..."
            }));
        }
    }
}
