namespace Event2023.Tests
{
    public class HelperTests
    {
        [Fact]
        public void ReadInputs_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Helper.ReadInputs(null));
        }

        [Fact]
        public void ReadInputs_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Helper.ReadInputs(""));
        }

        [Fact]
        public void GCD()
        {
            Assert.Equal(2, Helper.GCD(6, 4));
        }
    }
}