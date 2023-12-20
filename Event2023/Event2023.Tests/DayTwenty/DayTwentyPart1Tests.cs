using Event2023.Puzzles.DayTwenty;

namespace Event2023.Tests.DayTwenty
{
    public class DayTwentyPart1Tests
    {
        private DayTwentyPart1 _solver = new DayTwentyPart1();

        [Fact]
        public void Total_Case1()
        {
            Assert.Equal(32000000, _solver.Total(new List<string>
            {
                "broadcaster -> a, b, c",
                "%a -> b",
                "%b -> c",
                "%c -> inv",
                "&inv -> a"
            }));
        }

        [Fact]
        public void Total_Case2()
        {
            Assert.Equal(11687500, _solver.Total(new List<string>
            {
                "broadcaster -> a",
                "%a -> inv, con",
                "&inv -> b",
                "%b -> con",
                "&con -> output"
            }));
        }
    }
}
