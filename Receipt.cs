using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESVendingMachine
{
    class Receipt
    {
        public Article Article;
        private DateTime _time;

        public Receipt(Article article, DateTime time = default(DateTime))
        {
            Article = article;
            _time = time;
        }

        public DateTime Time
        {
            get
            {
                return _time;
            }
        }


    }
}
