using Event2023.Puzzles.DaySixteen;

namespace Event2023.Tests.DaySixteen
{
    public class DaySixteenPart1Tests
    {
        private DaySixteenPart1 _solver = new DaySixteenPart1();
        private List<string> _inputs = new List<string>
        {
            ".|...\\....",
            "|.-.\\.....",
            ".....|-...",
            "........|.",
            "..........",
            ".........\\",
            "..../.\\\\..",
            ".-.-/..|..",
            ".|....-|.\\",
            "..//.|...."
        };

        [Fact]
        public void Total_Part1()
        {
            Assert.Equal(46, _solver.Total(_inputs, false));
        }

        [Fact]
        public void Total_Part2()
        {
            Assert.Equal(51, _solver.Total(_inputs, true));
        }
    }
}
