using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace POS___Test
{

    internal class Program
    {
        DisplayItems items = new DisplayItems();

        static void Main(string[] args)
        {
            logo logo = new logo();
        productsLinked product = new productsLinked();



            userDetails user = new userDetails();
     
           

                logo.Display();
                Console.WriteLine(" LOGIN");
                Console.Write(" Username: \n Password: ");
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(11, currentLine - 1); // Move the cursor up 3 
            string name = Console.ReadLine();
            Console.SetCursorPosition(11, currentLine - 0); // Move the cursor up 3 
            string pass = Console.ReadLine();


            
            ConsoleKeyInfo keyInfo;
            
            
            do
            {
                int totalPages = (int)Math.Ceiling((double)product.productNames.Count / product.pageSize);
                DisplayItems.DisplayProducts();
                    for (int i = 0; i < product.lines.Length; i++)
                {
                    if (i == product.currentLines)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(" -" + product.lines[i]);

                    Console.ResetColor();
                }
                DisplayItems.DisplayCart();
                keyInfo = Console.ReadKey();

                int currentPage = 1;


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
                    product.currentLines = Math.Max(0, product.currentLines - 1);
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    product.currentLines = Math.Min(product.lines.Length - 1, product.currentLines + 1);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {

                    if (product.currentLines == 0) // Add Items
                    {
                        product.AddItem();

                    }
                    else if (product.currentLines == 1) //Edit Item
                    {
                        // ...
                    }
                    else if (product.currentLines == 2) // Remove Item
                    {
                        product.RemoveItem();
                    }
                    else if (product.currentLines == 3) // Exit
                    {
                        break;
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);



        }
    }
}

