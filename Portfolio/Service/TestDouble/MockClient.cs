using Portfolio.Model;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Portfolio.Service.TestDouble
{
    /// <summary>
    /// The MockClient acts as a test double for the <see cref="IMarketClient"/> interface for 
    /// unit testing. It returns pre-packaged values for all queries. 
    /// </summary>
    public class MockClient : IMarketClient
    {
        /// <summary>
        /// This function returns a test doubl AssetQuote object for the named asset symbol.
        /// </summary>
        /// <param name="assetSymbol">assetSymbol indicates the symbol or icon that a specific 
        /// asset is identified with</param>
        /// <returns>a test double AssetQuote with test data</returns>
        /// <exception cref="NotImplementedException"></exception>
        public AssetQuote GetQuote(string assetSymbol)
        {
            // creating an AssetQuote object
            AssetQuote objAssetQuote = new AssetQuote();
            // assigning test data to the object 
            objAssetQuote.AssetFullName = "APPLE";
            objAssetQuote.AssetQuoteValue = 90;
            objAssetQuote.AssetSymbol = assetSymbol.ToUpper();
            objAssetQuote.AssetType = AssetType.Equity;
            // returning the AssetQuote object
            return objAssetQuote;
        }

        /// <summary>
        /// A list of test double AssetQuotes for each of the named assets in the 
        /// </summary>
        /// <param name="assetSymbols">A list of asset symbols to get test quotes for.</param>
        /// <returns>A list of test asset quotes</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<AssetQuote> GetQuote(List<string> assetSymbols)
        {
            // creating a list of type AssetQuote called assetList 
            List<AssetQuote> assetList = new List<AssetQuote>(); 
            // using a for each to check through each asset's symbol in assetList
            foreach(string assetSymbol in assetSymbols)
            {
                // initializing assetName
                string assetName = "";
                // using a switch case to return the assetFullName according to the asset's symbol
                switch (assetSymbol.ToUpper())
                {
                    case "APPL":
                        assetName = "APPLE";
                        break;
                    case "TSLA":
                        assetName = "TESLA";
                        break;
                    case "MSFT":
                        assetName = "MICROSOFT";
                        break;
                    case "NVDA":
                        assetName = "NVIDIA";
                        break;
                    default:
                        assetName = "BIRKENSTOCK";
                        break;
                }
                // creating an AssetQuote object
                AssetQuote objAssetQuote = new AssetQuote();
                // assigning values to the object
                objAssetQuote.AssetFullName = assetName;
                objAssetQuote.AssetQuoteValue = 90;
                objAssetQuote.AssetSymbol = assetSymbol;
                objAssetQuote.AssetType= AssetType.Equity;
                // adding the AssetQuote object to the list assetList
                assetList.Add(objAssetQuote);
            }
            return assetList;
        }

        /// <summary>
        /// Gets a list of trending stocks for a region from an exchange.
        /// </summary>
        /// <param name="region">is the region to look up.</param>
        /// <returns>a list of asset symbols for the specified region</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<String> GetTrendingStocksForRegion(string region)
        {
            // creating a list to contain symbols of trending stocks
            List<String> trendingStockList = new List<String>();
            // adding stock symbols to the list
            trendingStockList.Add("AAPL");
            trendingStockList.Add("TSLA");
            // returning the list of asset symbols
            return trendingStockList;
        }

    }
}
