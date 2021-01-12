using System;
using System.Collections.Generic;
using System.Text;

namespace StudyCase.Model
{
    class Payment
    {
        private double promo = 0;
        private double balance = 0;
        private OnPaymentChangedListener paymentCallback;

        public Payment(OnPaymentChangedListener paymentCallback)
        {
            this.paymentCallback = paymentCallback;
        }
        public void updateTotal(double subtotal, double potongan)
        {
            double total = subtotal + potongan;
            this.paymentCallback.OnPriceUpdated(subtotal, total, potongan);
        }
    }
    interface OnPaymentChangedListener
    {
        internal void OnPriceUpdated(double subtotal, double total, double potongan)
        {
            throw new NotImplementedException();
        }
    }
}
