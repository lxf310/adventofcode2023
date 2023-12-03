using Event2023.Puzzles.DayThree;

namespace Event2023.Tests.DayThree
{
    public class DayThreePart2Tests
    {
        [Fact]
        public void Total_ReturnsResult()
        {
            var solver = new DayThreePart2();
            Assert.Equal(467835, solver.Total(new List<string>
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            }));
        }
    }
}
