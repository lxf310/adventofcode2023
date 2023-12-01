using Event2023.Puzzles.DayOne;
using Moq;

namespace Event2023.Tests.DayOneTests
{
    public class DayOneTests
    {
        private DayOne _algo;

        public DayOneTests()
        {
            var readerMock = new Mock<INumberReader>();
            readerMock.Setup(x => x.Read(It.IsAny<string>())).Returns(1);

            _algo = new DayOne(readerMock.Object);
        }

        [Fact]
        public void Ctor_NullParam_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new DayOne(null));
        }

        [Fact]
        public void Total_NullList_ReturnsZero()
        {
            Assert.Equal(0, _algo.Total(null));
        }

        [Fact]
        public void Total_EmptyList_ReturnsZero()
        {
            Assert.Equal(0, _algo.Total(new List<string>()));
        }

        [Fact]
        public void Total_ValidList_ReturnsZero()
        {
            Assert.Equal(3, _algo.Total(new List<string> { "a", "b", "c" }));
        }
    }
}
