using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace POS___Test
{

    internal class Display
    {


        public Inventory product;

        public Display(Inventory product)
        {
            this.product = product;
        }


        public static void DisplayMenu(Inventory product)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("═════════════════════");
            Console.WriteLine("║\tMenu");

            // Loop for the first column
            for (int j = 0; j < 27; j++)
            {
                Console.SetCursorPosition(0, 1 + j);
                Console.WriteLine("║");
            }

            // Loop for the second column
            Console.SetCursorPosition(20, 1);
            for (int y = 0; y < 27; y++)
            {
                Console.WriteLine("║");
                Console.SetCursorPosition(20, 1 + y);
            }

            if (product.admin == false)
            {
                for (int i = 0; i < product.linesEmployee.Length; i++)
                {
                    if (i == product.currentLines)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.SetCursorPosition(6, 4 + i); // Set cursor position before writing the "[-]"
                    Console.Write("[-]");
                    Console.WriteLine(product.linesEmployee[i]);
                    Console.ResetColor();
                }

                Console.SetCursorPosition(1, 19);
            }
            else if (product.admin == true)
            {
                for (int i = 0; i < product.linesAdmin.Length; i++)
                {
                    if (i == product.currentLines)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.SetCursorPosition(6, 4 + i); // Set cursor position before writing the "[-]" // Set cursor position before writing the "[-]"
                    Console.Write("[-]");
                    Console.WriteLine(product.linesAdmin[i]);

                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(0, 27);
            Console.WriteLine("═════════════════════");
            Console.SetCursorPosition(24, 15);
        }
        public static void DisplayCart(Inventory product)
        {
            Console.SetCursorPosition(100, 1);
            Console.WriteLine("ITEMS IN CART");
            Console.SetCursorPosition(92, 2);
            Console.WriteLine("══════════════════════════════");

            for (int i = product.cartItems.Count - 1; i >= 0; i--)
            {
                if (product.cartItems[i].quantityInCart > 0)
                {
                    Console.SetCursorPosition(91, i + 3);
                    Console.Write($"[{i + 1}]".PadRight(5));
                    Console.WriteLine($"║ {product.cartItems[i].ToString().PadRight(23)}║");
                }
                else
                {
                    // Remove item from cart
                    product.cartItems.RemoveAt(i);
                }
            }

            Console.SetCursorPosition(92, product.cartItems.Count + 3);
            Console.WriteLine("══════════════════════════════");
            Console.SetCursorPosition(1, 18);
        }











        public static void DisplayProducts(Inventory product)
        {
            int startingY = 3; // Starting position for Y-coordinate

            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(23, 1);

            Console.WriteLine("  No.  Product Name \t Quantity\tPrice");
            Console.SetCursorPosition(23, 2);
            Console.WriteLine("  ════════════════════════════════════════════════");
          
            for (int i = (product.currentPage - 1) * product.pageSize, displayIndex = 0; i < Math.Min(product.currentPage * product.pageSize, product.productNames.Count); i++, displayIndex++)
            {
                Console.SetCursorPosition(23, startingY + displayIndex);
                Console.Write($" [{i + 1}]".PadRight(5));
                Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                Console.Write($" $ {product.price[i].ToString().PadRight(5)}║\n");
            }

            Console.SetCursorPosition(23, startingY + product.pageSize); // Set the Y-coordinate after the loop
            Console.WriteLine("  ═════════════════════════════════════════════════");
            Console.SetCursorPosition(23, startingY + product.pageSize + 1);
            Console.WriteLine($" < prev.           Page {product.currentPage} of {totalPages}             next >");
        }

    }






    }





