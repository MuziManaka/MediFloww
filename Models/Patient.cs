using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Enums;
using Eish.Models;

namespace Eish.Models
{
        internal class Patient : Person 
        {

            public string BloodType { get; set; }
            public string MedicalCon { get; set; }
            public Priority PriorityLevel { get; set; }
            public Patient(string id, string name, string surname, int age, string address, string gender, string bloodtype, string medicalcon, Priority pl)
                : base(id, name, surname, age, address, gender)
            {
                BloodType = bloodtype;
                MedicalCon = medicalcon;
                PriorityLevel = pl;
            }
         

        }

      
}

