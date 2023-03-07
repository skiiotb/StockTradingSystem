using Microsoft.Extensions.Configuration;

namespace Portfolio.Application
{
    /// <summary>
    /// Main application class. This class should be used to initialise all necessary core 
    /// services and objects including the class that implements the IPortfolioSystem interface.
    /// </summary>
    public class MainApplication
    {
        /// <summary>
        /// AppConfig is used to access application configuration settings <see cref="AppConfig"/>.
        /// </summary>
        public AppConfig AppSettings { get; set; }

        public MainApplication(String appSettingsFile)
        {
            // Load the application settings;
            LoadAppSettings(appSettingsFile);

            // TODO - Initialise additional class members as appropriate based on AppSettings.

            // TODO - The class should start with an initial set of historical purchases. See the 
            // assignment specification for more details.
        }

        /// <summary>
        /// The LoadAppSettings method attempts to load the app settings from file and initialise 
        /// the AppSettings property. If an exception is raised the method will initilaise the
        /// <see cref="AppSettings"/> property to a default InDevelopment/Test state.
        /// </summary>
        /// <param name="appSettingsFile">the name of the app config json file to read.</param>
        /// <returns>True if the app settings was sucessfully created from the file otherwise 
        /// false. </returns>
        Boolean LoadAppSettings(String appSettingsFile)
        {

            // Load app configuration settings from the app settings file and set relevant feature flags.
            try
            {
                // Create a config object, using JSON provider specifying the appSetting.json file.
                IConfiguration appConfiguration = new ConfigurationBuilder()
                    .AddJsonFile(appSettingsFile)
                    .Build();

                // Get values from the appSettings.json configuation file
                //AppConfig? settings = appConfiguration.GetRequiredSection("AppConfig").Get<AppConfig>();
                AppSettings = appConfiguration.GetRequiredSection("AppConfig").Get<AppConfig>()!;
                return true;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The application settings file. AppSettings.json file was not " +
                    "found, deferring to in development and test settings.");
                Console.WriteLine(ex.Message);

                // We can't load app settings so create an InDevelopment / test AppConfig object
                AppSettings = new()
                {
                    InDevelopment = true,
                    InTest = true,
                    BaseURL = "Not using live service - Using mock data"
                };
                return false;
            }
        }
    }
}
