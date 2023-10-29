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
            //product.DisplayProductName();
            //product.DisplayQuantity();
            //product.DisplayPrice();

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

            string[] lines = { "Add", "Edit", "Remove", "Search" };
            int currentLines = 0;
           
        

            int currentPage = 1;
            int pageSize = 10;
            int totalPages = (int)Math.Ceiling((double)product.productNames.Count / pageSize);

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"Page {currentPage} of {totalPages}");
                Console.WriteLine("  No.  Product Name \t Quantity \t Price");
                Console.WriteLine("  ════════════════════════════════════════════════");

                for (int i = (currentPage - 1) * pageSize; i < Math.Min(currentPage * pageSize, product.productNames.Count); i++)
                {
                    Console.Write($" [{i + 1}]".PadRight(5));
                    Console.Write($"║ {product.productNames[i].PadRight(20)}║");
                    Console.Write($" {product.quantity[i].ToString().PadRight(12)}║");
                    Console.Write($" $ {product.price[i].ToString().PadRight(5)}║\n");
                }

                Console.WriteLine("  ═════════════════════════════════════════════════");
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

                for (int i = 0; i < product.order.Count; i++)
                {
                    Console.SetCursorPosition(118, i + 3); // Adjust position as needed
                    Console.WriteLine($"║ {product.order[i].PadRight(23)}║");
                    
                }

                Console.SetCursorPosition(118, product.order.Count + 3);
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

                    if (currentLines == 0) // Add Items
                    {
                        Console.Write("Enter item to be added (by number): ");
                        string itemNumber = Console.ReadLine();
                        Console.Write("Quantity: ");
                        string quantity = Console.ReadLine();
                        
                        if (int.TryParse(itemNumber, out int number) && int.TryParse(quantity, out int dquantity))
                        {
                            int selectedIndex = number - 1; // Adjust for 0-based index
                            
                            int selectedQuantity = product.quantity[selectedIndex];

                            if (dquantity <= selectedQuantity)
                            {
                                product.quantity[selectedIndex] -= dquantity;
                                string itemName = product.productNames[selectedIndex];
                                product.order.Add(itemName + " (Qty: " + quantity + ")");
                                product.values.Add(dquantity);
                                
                            }

                            else
                            {
                                Console.WriteLine("Insufficient quantity!");
                            }
                        }
                            
                    }
                    else if (currentLines == 1) //Edit Item
                    {
                        // ...
                    }
                    else if (currentLines == 2) // Remove Item
                    {
                        Console.WriteLine("Note: from 1 - i. depend on the product added");
                        Console.Write("Enter item to be removed (by number): ");
                        int itemNumber = int.Parse(Console.ReadLine()) - 1;

                        if (itemNumber >= 0 && itemNumber < product.order.Count)
                        {
                            int selectedIndex = itemNumber;
                            //string removedItem = product.order[itemNumber];
                            //product.order.RemoveAt(itemNumber);

                            Console.Write("Enter quantity to be added back: ");
                            int addedQuantity = int.Parse(Console.ReadLine());

                            // Update the quantity in product.quantity
                            product.quantity[selectedIndex] += addedQuantity;

                            //Console.WriteLine("Removing item: " + removedItem);

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
    



