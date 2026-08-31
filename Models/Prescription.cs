using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Prescription
    {
        private string prescriptionId;

        public string PrescriptionID 
        { 
            get => prescriptionId; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Prescription ID cannot be null or empty.");
                }
                else
                {
                    prescriptionId = value;
                }
            } 
        }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime PrescriptionDate {  get; set; }
        public string Notes { get; set; }

        public Prescription(string id, Patient patient, Doctor doctor, DateTime date, string notes)
        {
            PrescriptionID = id;
            Patient.ID = patient.ID;
            Doctor.ID = doctor.ID;
            PrescriptionDate = date;
            Notes = notes;
        }
    }
}
