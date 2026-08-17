using Eish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eish.Mangers
{
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



                if (IsAvailable(d, did, date, time))
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

                    Appointment appointment = new Appointment(appointmentID, p, d, date, time);// find a way to display only the patient name and dotor name
                    AppointmentList.Add(appointment);

                    AppointmentBooked?.Invoke(this, EventArgs.Empty);
                    AppointmentManager.AppointmentBooked += OnBooked;

                }

            }

        }
        public void EditAppointment()
        {
            Console.WriteLine("Please enter appointment ID");
            string appointID = Console.ReadLine();

            if (string.IsNullOrEmpty(appointID))
            {
                Console.WriteLine("ID cannot be empty");
            }
            else
            {
                Appointment a = SearchAppointment(appointID);
                Console.WriteLine("What information do you want to change");
                Console.WriteLine("1. AppointID");
                Console.WriteLine("2. Patient name");
                Console.WriteLine("3. Doctor name");
                Console.WriteLine("4. Date ");
                Console.WriteLine("5. Time");
                Console.WriteLine("6. Exit");
                // Console.WriteLine("6. Availablity");
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
                            Console.WriteLine("Please enter Appointment ID");
                            string id = Console.ReadLine();
                            a.AppointID = id;
                            break;

                        case 2:
                            Console.WriteLine("Please enter Paitent Name");
                            string name = Console.ReadLine();
                            a.Patient.Name = name;
                            break;

                        case 3:
                            Console.WriteLine("Please enter Doctor name");
                            string dName = (Console.ReadLine());
                            a.Doctor.Name = dName;
                            break;

                        case 4:
                            Console.WriteLine("Please enter date (yyyy/mm/dd)");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            a.Date = date;
                            break;

                        case 5:
                            Console.WriteLine("Please enter Time (HH:mm)");
                            TimeSpan time = TimeSpan.Parse(Console.ReadLine());
                            a.Time = time;
                            break;

                        case 6:

                            break;
                    }
                }

            }
        }

        public Appointment SearchAppointment(string appointmentID)
        {
            return AppointmentList.FirstOrDefault(a => a.AppointID == appointmentID);
        }

        public void Display(Appointment appointment)
        {
            foreach (Appointment a in AppointmentList)
            {
                Console.WriteLine(a);
            }
        }

        public void CancelAppointment(string appointmentID)
        {
            Console.WriteLine("Please enter the appointment you looking for");
            appointmentID = Console.ReadLine();

            Appointment a = SearchAppointment(appointmentID);
            if (a != null)
            {
                Console.WriteLine("Would you like to cancel your appointment");
                Console.WriteLine("Yes or No");
                string answer = Console.ReadLine().Trim();

                if (answer == "Yes")
                {
                    AppointmentList.Remove(a);
                    AppointmentCancelled?.Invoke(this, EventArgs.Empty)
                    AppointmentManager.AppoinmentCancelled += onCancelled;
                }
                else
                {
                   // Application.Exit();
                }
            }
        }

        public bool IsAvailable(Doctor doctor, string id, DateTime date, TimeSpan time)
        {
            return !AppointmentList.Any(a => a.Doctor.EmployeeID == doctor.EmployeeID && a.Date.Date == date.Date && a.Time == time && a.Status == "Avaiable");
        }

        public event EventHandler AppointmentBooked;
        public event EventHandler AppointmentCancelled;
        public void OnBooked(object sender, EventArgs e)
        {
            Console.WriteLine("Appointment has been booked!");
        }
        public void onCancelled(object sender, EventArgs e)
        {
            Console.WriteLine("Appointment has been canceled");
        }

    }
}
