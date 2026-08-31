using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Models
{
    internal class Department
    {
        private string id;
        private string name;
        public string DepartmentID 
        { 
            get => id; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Department ID cannot be null or empty.");
                }
                else
                {
                    id = value;
                }
            } 
        }
        public string DepartmentName 
        { 
            get => name; 
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Department name cannot be null or empty.");
                }
                else
                {
                    name = value;
                }
            } 
        }
        public string Description { get; set; }

        public Department(string departmentID, string departmentName, string description)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            Description = description;
        }

        public override string ToString()
        {
            return string.Format($"{DepartmentID} \t {DepartmentName} \t {Description}");
        }
    }
}
