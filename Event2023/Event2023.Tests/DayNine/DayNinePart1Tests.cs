using Event2023.Puzzles.DayNine;

namespace Event2023.Tests.DayNine
{
    public class DayNinePart1Tests
    {
        private DayNinePart1 _solver = new DayNinePart1();

        [Fact]
        public void Next_ReturnsNext()
        {
            Assert.Equal(18, _solver.Next(new List<int> { 0, 3, 6, 9, 12, 15 }));
            Assert.Equal(28, _solver.Next(new List<int> { 1, 3, 6, 10, 15, 21 }));
            Assert.Equal(68, _solver.Next(new List<int> { 10, 13, 16, 21, 30, 45 }));
        }

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(114, _solver.Total(new List<string>
            {
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45"
            }));
        }
    }
}
