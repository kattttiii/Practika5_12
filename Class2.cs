using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practika5_12
{
    internal class Class2
    {
        public string Title { get; set; }   
        public int Price { get; set; }

        public string StockQuantity { get; set; }

        public int Author_ID { get; set;}

        public Class2(string Title_, int price_, string StockQuantity_, int Autor_)
        {
            Title = Title_;
            Price = price_;
            StockQuantity = StockQuantity_;
            Author_ID = Autor_;
        }
    }
}
