using Portfolio.Application;
using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    public class PortfolioManager : IPortfolioSystem
    {
        public decimal Balance { get; }

        public void AddFunds(decimal amount)
        {
            throw new NotImplementedException();
        }

        public List<AssetQuote> GetAssetInformation(List<string> assetNames)
        {
            throw new NotImplementedException();
        }

        public decimal GetPortfolioValue()
        {
            throw new NotImplementedException();
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
