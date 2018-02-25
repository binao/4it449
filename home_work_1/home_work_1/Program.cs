using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask for users first name
            string firstName = Ask("Enter your first name");
            //ask for users last name
            string lastName = Ask("Enter your last name");

            //concat name parts into greeting string
            string greeting = String.Concat("Hello ", firstName, ' ', lastName, '!');

            //write greeting to console
            Console.WriteLine(greeting);
            //wait for any key pressed to prevent console from closing
            Console.ReadKey();
        }

        // private method for reading from console (return value string)
        private static string Ask(string question)
        {
            //write given question to console
            Console.WriteLine(question);
            //return users input
            return Console.ReadLine();
        }
    }
}
