using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCase.Model
{
    class Item
    {
        public string tittle { get; set; }
        public double price { get; set; }

        public Item(string tittle, double price)
        {
            this.tittle = tittle;
            this.price = price;
        }
    }
}
