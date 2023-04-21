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
using System.Text.Json;

namespace Portfolio
{   
    public class PortfolioManager : IPortfolioSystem
    {
        // List of assets
        List<Asset> _portfolioAssets = new List<Asset>();
        
        // Market client
        IMarketClient _marketClient;

        private decimal balance;
        decimal portfolioValue = 0.0m;
        
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

            // Iterate through the list of assets and get the current value of each
            portfolioValue = 0;
            foreach (Asset asset in _portfolioAssets)
            {
                decimal assetMarketValue = _marketClient.GetQuote(asset.AssetSymbol).AssetQuoteValue;
                portfolioValue += assetMarketValue * asset.UnitsPurchased;
                
            }
            if(portfolioValue < 0)
            {
                portfolioValue= 0;
            }
            return portfolioValue;
        }

        public string ListAllInvestements()
        {
            StringBuilder investments = new StringBuilder();

            foreach (Asset asset in _portfolioAssets)
            {
                AssetQuote assetQuote = _marketClient.GetQuote(asset.AssetSymbol);
                decimal assetMarketValue = assetQuote.AssetQuoteValue;
                decimal assetValue = assetMarketValue * asset.UnitsPurchased;

                investments.AppendLine($"Asset: {asset.AssetSymbol}, Units Purchased: {asset.UnitsPurchased}, Current Value: {assetValue:C}");
            }

            return investments.ToString();
        }

        public string ListPortfolioAssetsByName(List<string> assetNames)
        {
            StringBuilder resultBuilder = new StringBuilder();
            decimal currentAssetValue = 0;
            decimal totalPurchaseCost = 0;
            int unitPurchased = 0;
            foreach (string assetName in assetNames)
            {
                foreach (Asset asset in _portfolioAssets)
                {
                    if (assetNames.Contains(asset.AssetSymbol))
                    {
                        AssetQuote assetQuote = _marketClient.GetQuote(asset.AssetSymbol);
                        currentAssetValue += assetQuote.AssetQuoteValue * asset.UnitsPurchased;
                        totalPurchaseCost += asset.PurchaseCost * asset.UnitsPurchased;
                        unitPurchased += asset.UnitsPurchased;
                       // resultBuilder.AppendLine($"Asset: {asset.AssetSymbol}, Units: {asset.UnitsPurchased}, Purchase Cost: {totalPurchaseCost}, Current Value: {currentAssetValue}");
                    }
                }
                if(!resultBuilder.ToString().Contains(assetName))
                {
                    resultBuilder.AppendLine($"Asset: {assetName}, Units: {unitPurchased}, Purchase Cost: {totalPurchaseCost}, Current Value: {currentAssetValue}");
                }
               
            }
                return resultBuilder.ToString();
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
            AssetQuote assetQuote = _marketClient.GetQuote(assetSymbol);

            //if the asset quote isnt found
            if (assetQuote == null)
            {
                Console.WriteLine("Asset not found on the market");
                return false;
            }

            decimal assetMarketValue = assetQuote.AssetQuoteValue;
            decimal purchaseCost = assetMarketValue;

            //if balance is less than price
            if (balance < purchaseCost)
            {
                Console.WriteLine("Insufficient funds to purchase asset");
                return false;
            }

            // checking if the amount value to purchase is a valid number
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount entered");
                return false;
            }

            Asset assetToBuy = new Asset();
            assetToBuy.AssetSymbol = assetSymbol;
            assetToBuy.PurchaseCost = purchaseCost;
            assetToBuy.AssetPurchaseDateTime = DateTime.Now;
            assetToBuy.UnitsPurchased =Convert.ToInt32(amount);
            _portfolioAssets.Add(assetToBuy);
            balance -= purchaseCost;
            // updating the portfolioValue, adding the value of assets purchased to portfolioValue
           // portfolioValue += purchaseCost;
            return true;

        }

        public bool SellAsset(string assetSymbol, decimal amount)
        {
            Asset assetToSell = new Asset();
            foreach (Asset asset in _portfolioAssets)
            {
                if (asset.AssetSymbol == assetSymbol)
                {
                    assetToSell = asset;
                    asset.UnitsPurchased = asset.UnitsPurchased - Convert.ToInt32(amount);
                    break;
                }
            }
            //Asset Symbol not found
            if (assetToSell == null || _portfolioAssets.Contains(assetToSell) == false)
            {
                Console.WriteLine("Asset not found in portfolio");
                return false;
            }

            //Amount of units in the portfolio is lower than the amount trying to be sold
         //   if (assetToSell.UnitsPurchased < amount)
         //   {
         //       Console.WriteLine("Insufficient units to sell");
         //       return false;
         //   }
            
            decimal assetMarketValue = _marketClient.GetQuote(assetToSell.AssetSymbol).AssetQuoteValue;
            decimal saleProceeds = assetMarketValue * amount;
            // checking if the amount value to sell is a valid number 
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount entered");
                return false;
            }
            //checking if the overall saleProceeds is greater than portfolioValue and returning false
            if (saleProceeds > portfolioValue)
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }
            balance += saleProceeds;
            //taking away value of the amount of stock sold from portfolio value
            portfolioValue = portfolioValue - saleProceeds;
            
            return true;
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
