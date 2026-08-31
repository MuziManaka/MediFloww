using Eish.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Ward
    {
        private string wardID;
        private string wardName;
        private int capacity;
        public string WardID 
        { 
            get => wardID; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ward ID cannot be null or empty.");
                }
                else
                {
                    wardID = value;
                }
            } 
         }
        public string WardName 
        { 
            get => wardName; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ward name cannot be null or empty.");
                }
                else
                {
                    wardName = value;
                }
            } 
        }
        public WardType WardType { get; set; }
        public int Capacity
        { 
            get => capacity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity must be a positive integer.");
                }
                else
                    capacity = value;
            }
        }

        public Ward(string wardID, string wardName, WardType wardType, int capacity)
        {
            WardID = wardID;
            WardName = wardName;
            WardType = wardType;
            Capacity = capacity;
        }
    }
}
