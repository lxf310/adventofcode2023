using Event2023.Puzzles.DayTwelve;

namespace Event2023.Tests.DayTwelve
{
    public class DayTwelvePart2Tests
    {
        private DayTwelvePart2 _solver = new DayTwelvePart2();

        [Fact]
        public void Total_ReturnsTotalPossibilities()
        {
            Assert.Equal(525152, _solver.Total(new List<string>
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
