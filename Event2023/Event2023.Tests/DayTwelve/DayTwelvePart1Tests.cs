using Event2023.Puzzles.DayTwelve;

namespace Event2023.Tests.DayTwelve
{
    public class DayTwelvePart1Tests
    {
        private DayTwelvePart1 _solver = new DayTwelvePart1();

        [Fact]
        public void Total_ReturnsTotalPossibilities()
        {
            Assert.Equal(21, _solver.Total(new List<string>
            {
                "???.### 1,1,3",
                ".??..??...?##. 1,1,3",
                "?#?#?#?#?#?#?#? 1,3,1,6",
                "????.#...#... 4,1,1",
                "????.######..#####. 1,6,5",
                "?###???????? 3,2,1"
            }));
        }
    }
}
