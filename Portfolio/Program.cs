using Microsoft.Extensions.Configuration;
using Portfolio;
using Portfolio.Application;
using Portfolio.Model;
using Portfolio.Service;
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

YahooClient financeClient = new YahooClient(url: settings.BaseURL, settings.API_keys);
financeClient.GetQuote("AAPL");
/* TODO: Initialise and run your investment portfolio management system */

//YahooClient financeClient = new YahooClient(url: settings.BaseURL, settings.API_keys);
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