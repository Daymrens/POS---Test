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
                    Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                    Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                    Console.Write($" $ {product.price[i].ToString().PadRight(10)}║\n");
                }

                Console.WriteLine("  ════════════════════════════════════════════════");
                Console.WriteLine(" < prev.                                 next >");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == currentLines)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(" -" + lines[i]);


                    Console.ResetColor();
                }
                
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.LeftArrow && currentPage > 1)
                {
                    currentPage--;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && currentPage < totalPages)
                {
                    currentPage++;
                }
                
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        currentLines = Math.Max(0, currentLines - 1);
                    }
               else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        currentLines = Math.Min(lines.Length - 1, currentLines + 1);
                    }

               



            } while (keyInfo.Key != ConsoleKey.Escape);

           
       

        }
       





    }
}
    



