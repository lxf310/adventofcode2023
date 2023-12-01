namespace Event2023.Tests
{
    public class InputReaderTests
    {
        private readonly InputReader _reader;

        public InputReaderTests()
        {
            _reader = new InputReader();
        }

        [Fact]
        public void ReadInputs_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.ReadInputs(null));
        }

        [Fact]
        public void ReadInputs_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _reader.ReadInputs(""));
        }
    }
}