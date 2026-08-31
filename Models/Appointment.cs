using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eish.Models;
using Eish.Mangers;
using Eish.Enums;

namespace Eish.Models
{ 
   
   internal class Appointment
    {
       private string appointID;

        public string AppointID 
        { 
            get => appointID; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Appointment ID cannot be null or empty.");
                }
                else
                {
                    appointID = value;
                }
            } 
        }
        public Patient Patient { get; set; }
       
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
       
        public TimeSpan Time { get; set; }

        public Department Department { get; set; }

        public AppointmentStatus Status { get; set; }

        public Appointment(string appointId, Patient p, Doctor d, DateTime date, TimeSpan time, Department _department, AppointmentStatus _status)
        {
            AppointID = appointId;
            Patient.Name= p.Name;
            Doctor.Name = d.Name;
            Date = date;
            Time = time;
            Department.DepartmentName = _department.DepartmentName;
            Status = _status;
        }
    }
    
}




