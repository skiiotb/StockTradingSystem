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
            testPortfolio.AddFunds(1.5m);
            testPortfolio.PurchaseAsset("MSFT", 1m);
            var expectedBalance = 2m;
  

            //Act - invoke method being tested
            var result = testPortfolio.SellAsset("MSFT", 1.5m);
            testPortfolio.AddFunds(1.5m);


            //Assert - make sure results are as expected
            Assert.True(result);
            Assert.Equal(expectedBalance, testPortfolio.Balance);

        }

        [Fact]
        public void SellAsset_InvalidAmount_ReturnFalse()
        {
            //Arrange
            PortfolioManager testPortfolio = new();
            var assetSymbol = "MSFT";
            var amount = -1.5m;
            testPortfolio.AddFunds(1.5m);
            testPortfolio.PurchaseAsset("MSFT", 1.5m);

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
            testPortfolio.AddFunds(1.5m);
            testPortfolio.PurchaseAsset("MSFT", 1.5m);

            //Act
            var result = testPortfolio.SellAsset(assetSymbol, amount);

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void PurchaseAsset_ValidAmount_ReturnTrue()
        {
            //AAA Unit testing
            //Arrange - get data needed for test
            PortfolioManager testPortfolio = new();
            testPortfolio.AddFunds(1.5m);
            var expectedBalance = 0;

            //Act - invoke method being tested
            var result = testPortfolio.PurchaseAsset("MSFT", 1.5m);

            //Assert - make sure results are as expected
            Assert.True(result);
            Assert.Equal(expectedBalance, testPortfolio.Balance);

        }

        [Fact]
        public void PurchaseAsset_InvalidAmount_ReturnFalse()
        {
            //Arrange
            PortfolioManager testPortfolio = new();
            var assetSymbol = "MSFT";
            var amount = -1.5m;

            //Act and assert - make sure method throws exception if invalid amount is entered
            Assert.Throws<ArgumentException>(() => testPortfolio.PurchaseAsset(assetSymbol, amount));
        }

        [Fact]
        public void PurchaseAsset_InvalidAsset_ReturnFalse()
        {
            //Arrange 
            PortfolioManager testPortfolio = new();
            var assetSymbol = "BTC";
            var amount = 1.5m;

            //Act
            var result = testPortfolio.PurchaseAsset(assetSymbol, amount);

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void ListPortfolioInvestmentsByType_ValidType_ReturnsString()
        {
            //Arrange
            PortfolioManager testPortfolio = new();
            var assetType = "Equity";

            //Act 
            var result = testPortfolio.ListPortfolioInvestementsByType(assetType);

            //Assert
            if (String.IsNullOrEmpty(result))
            {
                Assert.False(true);
            }
        }





    }
}