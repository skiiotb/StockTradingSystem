namespace UnitTests
{
    public class PortfolioWithdrawAndAddFunds
    {
        [Fact]
        public void ValidTest_Portfolio_AddFunds()
        {
            //Arrange
            double initialBalance = 10.00;
            double amount = 5.00;
            double expectedBalance = 15.00;
            //Portfolio Number, Portfolio Owner and Initial balance.
            PortfolioAccount account = new PortfolioAccount("P0123456","Joe Bloggs", initialBalance);

            //Act
            account.deposit(amount, DateTime.Now, "Deposit Test");

            //Assert
            double actualBalance = account.Balance;
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void ValidTest_Portfolio_WithdrawFunds()
        {
            //Arrange
            double initialBalance = 10.00;
            double amount = 5.00;
            double expectedBalance = 5.00;
            PortfolioAccount account = new PortfolioAccount("P0123456","Joe Bloggs", initialBalance);

            //Act
            account.withdraw(amount, DateTime.Now, "Withdraw Test");

            //Assert
            double actualBalance = account.Balance;
            Assert.Equal(expectedBalance, actualBalance);
        }
    }
}