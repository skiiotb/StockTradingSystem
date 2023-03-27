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
        //private list
        private List<Transaction> allTransactions = new List<Transaction>();

        //properties
        public string PortfolioNumber{get;}
        public string PortfolioOwner {get; set;}

            public decimal PortfolioBalance
        {
            get
            {
                decimal portfolioBalance = 0;
                foreach (var Transaction in allTransactions)
                {
                    portfolioBalance += Transaction.amount;
                }
                return portfolioBalance;
            }
        }

        public void AddFunds(string portfolioNumber, string portfolioOwner, decimal initialBalance)
        {
             //throw new NotImplementedException();
             PortfolioNumber = portfolioNumber;
             PortfolioOwner = portfolioOwner;
             var deposit = new Transaction(PortfolioNumber, initialBalance, DateTime.Now, TransactionType.Deposit, "Initial portfolio balance");
             allTransactions.Add(deposit);
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

         public void WithdrawFunds(string portfolioNumber, string portfolioOwner, decimal initialBalance, DateTime date, decimal amount, string note)
        {
             //throw new NotImplementedException();
             PortfolioNumber = portfolioNumber;
             PortfolioOwner = portfolioOwner;
             var withdraw = new Transaction(PortfolioNumber, initialBalance, DateTime.Now, transactionType.withdraw, "Initial portfolio balance");
             allTransactions.Add(withdraw);
        }
    }
}
