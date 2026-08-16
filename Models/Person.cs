using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Eish.Models
{
    internal class Persons
    {
        public abstract class Person
        {
            private string id;
            public string ID
            {
                get
                {
                    return id;
                }
                set
                {
                    if (value.Length != 13)
                    {
                        throw new ArgumentException("ID number should contain 13 numbers");
                    }
                    else
                        id = value;
                }
            }
            private string name;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Name cannot be empty");
                    }
                    else
                        name = value;
                }
            }
            public string Surname { get; set; }
            private int age;
            public int Age
            {
                get
                {
                    return age;
                }

                set
                {
                    if (value <= 0)
                    {
                        age = value;
                    }
                    else
                    {
                        throw new ArgumentException("Age can't be negative");
                    }
                }


            }
            public string Address { get; set; }
            public string Gender { get; set; }

            protected Person(string id, string name, string surname, int age, string address, string gender)
            {
                ID = id;
                Name = name;
                Surname = surname;
                Age = age;
                Address = address;
                Gender = gender;
            }
            public virtual void DisplayInfo()
            {

            }

        }

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
        public class Doctor : Person
        {
            public string EmployeeID { get; set; }
            public string Department { get; set; }
            // ig the set of the departmet ill do it her
            public string Availability { get; set; }

            public Doctor(string id, string name, string surname, int age, string address, string gender, string employeeId, string department, string availbility)
                : base(id, name, surname, age, address, gender)
            {
                EmployeeID = employeeId;
                Department = department;
                Availability = availbility;
            }

        }

        public class PatientManager
        {
            private List<Patient> PaitentList = new List<Patient>();

            public void Add(Patient paitent)
            {
                PaitentList.Add(paitent);
            }

            public Patient Search(string Id)
            {
                return PaitentList.FirstOrDefault(p => p.ID == Id);
            }

            public void Edit(string id)
            {
                Patient p = Search(id);
                Console.WriteLine("what information would you like to change"); // this part im sure i can create something in teh UI to document this??
                // ohh and some checking maybe. if they say name we will validate the input and change... but i dont think its wise to change but the concept applies
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

            public class Appointment
            {
                private string appointID;
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

                public string Department { get; set; }

                public string Status { get; set; }

                protected Appointment(string appointId, Patient p, Doctor d, DateTime date, string status)
                {
                    AppointID = appointId;
                    Patient = p;
                    Doctor = d;
                    Date = date;
                    Status = status;
                }
            }
            public class AppointmentManger
            {
                public List<Appointment> AppointmentList = new List<Appointment>();

                public void Schedule()
                {
                    Console.WriteLine("Good day would you like to schedule an appointment (Yes/no) ");
                    string answer = Console.ReadLine();
                    if ((answer) == "yes")
                    {
                        Console.WriteLine("Please give me your ID number");
                        string id = Console.ReadLine();
                        PatientManager manager = new PatientManager();
                     
                        Patient p = manager.Search(id);

                        char firstInitial = p.Name[0];
                        char secondInitial = p.Surname[0];

                        string idAppoint = id.Substring(0, 4);
                        Random random = new Random();

                        int number = random.Next(1, 100);

                        string appointmentID = $"{firstInitial}{secondInitial}{idAppoint}-{number}";

                        if (Doctor d.status == "Scheduled" )
                        {
                            Console.WriteLine("Doctor is scheduled, please try another date");
                        }
                        else if(d.status == "Unavaible")
                        {
                            Console.WriteLine($"Doctor {Doctor.Name} is unavaible, please try again");
                        }
                        else 
                        {
                            // doctor 
                        }
                    }
                }

            }

        }
    }
}