using Event2023.Puzzles.DayEleven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event2023.Tests.DayEleven
{
    public class DayElevenPart1Tests
    {
        private DayElevenPart1 _solver = new DayElevenPart1();

        [Fact]
        public void Total_ReturnsDistances()
        {
            Assert.Equal(374, _solver.Total(new List<string>
            {
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            }));
        }
    }
}
