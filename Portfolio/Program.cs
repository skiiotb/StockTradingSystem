using Microsoft.Extensions.Configuration;
using Portfolio.Application;
using Portfolio.Service.Live;

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

/* Remember to add the fictional asset purchases specified in the assignment to the
   portfolio*/