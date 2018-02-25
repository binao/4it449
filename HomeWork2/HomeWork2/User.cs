using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class User
    {
        string firstName;
        string lastName;
        DateTime bornDate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BornDate { get => bornDate; set => bornDate = value; }
        public string FullName { get => firstName+' '+lastName;}

        public User(string firstName, string lastName, int day, int month, int year)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.bornDate = new DateTime(year, month, day);
        }

        public int Age()
        {
            return DateTime.Now.Year - bornDate.Year;
        }
    }
}
