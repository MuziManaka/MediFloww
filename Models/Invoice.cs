using Eish.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Invoice
    {
        private decimal amount;
        private string invoiceId;
        public string InvoiceID 
        { 
            get => invoiceId; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invoice ID cannot be null or empty.");
                }
                else
                {
                    invoiceId = value;
                }
            } 
        }
        public Patient Patient {  get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount
        {
            get => amount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value cannot be negative");
                else
                    amount = value; 
            }
        }
        public PaymentStatus PaymentStatus { get; set; }

        public Invoice(string _invoiceId, Patient _patientId,DateTime _date, decimal _amount, PaymentStatus _status )
        {
            InvoiceID = _invoiceId;
            Patient.ID =_patientId.ID;
            InvoiceDate = _date;
            TotalAmount = _amount;
            PaymentStatus = _status;
        }
    }
}
