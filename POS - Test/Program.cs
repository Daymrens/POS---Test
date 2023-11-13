using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace POS___Test
{

    internal class Program
    {


        static void Main(string[] args)
        {
            Inventory product = new Inventory();
            DisplayLogo.Display();
            
            Console.WriteLine("Opening System");
            for(int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(100);
            }
            bool admin = false;

            ConsoleKeyInfo keyInfo;


            do
            {
                int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);
                Console.ForegroundColor = ConsoleColor.Yellow;

                Display.DisplayProducts(product);
                Display.DisplayCart(product);
                Console.SetCursorPosition(1, 15);
                Console.WriteLine("Menu");
                Console.SetCursorPosition(1, 16);
                if (admin == false)
                {
                    for (int i = 0; i < product.linesEmployee.Length; i++)
                    {
                        if (i == product.currentLines)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine("-" + product.linesEmployee[i]);

                        Console.ResetColor();
                    }
                    Console.SetCursorPosition(1, 19);
                }
                else if (admin == true)
                {                
                 
                    for (int i = 0; i < product.linesAdmin.Length; i++)
                    {
                        if (i == product.currentLines)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine("-" + product.linesAdmin[i]);

                        Console.ResetColor();
                    }

                    Console.SetCursorPosition(1, 21);
                }
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.LeftArrow && product.currentPage > 1)
                {

                    product.currentPage--;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && product.currentPage < totalPages)
                {
                    product.currentPage++;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    product.currentLines = Math.Max(0, product.currentLines - 1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (admin == false)
                    {
                        product.currentLines = Math.Min(product.linesEmployee.Length - 1, product.currentLines + 1);
                    }
                    else if (admin == true)
                    {
                        product.currentLines = Math.Min(product.linesAdmin.Length - 1, product.currentLines + 1);
                    }


                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (admin == false)
                    {
                        if (product.currentLines == 0) // Add Items
                        {
                            Console.Write("Enter item to be added (Item Number): ");
                            string itemNumber = Console.ReadLine();
                            Console.Write("Quantity: ");
                            string quantityy = Console.ReadLine();
                           
                            product.AddItem(itemNumber, quantityy);

                        }
                        else if (product.currentLines == 1) //Search 
                        {
                            // ...
                        }
                        else if (product.currentLines == 2) // Admin Item
                        {

                            admin = true;

                        }
                        else if (product.currentLines == 3) // Exit
                        {


                        }
                    }
                    else if (admin == true)
                    {
                        if (product.currentLines == 0) // Add Items
                        {
                            Console.Write("Enter item to be added (Item Number): ");
                            string itemNumber = Console.ReadLine();
                            Console.Write("Quantity: ");
                            string quantityy = Console.ReadLine();
                            product.AddItem(itemNumber, quantityy);

                        }
                        else if (product.currentLines == 1) //Edit 
                        {
                            // ...
                        }
                        else if (product.currentLines == 2) //Remove Item
                        {
                            product.RemoveItem();


                        }
                        else if (product.currentLines == 3) // Search
                        {


                        }
                        else if (product.currentLines == 4) //Exit
                        {
                            admin = false;

                        }



                    }


                }

            } while (keyInfo.Key != ConsoleKey.Escape);



        }
    }
}

