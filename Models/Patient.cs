using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Models;

namespace Eish.Models
{
        public class Patient : Person 
        {

            public string BloodType { get; set; }
            public string MedicalCon { get; set; }
            public string PriorityLevel { get; set; }
            public Patient(string id, string name, string surname, int age, string address, string gender, string bloodtype, string medicalcon, string pl)
                : base(id, name, surname, age, address, gender)
            {
                BloodType = bloodtype;
                MedicalCon = medicalcon;
                PriorityLevel = pl;
            }
            public override void DisplayInfo()
            {
                Console.WriteLine($"This is patient {ID}");
            }

        }

      
}

