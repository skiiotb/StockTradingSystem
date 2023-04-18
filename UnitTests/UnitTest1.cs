using Portfolio;

namespace UnitTests
{
    public class PortfolioWithdrawAndAddFunds 
    {
        [Fact]
<
        public void AddFunds_ValidAmount_ChangesBalance()
        {
            //Arrange
            decimal initialBalance = 10.00m;
            decimal amount = 5.00m;
            decimal expectedBalance = 15.00m;
            //Portfolio Number, Portfolio Owner and Initial balance.
            //PortfolioManager account = new PortfolioManager("P0123456","Joe Bloggs", "10.0m");
            PortfolioManager account = new PortfolioManager();

            //Act
            account.AddFunds(amount);
            
            //Assert
            Assert.Equal(expectedBalance, account.Balance);
        }

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
        public void WithdrawFunds_ValidAmount_ChangesBalance()
        {
            //Arrange
            decimal initialBalance = 10.00m;
            decimal amount = 5.00m;
            decimal expectedBalance = 5.00m;
            //PortfolioManager account = new PortfolioManager("P0123456","Joe Bloggs", initialBalance);
            PortfolioManager account = new PortfolioManager();


            //Act
            account.WithdrawFunds(amount);

            //Assert
            Assert.Equal(expectedBalance, account.Balance);
        }

        public void AddFunds_invalidAmount_NotEqual()
        {
            //Arrange
            decimal initialBalance = 10.00m;
            decimal amount = -5.00m;
            decimal expectedBalance = 15.00m;
            //Portfolio Number, Portfolio Owner and Initial balance.
            //PortfolioManager account = new PortfolioManager("P0123456","Joe Bloggs", "10.0m");
            PortfolioManager account = new PortfolioManager();

            //Act
            account.AddFunds(amount);

            //Assert
            Assert.NotEqual(expectedBalance, account.Balance);
        }

        public void WithdrawFunds_InvalidAmount_NotEqual()
        {
            //Arrange
            decimal initialBalance = 10.00m;
            decimal amount = -5.00m;
            decimal expectedBalance = 15.00m;
            //PortfolioManager account = new PortfolioManager("P0123456","Joe Bloggs", initialBalance);
            PortfolioManager account = new PortfolioManager();


            //Act
            account.WithdrawFunds(amount);

            //Assert
            Assert.NotEqual(expectedBalance, account.Balance);
        }

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