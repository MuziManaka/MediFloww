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

        public class DoctorManager
        {
            private List<Doctor> DoctorList = new List<Doctor>();

            public void Add(Doctor doctor)
            {
                DoctorList.Add(doctor);
            }

            public Doctor Search(string employeID)
            {
                return DoctorList.FirstOrDefault(d => d.EmployeeID == employeID);
            }

            public void Edit(string employeeid)
            {
                Console.WriteLine("Please enter paitent ID");
                if (string.IsNullOrEmpty(employeeid))
                {
                    Console.WriteLine("ID cannot be empty");
                }
                else
                {
                    Doctor d = Search(employeeid);
                    Console.WriteLine("What information do you want to change");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Surname");
                    Console.WriteLine("3. Age");
                    Console.WriteLine("4. Address ");
                    Console.WriteLine("5. Department");
                    Console.WriteLine("6. Availablity");
                    Console.WriteLine("Please enter number 1-6");

                    int answer;
                    if (!int.TryParse(Console.ReadLine(), out answer))
                    {
                        Console.WriteLine("Cannot retrive answer");
                    }
                    else
                    {
                        switch (answer)
                        {
                            case 1:
                                Console.WriteLine("Please enter name");
                                string name = Console.ReadLine();
                                d.Name = name;
                                break;

                            case 2:
                                Console.WriteLine("Please enter surname");
                                string surname = Console.ReadLine();
                                d.Surname = surname;
                                break;

                            case 3:
                                Console.WriteLine("Please enter age");
                                int age = int.Parse(Console.ReadLine());
                                d.Age = age;
                                break;

                            case 4:
                                Console.WriteLine("Please enter address");
                                string address = Console.ReadLine();
                                d.Address = address;
                                break;

                            case 5:
                                Console.WriteLine("Please enter blood type");
                                string department = Console.ReadLine();
                                d.Department = department;
                                break;

                            case 6:
                                Console.WriteLine("Please enter medical condition");
                                string availabilty = Console.ReadLine();
                                d.Availability = availabilty;
                                break;
                        }
                    }

                }
            }
            public void Delete(string id)
            {
                Doctor d = Search(id);

                if (d != null)
                {
                    DoctorList.Remove(d);
                }
            }

            public void Display(Doctor doctor)
            {
                foreach (Doctor doc in DoctorList)
                {
                    Console.WriteLine(doc);
                }
            }

            
        }
    
}
