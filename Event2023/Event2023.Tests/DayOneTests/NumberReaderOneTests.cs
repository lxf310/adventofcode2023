using Event2023.Puzzles.DayOne;

namespace Event2023.Tests.DayOneTests
{
    public class NumberReaderOneTests
    {
        private readonly NumberReaderOne _reader;

        public NumberReaderOneTests()
        {
            _reader = new NumberReaderOne();
        }

        [Fact]
        public void Read_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.Read(null));
        }

        [Fact]
        public void Read_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.Read(""));
        }

        [Fact]
        public void Read_WhiteSpaceString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.Read("      "));
        }

        [Fact]
        public void Read_ValidInput_ReturnsNumber()
        {
            Assert.Equal(0, _reader.Read("abd"));
            Assert.Equal(11, _reader.Read("sabd1ff"));
            Assert.Equal(12, _reader.Read("1av2dfd"));
            Assert.Equal(23, _reader.Read("a2gdgd4gddddgs3ggds"));
        }
    }
}
