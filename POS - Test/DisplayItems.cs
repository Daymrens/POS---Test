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

    internal class DisplayItems : Program
    {

        public static void DisplayCart()
        {
            productsLinked product = new productsLinked();

            Console.SetCursorPosition(124, 1);
                Console.WriteLine("ITEMS IN CART");
                Console.SetCursorPosition(118, 2);
                Console.WriteLine("══════════════════════════");
             
                for (int i = 0; i < product.cartItems.Count; i++)
                {
                    if (product.cartItems[i].quantityInCart > 0)
                    {
                        Console.SetCursorPosition(118, i + 3);
                        Console.WriteLine($"║ {product.cartItems[i].ToString().PadRight(23)}║");
                    }
                    else
                    {
                        // Remove item from cart
                        product.cartItems.RemoveAt(i);
                        i--; // Decrement i to account for removed item
                    }
                }

                Console.SetCursorPosition(118, product.cartItems.Count + 3);
                Console.WriteLine("══════════════════════════");
                Console.SetCursorPosition(1, 19);

            




        }

        public static void DisplayProducts()
        {
            productsLinked product = new productsLinked();            
            product.productNames = new List<string>()
            {
            "Milk",
            "Chocolate",
            "Candy",
            "Sour Candy",
            "Bubble Gum",
            "Snow Bear",
            "Max",
            "Presto",
            "Sky Flakes",
            "Bingo",
            "Chocomucho",
            "Cloud 9",
            "Rebisco Crackers",
            "Fresh Milk",
            "Pineaple Juice",
            "C2 Large",
            "C2 Medium",
            "C3 Small",
            "Sprite Can",
            "Coke Can",
            "Royal Can",
            "Trust",
            "Robust",
            "Lighter",
            "Milo",
            "Orange Juice",
            "Tang",
            "Eight Oclock",
            "Bread",
            "Mayonnaise",
            };
            product.quantity = new List<int>()
            {
            10,
            5,
            8,
            3,
            12,
            6,
            7,
            9,
            2,
            4,
            22,
            99,
            85,
            34,
            12,
            61,
            73,
            93,
            24,
            45,
            105,
            55,
            85,
            35,
            124,
            64,
            74,
            93,
            23,
            43,
            };
            product.price = new List<int>()
            {
            20,
            10,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            10,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            10,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            20,
            };
            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 0);

            Console.WriteLine($"Page {product.currentPage} of {totalPages}");
            Console.WriteLine("  No.  Product Name \t Quantity \t Price");
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
    



