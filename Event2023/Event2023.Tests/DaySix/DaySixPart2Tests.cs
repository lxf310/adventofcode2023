using Event2023.Puzzles.DaySix;

namespace Event2023.Tests.DaySix
{
    public class DaySixPart2Tests
    {
        private DaySixPart2 _solver = new DaySixPart2();

        [Fact]
        public void Possibility_TotalTimeIsEven_ReturnsResult()
        {
            Assert.Equal(71503, _solver.Possibility(new List<string>
            {
                "Time:      7  15   30",
                "Distance:  9  40  200"
            }));
        }


        [Fact]
        public void Possibility_TotalTimeIsOdd_ReturnsResult()
        {
            Assert.Equal(81507, _solver.Possibility(new List<string>
            {
                "Time:      8  15   30",
                "Distance:  9  40  200"
            }));
        }
    }
}
