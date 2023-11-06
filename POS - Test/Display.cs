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
        public static void DisplayCart(Inventory product)
        {
            Console.SetCursorPosition(126, 1);
            Console.WriteLine("ITEMS IN CART");
            Console.SetCursorPosition(118, 2);
            Console.WriteLine("══════════════════════════════");

            for (int i = product.cartItems.Count - 1; i >= 0; i--)
            {
                if (product.cartItems[i].quantityInCart > 0)
                {
                    Console.SetCursorPosition(117, i + 3);
                    Console.Write($" [{i}]".PadRight(5));
                    Console.WriteLine($"║ {product.cartItems[i].ToString().PadRight(23)}║");
                }
                else
                {
                    // Remove item from cart
                    product.cartItems.RemoveAt(i);
                }
            }

            Console.SetCursorPosition(118, product.cartItems.Count + 3);
            Console.WriteLine("══════════════════════════════");
            Console.SetCursorPosition(1, 19);
        }








     


        public static void DisplayProducts(Inventory product)
        {

            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Page {product.currentPage} of {totalPages}");
            Console.WriteLine(" No.  Product Name \t Quantity \t Price");
            Console.WriteLine("  ════════════════════════════════════════════════");
            for (int i = (product.currentPage - 1) * product.pageSize; i < Math.Min(product.currentPage * product.pageSize, product.productNames.Count); i++)
            {
                Console.Write($" [{i + 1}]".PadRight(5));
                Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                Console.Write($" $ {product.price[i].ToString().PadRight(5)}║\n");
            }
            Console.WriteLine("  ═════════════════════════════════════════════════");
            Console.WriteLine(" < prev.                                 next >");

            
        }
       





    }
}
    



