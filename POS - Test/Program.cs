using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace POS___Test
{

    internal class Program
    {
        DisplayItems items = new DisplayItems();


        static void Main(string[] args)
        {
            logo logo = new logo();
            productsLinked linked = new productsLinked();
            
            
            userDetails user = new userDetails();
     
           

                logo.Display();
                Console.WriteLine(" LOGIN");
                Console.Write(" Username: \n Password: ");
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(11, currentLine - 1); // Move the cursor up 3 
            string name = Console.ReadLine();
            Console.SetCursorPosition(11, currentLine - 0); // Move the cursor up 3 
            string pass = Console.ReadLine();
           
            DisplayItems.Menu1();



        }
    }
}

