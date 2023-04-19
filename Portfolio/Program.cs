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
    YahooClient financeClient = new YahooClient(url: settings.BaseURL, settings.API_keys);
    financeClient.GetQuote("AAPL");

}

