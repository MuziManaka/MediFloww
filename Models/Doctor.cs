using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Enums;
using Eish.Models;

namespace Eish.Models
{
    internal class Doctor : Person
    {
        private string employeeID;

        public string EmployeeID 
        { 
            get => employeeID; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Employee ID cannot be null or empty.");
                }
                else
                {
                    employeeID = value;
                }
            } 
        }
        public Department Department { get; set; }
           
        public DoctorAvailabilty Availability { get; set; }
            
        public Doctor(string id, string name, string surname, int age, string address, string gender, string employeeId, Department department, DoctorAvailabilty availbility)
            : base(id, name, surname, age, address, gender)
        {
            EmployeeID = employeeId;
            Department.DepartmentID = department.DepartmentID;
            Availability = availbility;
        }

    }
    
}
