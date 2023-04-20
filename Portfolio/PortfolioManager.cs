using Portfolio.Application;
using Portfolio.Model;
using Portfolio.Service.TestDouble;
using Portfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Portfolio
{   
    public class PortfolioManager : IPortfolioSystem
    {
        // List of assets
        List<Asset> _portfolioAssets = new List<Asset>();
        Asset asset1 = new Asset();
        
        // Market client
        IMarketClient _marketClient;

        private decimal balance;
        public PortfolioManager()
        {
            _marketClient = new MockClient();
            balance = 10;
        }

        public PortfolioManager(IMarketClient marketClient)
        {
            _marketClient = marketClient;
            
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public void AddFunds(decimal amount)
        {
            if(amount > 0)
            {
                balance += amount;
            }
            else
            {
                Console.WriteLine("Invalid amount entered");
            }
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
            string PInRange;
            foreach(var asset in _portfolioAssets)
            {
                if (asset.AssetPurchaseDateTime >= startDateTime && asset.AssetPurchaseDateTime <= endDateTime)
                {
                    PInRange = $"Asset: {asset.AssetSymbol}, Purchase Price: {asset.PurchaseCost}, Current Price: {asset.AssetQuote.AssetQuoteValue}, Change: {Math.Abs(asset.AssetQuote.AssetQuoteValue - asset.PurchaseCost)}";
                    return PInRange;
                }
                else
                {
                    PInRange = "Out of range";
                    return PInRange;
                }
            }
            return PInRange = "No assets found within this timeframe";
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
            if(amount > 0 && amount < balance)
            {
                balance = balance- amount;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid amount entered");
                return false;
            }
        }
    }
}
