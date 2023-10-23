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
     
            do
            {

                logo.Display();
                Console.WriteLine("Choose one below:");
                Console.Write(" [0]. Sign Up\n [1]. Employees Access\n- ");
                user.choice = Console.ReadLine();


            } while (!user.CheckChoice());
            switch (user.userInput)
            {
                case 0:
                    {
                        do
                        {
                        
                            Console.Clear();
                            logo.Display();
                            Console.WriteLine("User - SignUp");
                            Console.Write("User: ");
                            user.userName = Console.ReadLine();
                            Console.Write("Password: ");
                            user.password = Console.ReadLine();
                        start1:
                            Console.Clear();
                            logo.Display();
                            Console.WriteLine("Log In");
                            Console.Write("UserName: ");
                            string name = Console.ReadLine();
                            Console.Write("Password: ");
                            string pass = Console.ReadLine();
                            if (name != user.userName || pass != user.password)
                            {
                                Console.WriteLine("Invalid input!");
                                Thread.Sleep(500);
                                goto start1;
                            }

                        } while (!user.CheckUser());
                    }
                    break;
                case 1:
                    {
                        do
                        {
                            logo.Display();
                            Console.WriteLine("Employees Access - LogIn");
                            Console.Write("User: ");
                            user.userName = Console.ReadLine();
                            Console.Write("Password: ");
                            user.password = Console.ReadLine();
                        } while (!user.CheckAdmin());


                    }
                    break;

            }

            if (user.userInput == 1)
            {
                Thread.Sleep(500);
                Console.Clear();
                logo.Display();
                Console.WriteLine(" - Admin Menu - ");
                Console.Write(" [0] Show Products\n" +
                                  " [1] Edit (Add/Remove)\n" +
                                  " [2] Search Products\n" +
                                  " [3] Exit\n- ");
                int choice = int.Parse(Console.ReadLine());
                string prod;
            start:
                Console.Clear();
                DisplayItems.Menu1();
                switch (choice)
                {
                    case 1:
                        {

                            Console.WriteLine(" [0] Add\n" +
                                              " [1] Remove\n" +
                                              " [2] Edit\n" +
                                              " [3] Find(Search)\n- ");
                            int dChoice = int.Parse(Console.ReadLine());
                            switch (dChoice)
                            {
                                case 0:
                                    {
                                        Console.Write("Add Item: ");
                                        prod = Console.ReadLine();
                                        linked.AddFirst(prod);
                                        goto start;
                                    }

                                case 1:
                                    {
                                        Console.Write("Remove Item: ");
                                        prod = Console.ReadLine();
                                        linked.Remove(prod);
                                        goto start;
                                    }
                                case 2:
                                    {

                                    }
                                    break;
                                case 3:
                                    {
                                        
                                        bool ret = false;
                                        do
                                        {
                                            Console.Clear();
                                            DisplayItems.Menu1();
                                            Console.WriteLine("same name will be displayed", Console.ForegroundColor = ConsoleColor.White);
                                            Console.Write("Find: ");
                                            prod = Console.ReadLine();
                                            if (!linked.list.Contains(prod))
                                            {                                                
                                                Console.WriteLine("walay kapareho");
                                                Thread.Sleep(500);
                                                ret = true;
                                            }
                                            else
                                            {
                                                linked.Find(linked.list, prod);
                                                ret = true;
                                            }
                                        } while (ret == false);
                                        
                                        
                                    }
                                    break;

                            }
                            break;



                        }

                        
                }

            }
            else if (user.userInput == 0)
            {
                Thread.Sleep(500);
                Console.Clear();
                logo.Display();
                Console.WriteLine(" - Menu - ");
                Console.Write(" [0] Products\n" +
                                  " [1] POS\n" +
                                  " [2] Log Out\n- ");
                                  
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 0:
                        {
                            DisplayItems.Menu1();
                        }break;
                }


            }
        }
    }
}

