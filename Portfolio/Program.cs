using Microsoft.Extensions.Configuration;
using Portfolio;
using Portfolio.Application;
using Portfolio.Model;
using Portfolio.Service;
using Portfolio.Service.Live;
using Portfolio.Service.TestDouble;
using System.Numerics;
using System.Text.Json;
using Portfolio.Service.Live;
using Portfolio.Service.TestDouble;


// Load app configuration settings from the app settings file and set relevant feature flags.

// Create a config object, using JSON provider specifying the appSetting.json file.
IConfiguration appConfiguration = new ConfigurationBuilder()
    .AddJsonFile(@"Raw\appSettings.json")
    .Build();

// Get values from the appSettings.json configuation file
AppConfig? settings = appConfiguration.GetRequiredSection("AppConfig").Get<AppConfig>();

Console.WriteLine("Welcome to the ATU Porfolio management system");


// Creating a mock client
IMarketClient marketClient = new MockClient();
// creating a portfolio for the mock client
PortfolioManager portfolio1 = new PortfolioManager(marketClient);
// creating a list of type string to contain the asset symbols
List<string> assetNames = new List<string>();
// adding symbols to the list assetNames
assetNames.Add("APPL");
assetNames.Add("MSFT");
// printing the portfolio value
Console.WriteLine("Total portfolio value: " + portfolio1.GetPortfolioValue());
// creating a list of type AssetQuote called assetQuotes,
// to contain the information(AssetQuote objects) returned by the method GetAssetInformation(assetNames)
List<AssetQuote> assetQuotes = new List<AssetQuote>();
assetQuotes = portfolio1.GetAssetInformation(assetNames);
//serializing the returned data
var assetQuotesJson = JsonSerializer.Serialize(assetQuotes);
Console.WriteLine("Asset Information: " + assetQuotesJson);


/* TODO: Initialise and run your investment portfolio management system */

YahooClient financeClient = new YahooClient(url: settings.BaseURL, settings.API_keys);
AssetQuote tempQuote = financeClient.GetQuote("AAPL");

//PortfolioManager portfolio = new PortfolioManager(financeClient);

//MarketClient marketClient = new MockClient();

//PortfolioManager portfolio2 = new PortfolioManager(marketClient);
//Create list of asset symbols to get quotes for
List<string> assetSymbols = new List<string>();
assetSymbols.Add("MSFT");
assetSymbols.Add("TSLA");
List<AssetQuote> tempQuotes = financeClient.GetQuote(assetSymbols);

Console.WriteLine($"Live stock information for {tempQuote.AssetFullName} current value is ${tempQuote.AssetQuoteValue}");

financeClient.GetTrendingStocksForRegion("US");

/* Remember to add the fictional asset purchases specified in the assignment to the
   portfolio*/

bool inDevelopment = settings.InDevelopment;
if(inDevelopment)
{
    //Create an instance of the mock data client
    MockClient mockClient = new MockClient();
    AssetQuote test = mockClient.GetQuote("APPL");

    AssetQuote test2 = mockClient.GetQuote("NVDA");
}
else
{
    // Get the live client
     financeClient = new YahooClient(url: settings.BaseURL, settings.API_keys);
     financeClient.GetQuote("AAPL");

}

//UI

// creating a portfolio object 
PortfolioManager portfolioUser = new PortfolioManager();
// variable 'option' to let the user choose an option from the avaiable options
int option = 0;
// variable 'amt' to let the user enter amount related to assets where applicable
decimal amt = 0;
// DateTime variables to get user input for calling range-related methods
DateTime startDateInput;
DateTime endDateInput;
// a string variable to get user input for assetSymbol where needed
string assetSymbolInput;
do
{
    Console.WriteLine("1: Add funds");
    Console.WriteLine("2: Withdraw funds");
    Console.WriteLine("3: Purchase Asset");
    Console.WriteLine("4: Sell Asset");
    Console.WriteLine("5: Get total Portfolio value");
    Console.WriteLine("6: Get summary information on investments");
    Console.WriteLine("7: Get summary of asset purchases in range");
    Console.WriteLine("8: Get summary of asset sales in range");
    Console.WriteLine("9: Get portfolio summary");
    Console.WriteLine("10: Exit");
    Console.WriteLine("Enter option: ");
    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.WriteLine("Enter amount to be added: ");
            amt = decimal.Parse(Console.ReadLine());
            portfolioUser.AddFunds(amt);
            break;
        case 2:
            Console.WriteLine("Enter amount to be withdrawn: ");
            amt = decimal.Parse(Console.ReadLine());
            portfolioUser.WithdrawFunds(amt);
            break;
        case 3:
            Console.WriteLine("Enter asset to purchase: ");
            assetSymbolInput = Console.ReadLine();
            Console.WriteLine("Enter amount to purchase: ");
            amt = decimal.Parse(Console.ReadLine());
            portfolioUser.PurchaseAsset(assetSymbolInput, amt);
            break;
        case 4:
            Console.WriteLine("Enter asset to sell: ");
            assetSymbolInput = Console.ReadLine();
            Console.WriteLine("Enter amount to sell: ");
            amt = decimal.Parse(Console.ReadLine());
            portfolioUser.SellAsset(assetSymbolInput, amt);
            break;
        case 5:
            Console.WriteLine("Portfolio value: " + portfolioUser.GetPortfolioValue());
            break;
        case 6:
            int summaryOption;
            Console.WriteLine("1. Get summary of all investments");
            Console.WriteLine("2. Get summary of specific investments");
            Console.WriteLine("3. Get summary of a particular type of investments");
            Console.WriteLine("Choose option: ");
            summaryOption = int.Parse(Console.ReadLine());
            switch (summaryOption)
            {
                case 1:
                    Console.WriteLine(portfolioUser.ListAllInvestements());
                    break;
                case 2:
                    char yesOrNoOption = ' ';
                    string assetNameInput;
                    List<string> userAssetList = new List<string>();
                    do
                    {
                        Console.WriteLine("Enter Asset name: ");
                        assetNameInput = Console.ReadLine();
                        userAssetList.Add(assetNameInput);
                        Console.WriteLine("Do you want to enter another asset name? y/n ");
                        yesOrNoOption = char.Parse(Console.ReadLine());
                    } while (yesOrNoOption != 'n' && yesOrNoOption != 'N');

                    Console.WriteLine(portfolioUser.ListPortfolioAssetsByName(userAssetList));
                    break;
                case 3:
                    String assetTypeInput;
                    Console.WriteLine("Enter Asset Type: ");
                    assetTypeInput = Console.ReadLine();
                    Console.WriteLine(portfolioUser.ListPortfolioInvestementsByType(assetTypeInput));
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;

            }
            break;
        case 7:
            Console.WriteLine("Enter start date: ");
            startDateInput = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end date: ");
            endDateInput = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(portfolioUser.ListPortfolioPurchasesInRange(startDateInput, endDateInput));
            break;
        case 8:
            Console.WriteLine("Enter start date: ");
            startDateInput = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end date: ");
            endDateInput = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(portfolioUser.ListPortfolioSalesInRange(startDateInput, endDateInput));
            break;
        case 9:
            Console.WriteLine(portfolioUser.ListAllInvestements());
            break;
        case 10:
            Console.WriteLine("Thank you");
            break;


    }
} while (option != 10);


