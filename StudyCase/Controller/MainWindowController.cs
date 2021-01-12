using System;
using System.Collections.Generic;
using System.Text;
using StudyCase.Model;

namespace StudyCase.Controller
{
    class MainWindowController
    {
        KeranjangBelanja KeranjangBelanja;
        public MainWindowController(KeranjangBelanja keranjangBelanja)
        {
            this.KeranjangBelanja = keranjangBelanja;
        }
        public void addItem(Item item)
        {
            this.KeranjangBelanja.addItem(item);
        }
        public void addVoucher(Voucher item)
        {
            this.KeranjangBelanja.addVoucher(item);
        }
        public List<Item> getSelectedItems()
        {
            return this.KeranjangBelanja.getItems();
        }
        public List<Voucher> getSelectedVouchers()
        {
            return this.KeranjangBelanja.getVouchers();
        }
        public void deleteSelectedItem(Item item)
        {
            this.KeranjangBelanja.removeItem(item);
        }
        public void deleteSelectedVoucher(Voucher item)
        {
            this.KeranjangBelanja.removeVoucher(item);
        }
    }
}
