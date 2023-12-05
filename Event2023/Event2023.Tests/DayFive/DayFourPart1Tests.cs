using Event2023.Puzzles.DayFive;

namespace Event2023.Tests.DayFive
{
    public class DayFourPart1Tests
    {
        private DayFivePart1 _solver = new DayFivePart1();

        [Fact]
        public void Next_ReturnsLocation()
        {
            var maps = new List<List<List<long>>>
            {
                new List<List<long>>
                {
                    new List<long> { 50, 98, 2},
                    new List<long> { 52, 50, 48},
                },
                new List<List<long>>
                {
                    new List<long> { 0, 15, 37},
                    new List<long> { 37, 52, 2},
                    new List<long> { 39, 0, 15},
                },
                new List<List<long>>
                {
                    new List<long> { 49, 33, 6},
                    new List<long> { 100, 50, 48},
                }
            };

            Assert.Equal(54, _solver.Next(51, maps, 0));
        }

        [Fact]
        public void Total_ReturnsResult()
        {
            Assert.Equal(35, _solver.Total(new List<string>
            {
                "seeds: 79 14 55 13",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
                "soil-to-fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "fertilizer-to-water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "water-to-light map:",
                "88 18 7",
                "18 25 70",
                "light-to-temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "temperature-to-humidity map:",
                "0 69 1",
                "1 0 69",
                "humidity-to-location map:",
                "60 56 37",
                "56 93 4"
            }));
        }
    }
}
