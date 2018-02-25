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
                User user = new User(firstName, lastName, day, month, year);
                Console.WriteLine(user.FullName + ' ' + user.Age());
                Console.ReadKey();
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        private static string AskName(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private static int AskDate(string question)
        {
            Console.WriteLine(question);
            bool result = Int32.TryParse(Console.ReadLine(), out int datePart);
            return result ? datePart : AskDate(question);
        }
    }
}
