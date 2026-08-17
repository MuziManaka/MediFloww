using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Models;

namespace Eish.Models
{
  
  
        public class Doctor : Person
        {
            public string EmployeeID { get; set; }
            public string Department { get; set; }
            // ig the set of the departmet ill do it her
            public string Availability { get; set; }
            // probably set the validation here or create a method in the docmanager
            public Doctor(string id, string name, string surname, int age, string address, string gender, string employeeId, string department, string availbility)
                : base(id, name, surname, age, address, gender)
            {
                EmployeeID = employeeId;
                Department = department;
                Availability = availbility;
            }

        }
    
}
