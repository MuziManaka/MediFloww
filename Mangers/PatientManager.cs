using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Models;
using Eish.Interfaces;

namespace Eish.Mangers
{
    public class PatientManager : IRegisterable
    {
        private List<Patient> PaitentList = new List<Patient>();

        public bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Add(Patient paitent)
        {
            PaitentList.Add(paitent);
            PatientAdmitted?.Invoke(this, EventArgs.Empty);
            PatientManager.PatientAdmitted += OnPatientAdmitted;
        }

        public Patient Search(string Id)
        {
            return PaitentList.FirstOrDefault(p => p.ID == Id);
        }

        public void Edit(string id)
        {
            Console.WriteLine("Please enter paitent ID");
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("ID cannot be empty");
            }
            else
            {
                Patient p = Search(id);
                Console.WriteLine("What information do you want to change");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Surname");
                Console.WriteLine("3. Age");
                Console.WriteLine("4. Address ");
                Console.WriteLine("5. Blood Type");
                Console.WriteLine("6. Medical Condition");
                Console.WriteLine("7. Priority Level");
                Console.WriteLine("Please enter number 1-7");

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
                            p.Name = name;
                            break;

                        case 2:
                            Console.WriteLine("Please enter surname");
                            string surname = Console.ReadLine();
                            p.Surname = surname;
                            break;

                        case 3:
                            Console.WriteLine("Please enter age");
                            int age = int.Parse(Console.ReadLine());
                            p.Age = age;
                            break;

                        case 4:
                            Console.WriteLine("Please enter address");
                            string address = Console.ReadLine();
                            p.Address = address;
                            break;

                        case 5:
                            Console.WriteLine("Please enter blood type");
                            string bloodtype = Console.ReadLine();
                            p.BloodType = bloodtype;
                            break;

                        case 6:
                            Console.WriteLine("Please enter medical condition");
                            string mc = Console.ReadLine();
                            p.MedicalCon = mc;
                            break;

                        case 7:
                            Console.WriteLine("Please enter priority level");
                            string pl = Console.ReadLine();
                            p.PriorityLevel = pl;
                            break;
                    }
                }

            }
        }

        public void Delete(string id)
        {
            Patient p = Search(id);

            if (p != null)
            {
                PaitentList.Remove(p);
            }
        }

        public void Display(Patient paitent)
        {
            foreach (Patient patient in PaitentList)
            {
                Console.WriteLine(patient);
            }
        }

        public event EventHandler PatientAdmitted;

        public void OnPatientAdmitted(object sender, EventArgs e)
        {
            Console.WriteLine("A patient has been admitted!");
        }

    }
}
