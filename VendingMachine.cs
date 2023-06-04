using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESVendingMachine
{
    public class VendingMachine
    {
        private List<ArticleToSell> _articles;
        private List<Receipt> _history = new List<Receipt>();
        private decimal _balance = 0;
        private decimal _change = 0;



        public VendingMachine(List<ArticleToSell> articles)
        {
            _articles = articles;
        }



        public decimal GetChange()
        {
            decimal changeToReturn = _change;
            _change = 0;
            return changeToReturn;

        }

        public decimal GetBalance()
        {
            return _balance;
        }


        public decimal Insert(decimal change)
        {
            _change += change;
            return _change;
        }

        /*
         I couldn't make it so the set time was only present when I was testing
         
         */

        public string Choose(string code, DateTime? timestamp = null)
        {
            ArticleToSell article = null;

            foreach (var item in _articles)
            {
                if (item.Code == code)
                {
                    article = item;
                    break;
                }
            }


            if (article == null)
                return "Invalid selection!";
            if (article.Quantity == 0)
                return $"Item {article.Name}: Out of stock!";
            if (_change < article.Price)
                return "Not enough money!";


            _change -= article.Price;
            _balance += article.Price;
            article.Quantity--;
            DateTime actualTimestamp = timestamp ?? DateTime.Now;

            _history.Add(new Receipt(article, actualTimestamp));
             
            return "Vending " + article.Name;

        }



        public string[] BestHours(int top = 3)
        {
            decimal[] revenue = new decimal[24];
            string[] generatedTexts = new string[top];

            foreach (Receipt receipt in _history)
            {
                revenue [receipt.Time.Hour] += receipt.Article.Price;
            }

            decimal[] highestThree = revenue.OrderByDescending(x => x).Take(top).ToArray();

            for (int i = 0; i < top; i++)
            {
                generatedTexts[i] = $"Hour {Array.IndexOf(revenue, highestThree[i])} generated a revenue of {highestThree[i].ToString("0.00")}";
            }

            return generatedTexts;
        }




    }
}
