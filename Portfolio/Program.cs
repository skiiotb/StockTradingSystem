using Microsoft.Extensions.Configuration;
using Portfolio.Application;
using Portfolio.Model;
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

