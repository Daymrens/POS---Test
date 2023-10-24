using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.Design;
using System.Windows.Forms;

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
            int left = Console.CursorLeft;
                        int top = Console.CursorTop;
        

            int currentPage = 1;
            int pageSize = 10;
            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / pageSize);

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"Page {currentPage} of {totalPages}");
                Console.WriteLine("  No.  Product Name \t Quantity \t Price");
                Console.WriteLine("  ═══════════════════════════════════════════════");

                for (int i = (currentPage - 1) * pageSize; i < Math.Min(currentPage * pageSize, product.productNames.Count); i++)
                {
                    Console.Write($" [{i + 1}]".PadRight(5));
                    Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                    Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                    Console.Write($" $ {product.price[i].ToString().PadRight(5)}║\n");
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

                Console.SetCursorPosition(124, 1);
                Console.WriteLine("ITEMS IN CART");
                Console.SetCursorPosition(118, 2);
                Console.WriteLine("══════════════════════════");

                for (int i = 0; i < product.list.Count; i++)
                {
                    Console.SetCursorPosition(118, i + 3); // Adjust position as needed
                    Console.WriteLine($"║ {product.list[i].PadRight(24)}║");
                    
                }

                Console.SetCursorPosition(118, product.list.Count + 3);
                Console.WriteLine("══════════════════════════");
                Console.SetCursorPosition(1, 19);

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
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (currentLines == 0) // View Items
                    {
                        Console.Write("Enter item to be added (by number): ");
                        int itemNumber = int.Parse(Console.ReadLine()) - 1;

                        if (itemNumber >= 0 && itemNumber < product.productNames.Count)
                        {
                            string itemName = product.productNames[itemNumber];
                            int itemQuantity = product.quantity[itemNumber];

                            Console.WriteLine("Adding item: " + itemName + " (Quantity: " + itemQuantity + ")");

                            // Add item to cart
                            product.list.Add(itemName + " (Qty: " + itemQuantity + ")");
                        }
                        else
                        {
                            Console.WriteLine("Invalid item number!");
                        }

                        Console.ReadLine();
                    }
                    else if (currentLines == 1) // Add Item
                    {
                        // ...
                    }
                    else if (currentLines == 2) // Remove Item
                    {
                        Console.WriteLine("Note: from 1 - i. depend on the product added");
                        Console.Write("Enter item to be removed (by number): ");
                        int itemNumber = int.Parse(Console.ReadLine()) - 1;

                        if (itemNumber >= 0 && itemNumber < product.list.Count)
                        {
                            string removedItem = product.list[itemNumber];
                            product.list.RemoveAt(itemNumber);
                            

                            Console.WriteLine("Removing item: " + removedItem);
                        }
                        else
                        {
                            Console.WriteLine("Invalid item number!");
                        }
                    }
                    else if (currentLines == 3) // Exit
                    {
                        break;
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);




        }
       





    }
}
    



