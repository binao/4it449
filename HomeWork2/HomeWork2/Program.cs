using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
                string firstName = AskName("Firstname");
                string lastName = AskName("Lastname");
                
                int day = AskDate("Birth day");
                int month = AskDate("Birth month");
                int year = AskDate("Birth year");
            try
            {
                //Create new user instance
                User user = new User(firstName, lastName, day, month, year);

                //Write users full name and age to console and wait for key press
                Console.WriteLine(String.Format("{0} {1}", user.FullName, user.Age()));
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Write exception message to console and wait for key press
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        //Asks for users name and returns answer (string)
        private static string AskName(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        //Asks for date name and returns integer
        private static int AskDate(string question)
        {
            Console.WriteLine(question);

            //Try parse users input to integer
            bool result = Int32.TryParse(Console.ReadLine(), out int datePart);
            //Return result if integer else ask recursively again
            return result ? datePart : AskDate(question);
        }
    }
}
