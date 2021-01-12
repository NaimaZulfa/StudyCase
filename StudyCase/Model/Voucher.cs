using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCase.Model
{
    public class Voucher
    {
        public string tittle { get; set; }
        public double disc { get; set; }
        public double discInPercent { get; set; }

        public Voucher(string tittle, double disc = 0, double discInPercent = 0)
        {
            this.tittle = tittle;
            this.disc = disc;
            this.discInPercent = discInPercent;
        }
    }
}
