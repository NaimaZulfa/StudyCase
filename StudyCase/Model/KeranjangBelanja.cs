using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StudyCase.Model
{
    class KeranjangBelanja
    {
        List<Item> itemBelanja;
        List<Voucher> itemVoucher;
        int capacity = 1;
        Payment payment;
        OnKeranjangBelanjaChangerListener callback;
        private MainWindow mainWindow;

        public KeranjangBelanja(Payment payment, OnKeranjangBelanjaChangerListener callback)
        {
            this.payment = payment;
            this.itemBelanja = new List<Item>();
            this.itemVoucher = new List<Voucher>();
            this.callback = callback;
        }
        public List<Item> getItems()
        {
            return this.itemBelanja;
        }
        public List<Voucher> getVouchers()
        {
            return this.itemVoucher;
        }

        public void addItem(Item item)
        {
            this.itemBelanja.Add(item);
            this.callback.addItemSucceed();
            calculateSubTotal();
        }
        public void addVoucher(Voucher item)
        {
            if(capacity == 1)
            {
                this.itemVoucher.Add(item);
                this.callback.addVoucherSucceed();
                capacity = 0;
                calculateSubTotal();
            }
            else
            {
                MessageBox.Show("GAGAL", "Ok", MessageBoxButton.OK);
            }
        }
        public void removeItem(Item item)
        {
            this.itemBelanja.Remove(item);
            this.callback.removeItemSucceed();
            capacity = 1;
            calculateSubTotal();
        }
        public void removeVoucher(Voucher item)
        {
            this.itemVoucher.Remove(item);
            this.callback.removeVoucherSucceed();
            capacity = 1;
            calculateSubTotal();
        }
        private void calculateSubTotal()
        {
            double subtotal = 0;
            double potongan = 0;
            foreach (Item item in itemBelanja)
            {
                subtotal += item.price;
            }

            foreach (Voucher voucher in itemVoucher)
            {
                if (voucher.discInPercent != 0)
                {

                    if (voucher.discInPercent == 30)
                    {
                        if (subtotal >= 100000)
                        {
                            potongan -= 30000;
                        }
                        else
                        {
                            potongan -= subtotal * (voucher.discInPercent / 100);
                        }
                    }
                    else
                    {
                        potongan -= subtotal * (voucher.discInPercent / 100);
                    }
                }

                if (voucher.disc != 0)
                {
                    potongan -= voucher.disc;
                }
            }
            payment.updateTotal(subtotal, potongan);
        }
    }

    interface OnKeranjangBelanjaChangerListener
    {
        void addItemSucceed();
        void addVoucherSucceed();
        void removeItemSucceed();
        void removeVoucherSucceed();
    }
}
