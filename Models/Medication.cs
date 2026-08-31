using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Medication
    {
        private int quantity;
        private decimal unitPrice;
        private string id;
        private string name;
        public string MedicationID 
        {
            get => id;
            set
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Medication ID cannot be null or empty.");
                }
                else
                {
                    id = value;
                }
            }
        }
        public string MedicationName 
        { 
            get => name; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Medication name cannot be null or empty.");
                }
                else
                {
                    name = value;
                }
            } 
        }
        public string Description { get; set; }
        public int Quantity
        {
            get => quantity;
            set
            { 
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
                else
                    quantity = value;
            }
        }
        public decimal UnitPrice 
        { 
            get => unitPrice;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Unit price cannot be negative.");
                }
                else
                    unitPrice = value;
            }
        }

        public Medication(string _id, string _name, string _description, int _quantity, decimal _unitPrice)
        {
            MedicationID = _id;
            MedicationName = _name;
            Description = _description;
            Quantity = _quantity;
            UnitPrice = _unitPrice;
        }
    }
}
