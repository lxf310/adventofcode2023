﻿using Event2023.Puzzles.DayEighteen;

namespace Event2023.Tests.DayEighteen
{
    public class DayEighteenPart1Tests
    {
        private DayEighteenPart1 _solver = new DayEighteenPart1();

        [Fact]
        public void Total_ReturnsTotal()
        {
            Assert.Equal(62, _solver.Total(new List<string>
            {
                "R 6 (#70c710)",
                "D 5 (#0dc571)",
                "L 2 (#5713f0)",
                "D 2 (#d2c081)",
                "R 2 (#59c680)",
                "D 2 (#411b91)",
                "L 5 (#8ceee2)",
                "U 2 (#caa173)",
                "L 1 (#1b58a2)",
                "U 2 (#caa171)",
                "R 2 (#7807d2)",
                "U 3 (#a77fa3)",
                "L 2 (#015232)",
                "U 2 (#7a21e3)"
            }));
        }
    }
}
