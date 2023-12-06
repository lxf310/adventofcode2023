using Event2023.Puzzles.DaySix;

namespace Event2023.Tests.DaySix
{
    public class DaySixPart1Tests
    {
        private DaySixPart1 _solver = new DaySixPart1();

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(288, _solver.Total(new List<string>
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            }));
        }
    }
}
