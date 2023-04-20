using Portfolio.Application;
using Portfolio.Model;
using Portfolio.Service;
using Portfolio.Service.TestDouble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{   
    public class PortfolioManager : IPortfolioSystem
    {
        // List of assets
        List<Asset> _portfolioAssets = new List<Asset>();
        Asset asset1 = new Asset();
        
        // Market client
        IMarketClient _marketClient;

         public PortfolioManager()
        {
            _marketClient = new MockClient();
        }

        public PortfolioManager(IMarketClient marketClient)
        {
            _marketClient = marketClient;
            
        }

        public void AddFunds(decimal amount)
        {
            throw new NotImplementedException();
        }

        public List<AssetQuote> GetAssetInformation(List<string> assetNames)
        {
            // creating a list to contain the returned resultList of AssetQuote objects
            List<AssetQuote> resultList = new List<AssetQuote>();
            //calling the GetQuote(List<string> assetSymbols) method from MockClient
            resultList = _marketClient.GetQuote(assetNames);
            return resultList;
           
        }

        public decimal GetPortfolioValue()
        {
            // test data
            asset1.AssetSymbol = "APPL";
            asset1.UnitsPurchased = 2;
            _portfolioAssets.Add(asset1);
            decimal portfolioValue = 0.0m;
            // Iterate through the list of assets and get the current value of each
            foreach(Asset asset in _portfolioAssets)
            {
                decimal assetMarketValue = _marketClient.GetQuote(asset.AssetSymbol).AssetQuoteValue;
                portfolioValue += assetMarketValue * asset.UnitsPurchased;
                
            }

            return portfolioValue;
        }

        public string ListAllInvestements()
        {
            throw new NotImplementedException();
        }

        public string ListPortfolioAssetsByName(List<string> assetNames)
        {
            throw new NotImplementedException();
        }

        public string ListPortfolioInvestementsByType(string assetType)
        {
            throw new NotImplementedException();
        }

        public string ListPortfolioPurchasesInRange(DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public string ListPortfolioSalesInRange(DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public bool PurchaseAsset(string assetSymbol, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool SellAsset(string assetSymbol, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool WithdrawFunds(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
