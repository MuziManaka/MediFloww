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

        //=========  Paitent Class ============
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

        // ====== Doctor ========
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
        // ========= Patient Manager ========
        public class PatientManager
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
                    if (!int.TryParse(Console.ReadLine(), out  answer))
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

            //======= Apointment ========
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
                  //  Status = status;
                }
            }

            // ======= Appointment Manager ========
            public class AppointmentManger
            {
                public List<Appointment> AppointmentList = new List<Appointment>();

                public void Schedule()
                {
                    Console.WriteLine("Good day would you like to schedule an appointment (Yes/no) ");
                    string answer = Console.ReadLine();
                    if ((answer) == "yes")
                    {
                        Console.WriteLine("Please enter patient ID");
                        string id = Console.ReadLine();

                        PatientManager manager = new PatientManager();
                        Patient p = manager.Search(id);

                        char firstInitial = p.Name[0];
                        char secondInitial = p.Surname[0];

                        string idAppoint = id.Substring(0, 4);
                        Random random = new Random();

                        int number = random.Next(1, 100);

                        string appointmentID = $"{firstInitial}{secondInitial}{idAppoint}-{number}";
                       

                        Console.WriteLine("Please enter Doctor employee ID");
                        string employeeID = Console.ReadLine();

                        DoctorManager doctorManager = new DoctorManager();
                        Doctor d = doctorManager.Search(employeeID);

                        DateTime date = new DateTime(); 

                        if ( d.Availability == "Scheduled" )
                        {
                            Console.WriteLine("Doctor is scheduled, please try another date");
                        }
                        else if(d.Availability == "Unaviable")
                        {
                            Console.WriteLine($"Doctor {d.Name} is unavaible, please try again");
                        }
                        else 
                        {
                            Appointment appointment = new Appointment(appointmentID,p,d,date);
                           
                        }
                    }
                }

            }

        }
    }
}