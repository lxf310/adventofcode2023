using Event2023.Puzzles.DayTen;

namespace Event2023.Tests.DayTen
{
    public class DayTenPart2Tests
    {
        private DayTenPart2 _solver = new DayTenPart2();

        [Fact]
        public void Total_Case1()
        {
            Assert.Equal(4, _solver.Total(new List<string>
            {
                "...........",
                ".S-------7.",
                ".|F-----7|.",
                ".||.....||.",
                ".||.....||.",
                ".|L-7.F-J|.",
                ".|..|.|..|.",
                ".L--J.L--J.",
                "..........."
            }));
        }
    }
}
