using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;


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

            Console.WriteLine(" Product Name \t Quantity \t Price");
            Console.WriteLine("  ═══════════════════════════════════════════");

            for (int i = 0; i < product.productNames.Count; i++)
            {
                Console.Write($" [{i + 1}]".PadRight(5));
                Console.Write($"║ {product.productNames[i].PadRight(15)}║");
                Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                Console.Write($" $ {product.price[i].ToString().PadRight(10)}║\n");
            }

            Console.WriteLine("  ════════════════════════════════════════════");
            Console.WriteLine(" < prev.                                 next >", Console.ForegroundColor = ConsoleColor.Red);

        }






    }
}

