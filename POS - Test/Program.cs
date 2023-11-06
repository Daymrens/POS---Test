using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace POS___Test
{

    internal class Program
    {
        

        static void Main(string[] args)
        {
            Inventory product = new Inventory(); 
            DisplayLogo.Display();
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
                Console.ForegroundColor = ConsoleColor.Yellow;

                Display.DisplayProducts(product);
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


                Display.DisplayCart(product);
                keyInfo = Console.ReadKey();

              


                if (keyInfo.Key == ConsoleKey.LeftArrow && product.currentPage > 1)
                {
                    
                    product.currentPage--;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow && product.currentPage < totalPages)
                {
                    product.currentPage++;
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
                        Console.Write("Enter item to be added (Item Number): ");
                        string itemNumber = Console.ReadLine();
                        Console.Write("Quantity: ");
                        string quantityy = Console.ReadLine();
                        product.AddItem(itemNumber, quantityy);

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

