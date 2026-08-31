using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class PrescriptionDetail
    {
        private string prescriptionDetailID;
        public string PrescriptionDetailID 
        { 
            get => prescriptionDetailID; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Prescription Detail ID cannot be null or empty.");
                }
                else
                {
                    prescriptionDetailID = value;
                }
            } 
        }
        public Prescription Prescription { get; set; }
        public Medication Medication { get; set; }
        public string Dosage {  get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }

        public PrescriptionDetail( string prescriptionDetailID, Prescription prescriptionID, Medication medicationID, string dosage, string frequency, string duration)
        {
            PrescriptionDetailID = prescriptionDetailID;
            Prescription.PrescriptionID = prescriptionID.PrescriptionID;
            Medication.MedicationID = medicationID.MedicationID;
            Dosage = dosage;
            Frequency = frequency;
            Duration  = duration;
        }

    }
}
