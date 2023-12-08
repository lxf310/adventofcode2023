using Event2023.Puzzles.DayEight;

namespace Event2023.Tests.DayEight
{
    public class DayEightPart1Tests
    {
        private DayEightPart1 _solver = new DayEightPart1();

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(2, _solver.Total(new List<string>
            {
                "RL",
                "AAA = (BBB, CCC)",
                "BBB = (DDD, EEE)",
                "CCC = (ZZZ, GGG)",
                "DDD = (DDD, DDD)",
                "EEE = (EEE, EEE)",
                "GGG = (GGG, GGG)",
                "ZZZ = (ZZZ, ZZZ)"
            }));


            Assert.Equal(6, _solver.Total(new List<string>
            {
                "LLR",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)"
            }));
        }
    }
}
