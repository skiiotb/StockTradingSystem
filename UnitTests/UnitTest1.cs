using Portfolio;

namespace UnitTests
{
    public class PortfolioWithdrawAndAddFunds 
    {
        [Fact]
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
    }
}