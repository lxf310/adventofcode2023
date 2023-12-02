using Event2023.Puzzles.DayTwo;

namespace Event2023.Tests.DayTwo
{
    public class DayTwoPart1Tests
    {
        [Fact]
        public void PossibleId_DeafultConfiguration_Impossible_ReturnsMinusOne()
        {
            var solver = new DayTwoPart1();
            Assert.Equal(-1, solver.PossibleId("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"));
        }

        [Fact]
        public void PossibleId_DeafultConfiguration_Possible_ReturnsGameId()
        {
            var solver = new DayTwoPart1();
            Assert.Equal(2, solver.PossibleId("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"));
        }

        [Fact]
        public void PossibleId_SpecifiedConfiguration_Impossible_ReturnsMinusOne()
        {
            var solver = new DayTwoPart1(new Dictionary<string, int>
            {
                { "red", 1},
                { "green", 2 },
                { "blue", 4 }

            });
            Assert.Equal(-1, solver.PossibleId("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"));
        }

        [Fact]
        public void PossibleId_SpecifiedConfiguration_Possible_ReturnsGameId()
        {
            var solver = new DayTwoPart1(new Dictionary<string, int>
            {
                { "red", 21},
                { "green", 13 },
                { "blue", 6 }

            });
            Assert.Equal(3, solver.PossibleId("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"));
        }

        [Fact]
        public void Total_ReturnsTotalPossible()
        {
            var solver = new DayTwoPart1();
            Assert.Equal(8, solver.Total(new List<string>
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            }));
        }
    }
}
