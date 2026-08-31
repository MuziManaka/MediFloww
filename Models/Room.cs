using Eish.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Room
    {
        private string roomID;
        private int roomNumber;
        private int capacity;
        public string RoomID 
        { 
            get => roomID; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Room ID cannot be null or empty.");
                }
                else
                {
                    roomID = value;
                }
            } 
        }
        public Ward WardID { get; set; }
        public int RoomNumber 
        {  
            get => roomNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Room number must be a positive integer.");
                }
                else
                    roomNumber = value;
            }
        }
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
        public RoomStatus Status { get; set; }

        public Room(string roomID, Ward wardID, int roomNumber, int capacity, RoomStatus status)
        {
            RoomID = roomID;
            WardID = wardID;
            RoomNumber = roomNumber;
            Capacity = capacity;
            Status = status;
        }
    }
}
