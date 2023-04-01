using Portfolio.Model;

namespace TestPortfolio
{
    public class UnitTest1
    {
        //A unit test for the method ListAllInvestments() checking if the method returns a null value
        [Fact]
        public void ListAllInvestments_Test()
        {
            //Arrange
            Portfolio.PortfolioManager portfolioManager = new Portfolio.PortfolioManager();
            var result = portfolioManager.ListAllInvestements();
            //ACT
            if (result == null)
            {
                //ASSERT
                Assert.Fail("IS NULL");
            }

        }
        //A unit test for the method ListPortfolioAssetsByName() checking if the method returns a null value
        [Fact]
        public void ListPortfolioAssetsByName_Test()
        {
            //Arrange
            Portfolio.PortfolioManager portfolioManager = new Portfolio.PortfolioManager();
            List<string> testAssetNames = new List<string>(); //creating a list of string and adding few asset names for testing
            testAssetNames.Add("MSFT");
            testAssetNames.Add("AAPL");
            var result = portfolioManager.ListPortfolioAssetsByName(testAssetNames); //assigning the returned string to a variable result
            //ACT
            if (result == null)
            {
                //ASSERT
                Assert.Fail("IS NULL"); //fail the test immediately
            }

        }
        //A unit test case for the method ListPortfolioSalesInRange() when DateTime given is valid
        //also checks if the meethod returns a null value
        [Fact]
        public void ListPortfolioSalesInRange_ValidRange_Test()
        {
            //Arrange
            Portfolio.PortfolioManager portfolioManager = new Portfolio.PortfolioManager();
            DateTime startDateTime = Convert.ToDateTime("03-03-2023 02:39:22");
            DateTime endDateTime = DateTime.Now;
            var result = portfolioManager.ListPortfolioSalesInRange(startDateTime, endDateTime); //assigning the returned string to a variable result
            //ACT
            if (result == null)
            {
                //ASSERT
                Assert.Fail("IS NULL");
            }

        }
        //A unit test case for the method ListPortfolioSalesInRange() when DateTime given is invalid,
        //also checks if the meethod returns a null value
        [Fact]
        public void ListPortfolioSalesInRange_InvalidRange_Test()
        {
            //Arrange
            Portfolio.PortfolioManager portfolioManager = new Portfolio.PortfolioManager();
            DateTime startDateTime = Convert.ToDateTime("03-03-2023 02:39:22");
            DateTime endDateTime = Convert.ToDateTime("02-01-2023 03:40:47");
            //ACT
            if (endDateTime < startDateTime || startDateTime > endDateTime) //checking if start or end datetime is invalid
            {
                //ASSERT
                Assert.Fail("Invalid date time range");
            }
            var result = portfolioManager.ListPortfolioSalesInRange(startDateTime, endDateTime); //assigning the returned string to a variable result
            //ACT
            if (result == null)
            {
                //ASSERT
                Assert.Fail("IS NULL");
            }

        }
    }
}