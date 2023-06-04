using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESVendingMachine
{
    public class Article
    {
        private string _name;

        private decimal _price;

        public Article(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
