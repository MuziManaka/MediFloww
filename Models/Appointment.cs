using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eish.Models;

namespace Eish.Models
{ 
    //======= Apointment ========
   public class Appointment
    {
        private string appointID;
        private PatientManager patientManager;
        private DoctorManager doctorManager;
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
        public TimeSpan Time { get; set; }

        public string Department { get; set; }

        public string Status { get; set; }

        public Appointment(string appointId, Patient p, Doctor d, DateTime date, TimeSpan time)
        {
            AppointID = appointId;
            Patient = p;
            Doctor = d;
            Date = date;
            Time = time;
            //  Status = status;
        }
    }

    // ======= Appointment Manager ========
    public class AppointmentManager
    {
        public List<Appointment> AppointmentList = new List<Appointment>();
        PatientManager patientManager = new PatientManager();
        DoctorManager doctorManager = new DoctorManager();
        public void Schedule()
        {
            Console.WriteLine("Good day would you like to schedule an appointment (Yes/no) ");
            string answer = Console.ReadLine();
            if ((answer) == "yes")
            {
                Console.WriteLine("Please enter patient ID");
                string pid = Console.ReadLine();
                Patient p = patientManager.Search(pid);

                Console.WriteLine("Please enter Doctor employee ID");
                string did = Console.ReadLine();
                Doctor d = doctorManager.Search(did);

                Console.WriteLine("What date would you like (yyyy/mm/dd)");
                string input = Console.ReadLine();
                if (!DateTime.TryParse(input, out DateTime date))
                {
                    Console.WriteLine("Cannot retrieve date");
                }
                else 
                {
                    Console.WriteLine("date captured");
                }

                Console.WriteLine("What time slot would you like HH:mm");
                string input2 = Console.ReadLine();
                if (!TimeSpan.TryParse(input2, out TimeSpan time))
                {
                    Console.WriteLine("Cannot retrieve time");
                }
                else
                {
                    Console.WriteLine("Time recieved");
                }
           


                if (IsAvailable(d, did,date,time ))
                {
                    Console.WriteLine("Doctor is scheduled, please try another date");
                }
              
                else
                {
                    char firstInitial = p.Name[0];
                    char secondInitial = p.Surname[0];

                    string idAppoint = pid.Substring(0, 4);
                    Random random = new Random();

                    int number = random.Next(1, 100);

                    string appointmentID = $"{firstInitial}{secondInitial}{idAppoint}-{number}";
                   
                    Appointment appointment = new Appointment(appointmentID, p, d, date, time);
                    AppointmentList.Add(appointment);

                }

            }

        }



        public bool IsAvailable(Doctor doctor, string id, DateTime date, TimeSpan time)
        {
            return !AppointmentList.Any(a => a.Doctor.EmployeeID == doctor.EmployeeID && a.Date.Date == date.Date && a.Time == time && a.Status == "Avaiable");
        }


    }
}




