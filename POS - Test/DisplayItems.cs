using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.Design;

namespace POS___Test
{
    internal class DisplayItems : productsLinked
    {

        public static void Menu1()
        {
            productsLinked product = new productsLinked();
            product.DisplayProductName();
            product.DisplayQuantity();
            product.DisplayPrice();

            string[] lines = { "Add", "Edit", "Remove", "Search" };
            int currentLines = 0;


            int currentPage = 1;
            int pageSize = 10;
            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / pageSize);

            ConsoleKeyInfo keyInfo;

          
                Console.Clear();

                Console.WriteLine($"Page {currentPage} of {totalPages}");
                Console.WriteLine("  No.  Product Name \t Quantity \t Price");
                Console.WriteLine("  ═══════════════════════════════════════════════");

                for (int i = (currentPage - 1) * pageSize; i < Math.Min(currentPage * pageSize, product.productNames.Count); i++)
                {
                    Console.Write($" [{i + 1}]".PadRight(5));
                    Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                    Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                    Console.Write($" $ {product.price[i].ToString().PadRight(10)}║\n");
                }

                Console.WriteLine("  ════════════════════════════════════════════════");
                Console.WriteLine(" < prev.                                 next >");


                int currentLine = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == currentLine)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(lines[i]);
                Console.ResetColor();
            }

            do
                {
                  
                   

                    keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        currentLine = Math.Max(0, currentLine - 1);
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        currentLine = Math.Min(lines.Length - 1, currentLine + 1);
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (currentLine == 0) // View Items
                        {
                           
                            Console.WriteLine("Viewing Items...");
                            Console.ReadKey();
                        }
                        else if (currentLine == 1) // Add Item
                        {
                          
                            Console.WriteLine("Enter item to be added:");
                            string item = Console.ReadLine();
                            Console.WriteLine("Adding item: " + item);
                            Console.ReadKey();
                        }
                        else if (currentLine == 2) // Remove Item
                        {
                            
                            Console.WriteLine("Enter item to be removed:");
                            string item = Console.ReadLine();
                            Console.WriteLine("Removing item: " + item);
                            Console.ReadKey();
                        }
                        else if (currentLine == 3) // Exit
                        {
                            break;
                        }
                    }

                } while (keyInfo.Key != ConsoleKey.Escape);
            }
            }
    }





            
            
       






    



