using Portfolio.Model;

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
            throw new NotImplementedException();
        }

        /// <summary>
        /// A list of test double AssetQuotes for each of the named assets in the 
        /// </summary>
        /// <param name="assetSymbols">A list of asset symbols to get test quotes for.</param>
        /// <returns>A list of test asset quotes</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<AssetQuote> GetQuote(List<string> assetSymbols)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of trending stocks for a region from an exchange.
        /// </summary>
        /// <param name="region">is the region to look up.</param>
        /// <returns>a list of asset symbols for the specified region</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<String> GetTrendingStocksForRegion(string region)
        {
            throw new NotImplementedException();
        }

    }
}
