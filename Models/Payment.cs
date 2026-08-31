using Eish.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Payment
    {
        private decimal amount;
        public string PaymentID { get; set; }
        public Invoice InvoiceID { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethodType PaymentType { get; set; }
        public decimal Amount   
        {
            get => amount;
            set
            {
                if (amount > 0)
                    amount = value;
                else
                    throw new ArgumentException("Amount cannot be negative");
            }
        }

        public Payment(string _paymentId, Invoice _invoiceId, DateTime _date, PaymentMethodType _paymentType, decimal _amount)
        {
            PaymentID = _paymentId;
            InvoiceID = _invoiceId;
            PaymentDate = _date;
            PaymentType = _paymentType;
            Amount = _amount;
        }
    }
}
