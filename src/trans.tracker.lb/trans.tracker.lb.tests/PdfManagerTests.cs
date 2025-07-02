using trans.tracker.lb.Services;

namespace trans.tracker.lb.tests
{
    public class PdfManagerTests
    {
        private readonly PdfManager _manager;

        public PdfManagerTests()
        {
            _manager = new();
        }

        [Fact]
        public void GetSymbolsCount_ReturnsLetterCountWithSpaces()
        {
            // Act
            int count = _manager.GetSymbolsCount("./TestData/Course2Roadmap.pdf", includeSpaces: true);

            // Assert
            // Only letters — punctuation and digits removed — but spaces kept
            Assert.Equal(1223, count);
        }

        [Fact]
        public void GetSymbolsCount_ReturnsLetterCountWithoutSpaces()
        {
            int count = _manager.GetSymbolsCount("./TestData/Course2Roadmap.pdf", includeSpaces: false);

            // "Helloworld" (spaces and digits removed)
            Assert.Equal(1077, count);
        }
    }
}
