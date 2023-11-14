using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(100);
            }


            ConsoleKeyInfo keyInfo;


            do
            {
                int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);
                Console.ForegroundColor = ConsoleColor.Yellow;
                
                Display.DisplayProducts(product);
                Display.DisplayCart(product);                
                Display.DisplayMenu(product);

                keyInfo = Console.ReadKey();

                if (product.editable == false)
                {

                
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
                    if (product.admin == false)
                    {
                        product.currentLines = Math.Min(product.linesEmployee.Length - 1, product.currentLines + 1);
                    }
                    else if (product.admin == true)
                    {
                        product.currentLines = Math.Min(product.linesAdmin.Length - 1, product.currentLines + 1);
                    }


                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                        if (product.admin == false)
                        {
                            if (product.currentLines == 0) // Add Items
                            {
                                Console.SetCursorPosition(24, 16);
                                Console.Write("Enter item to be added (Item Number): ");
                                string itemNumber = Console.ReadLine();
                                Console.SetCursorPosition(24, 17);
                                Console.Write("Quantity: ");
                                string quantityy = Console.ReadLine();

                                product.AddItem(itemNumber, quantityy);

                            }
                            else if (product.currentLines == 1) //Search 
                            {
                                // ...
                                Console.SetCursorPosition(25, 15);
                                Console.Write("Enter name: ");
                                
                                string prodName = Console.ReadLine();

                                product.FindRelevance(product.productNames, prodName);
                            }
                            else if (product.currentLines == 2) // Admin Item
                            {

                                product.admin = true;

                            }
                            else if (product.currentLines == 3) // Exit
                            {


                            }
                        }
                        else if (product.admin == true)
                        {
                            if (product.currentLines == 0) // Add Items
                            {
                                Console.SetCursorPosition(25, 15);
                                Console.Write("Enter item to be added (Item Number): ");
                                string itemNumber = Console.ReadLine();
                                Console.SetCursorPosition(25, 16);
                                Console.Write("Quantity: ");
                                string quantityy = Console.ReadLine();
                                product.AddItem(itemNumber, quantityy);

                            }
                            else if (product.currentLines == 1) //Edit 
                            {
                                product.editable = true;
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
                                product.admin = false;

                            }
                        }
                        else if (product.editable == true)
                        {
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

                            }

                        }
                        

                    }


                }

            } while (keyInfo.Key != ConsoleKey.Escape);



        }
    }
}

