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

            Thread navigationThread = new Thread(NavigationThread);
            navigationThread.Start();
            bool buying;

            int currentPage = 1;
            int pageSize = 10;
            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / pageSize);

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine($"Page {currentPage} of {totalPages}");
                Console.WriteLine("  No.  Product Name \t Quantity \t Price");
                Console.WriteLine("  ═══════════════════════════════════════════════");

                for (int i = (currentPage - 1) * pageSize; i < Math.Min(currentPage * pageSize, product.productNames.Count); i++)
                {
                    Console.Write($" [{i + 1}]".PadRight(5));
                    Console.Write($"║ {product.productNames[i].PadRight(15)}║");
                    Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                    Console.Write($" $ {product.price[i].ToString().PadRight(10)}║\n");
                }

                Console.WriteLine("  ════════════════════════════════════════════════");
                Console.WriteLine(" < prev.                                 next >");
                Console.WriteLine("Options");
                Console.Write(" [0] Add\n" +
                              " [1] Edit\n" +
                              " [2] Remove\n" +
                              " [3] Display\n" +
                              " [4] Search\n- ");

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.LeftArrow && currentPage > 1)
                {
                    currentPage--;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && currentPage < totalPages)
                {
                    currentPage++;
                }



            } while (keyInfo.Key != ConsoleKey.Escape);

            buying = false;
            // Stop buying thread
            navigationThread.Join();
            
        }
        public static void NavigationThread()
        {
            productsLinked product = new productsLinked();
            bool buying = true;
            while (buying)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D0)
                {
                    Console.Write("\nPlease enter the product name: ");
                    int prodNum = int.Parse(Console.ReadLine());

                    int qty;
                    Console.Write("Please enter the quantity: ");

                    if (int.TryParse(Console.ReadLine(), out qty))
                    {
                        // Add the product to the cart
                        product.ProductsinCart(prodNum);
                        product.Quantity(qty);

                        Thread.Sleep(100);
                        Console.WriteLine("Product added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid integer.");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.D1)
                {
                    // Option for D1
                }
                // Add other options as needed...
            }
        }






    }
    }



