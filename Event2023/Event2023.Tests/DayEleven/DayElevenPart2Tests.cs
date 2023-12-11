using Event2023.Puzzles.DayEleven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event2023.Tests.DayEleven
{
    public class DayElevenPart2Tests
    {
        private DayElevenPart2 _solver = new DayElevenPart2();
        private List<string> _inputs = new List<string>
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
            };

        [Fact]
        public void Total_10_ReturnsDistances()
        {
            Assert.Equal(1030, _solver.Total(_inputs, 10));
        }

        [Fact]
        public void Total_100_ReturnsDistances()
        {
            Assert.Equal(8410, _solver.Total(_inputs, 100));
        }
    }
}
