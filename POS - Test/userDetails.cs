using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace POS___Test
{
    internal class userDetails
    {

        public string userName;
        public string password;
        public string admin = "admin";
        public string adminPass = "admin";
        public string choice;
        public int userInput;

        //example adding or removing code

        public bool CheckChoice()
        {
            if (int.TryParse(choice, out userInput))
            {
                if (userInput == 0)
                {
                    Thread.Sleep(500);
                    Console.Clear();
                    return true;
                }
                else if (userInput == 1)
                {
                    Thread.Sleep(500);
                    Console.Clear();
                    return true;
                }
                if (userInput >= 2)
                {
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(" - Error, Out of bounds");
                    return false;
                }
                return true;
            }
            else
            {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(" - Invalid input. Please enter a valid number.");
                return false;
            }
        }




        public bool CheckAdmin()
        {
            if (userName == admin && password == adminPass)
            {
                Console.WriteLine("Log in Successfull");
                return true;
            }
            else
            {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Invalid admin(basta di mao imong admin details!");
                return false;

            }
        }

        public bool CheckUser()
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(" - Error, empty");
                return false;
            }
            else
            {
                Console.WriteLine(" - Log in Successfully");
                return true;
            }

        }





    }
}
