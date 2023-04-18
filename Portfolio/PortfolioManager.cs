using Portfolio.Application;
using Portfolio.Model;
using Portfolio.Service.TestDouble;
using Portfolio.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    public class PortfolioManager : IPortfolioSystem
    {

        //List of assets
        List<Asset> _portfolioAssets;

        //Market Client
        IMarketClient _client;


        private decimal balance;

        public PortfolioManager()
        {
            _portfolioAssets = new List<Asset>();
            _client = new MockClient();
            balance= 10;
        }

        public PortfolioManager(IMarketClient marketClient)
        {
            _portfolioAssets = new List<Asset>();
            _client = marketClient;
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
