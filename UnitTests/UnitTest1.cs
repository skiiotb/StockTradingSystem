using Portfolio;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void SellAsset_ValidAmount_ReturnTrue()
        {
            //AAA Unit testing
            //Arrange - get data needed for test
            PortfolioManager testPortfolio = new();

            //Act - invoke method being tested
            var result = testPortfolio.SellAsset("MSFT", 1.5m);

            //Assert - make sure results are as expected
            Assert.True(result);

        }

        [Fact]
        public void SellAsset_InvalidAmount_ReturnFalse()
        {
            //Arrange
            PortfolioManager testPortfolio = new();
            var assetSymbol = "MSFT";
            var amount = -1.5m;

            //Act and assert - make sure method throws exception if invalid amount is entered
            Assert.Throws<ArgumentException>(() => testPortfolio.SellAsset(assetSymbol, amount));
        }

        [Fact]
        public void SellAsset_InvalidAsset_ReturnFalse()
        {
            //Arrange
            PortfolioManager testPortfolio = new();
            var assetSymbol = "BTC";
            var amount = 1.5m;

            //Act
            var result = testPortfolio.SellAsset(assetSymbol, amount);

            //Assert
            Assert.False(result);

        }

    }
}