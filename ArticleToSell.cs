using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESVendingMachine
{
    public class ArticleToSell : Article
    {
        private string _code;
        private int _quantity;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public ArticleToSell(string name, string code, decimal price, int quantity) : base(name, price)
        {
            this.Code = code;
            this.Quantity = quantity;
        }
    }
}
