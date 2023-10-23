using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace POS___Test
{

    internal class Program
    {
        
        static void Main(string[] args)
        {
            userDetails user = new userDetails();
            logo logo = new logo();
            do
            {

            logo.Display();
            Console.WriteLine("OPTIONS");
            Console.Write(" 0. User\n 1. Admin\n- ");
            user.choice = Console.ReadLine();
            
            
            } while (!user.CheckChoice());
            switch (user.userInput)
            { 
            case 0 :
                    {
                        do
                        {
                            logo.Display();
                            Console.WriteLine("User - LogIn");
                            Console.Write("User: ");
                            user.userName = Console.ReadLine();
                            Console.Write("Password: ");
                            user.password = Console.ReadLine();
                        } while (!user.CheckUser());
                    }
                    break;
            case 1 :
                    {
                        do
                        {
                            logo.Display();
                            Console.WriteLine("Admin - LogIn");
                            Console.Write("User: ");
                            user.userName = Console.ReadLine();
                            Console.Write("Password: ");
                            user.password = Console.ReadLine();
                            
                            
                        }while(!user.CheckAdmin());


                    }
                    break;

            }

            



            Console.ReadLine();

        }
    }
}
