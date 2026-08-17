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
    }


 
      
       