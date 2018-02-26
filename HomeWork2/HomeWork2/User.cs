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
        DateTime birthDate;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string FullName { get => String.Format("{0} {1}", firstName, lastName); }

        public User(string firstName, string lastName, int day, int month, int year)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = ConvertToBirthDate(year, month, day);
        }

        public int Age()
        {
            DateTime currentDate = DateTime.Now;
            //calculate age from year difference
            int age = currentDate.Year - birthDate.Year;

            //return decremented age if birthdate not overlaping currentdate
            return NotOverlaping(currentDate, birthDate) ? --age : age;
        }

        //Check if birth date is not overlapping current date
        private bool NotOverlaping(DateTime currentDate, DateTime birthDate)
        {
            return (currentDate.Month < birthDate.Month ||
                      (currentDate.Month == birthDate.Month &&
                       currentDate.Day < birthDate.Day));
        }

        /*Create new DateTime from integer params
        throws ArgumentOutOfRangeException if not valid*/
        private DateTime ConvertToBirthDate(int year, int month, int day)
        {
            birthDate = new DateTime(year, month, day);

            //throw ArgumentOutOfRangeException if birthdate in future
            if (birthDate > DateTime.Now) throw new ArgumentOutOfRangeException();
            return birthDate;
        }
    }
}
