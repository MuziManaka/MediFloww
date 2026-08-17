using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eish.Models;
using Eish.Mangers;

namespace Eish.Models
{ 
    //======= Apointment ========
   public class Appointment
    {
        private string appointID;
        private PatientManager patientManager;
        private DoctorManager doctorManager;
        public string AppointID
        {
            get
            {
                return appointID;
            }
            set
            {
                if (value.Length != 13)
                {
                    throw new ArgumentException("ID number should contain 13 numbers");
                }
                else
                    appointID = value;

            }
        }
        public Patient Patient { get; set; }
        // the doctor class ask armando
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        // i also want to add time
        public TimeSpan Time { get; set; }

        public string Department { get; set; }

        public string Status { get; set; }

        public Appointment(string appointId, Patient p, Doctor d, DateTime date, TimeSpan time)
        {
            AppointID = appointId;
            Patient.Name= p.Name;
            Doctor.Name = d.Name;
            Date = date;
            Time = time;
            //  Status = status;
        }
    }

    // ======= Appointment Manager ========
    
}




