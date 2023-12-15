using Event2023.Puzzles.DayFifteen;

namespace Event2023.Tests.DayFifteen
{
    public class DayFifteenPart1Tests
    {
        private DayFifteenPart1 _solver = new DayFifteenPart1();

        [Fact]
        public void Total_SingleStep()
        {
            Assert.Equal(97, _solver.Total(new List<string> { "qp=3" }));
        }

        [Fact]
        public void Total_MultipleSteps()
        {
            Assert.Equal(1320, _solver.Total(new List<string>
            {
                "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7"
            }));
        }
    }
}
