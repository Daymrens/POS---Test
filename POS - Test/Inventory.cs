using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace POS___Test
{
    internal class Inventory
    {


        public List<string> productNames { get; set; }
        public List<int> quantity { get; set; }
        public List<int> price { get; set; }

        public List<(string productName, int quantityInCart)> cartItems { get; private set; } = new List<(string, int)>();
        public List<int> removedQuantities { get; private set; } // New list to track removed quantities
        public string[] linesEmployee = { "Add", "Search", "Admin" };
        public string[] linesAdmin = { "Add", "Edit", "Remove", "Search", "Exit" };
        public int currentLines = 0;
        public int currentPage = 1;
        public int pageSize = 10;
        // Constructor
        public Inventory()
        {
            removedQuantities = new List<int>();
            productNames = new List<string>()
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
            "C2 Small",
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
            quantity = new List<int>()
            {
            102,
            53,
            814,
            35,
            132,
            623,
            37,
            329,
            254,
            45,
            232,
            99,
            85,
            334,
            142,
            621,
            73,
            93,
            234,
            425,
            105,
            535,
            85,
            325,
            124,
            64,
            74,
            93,
            233,
            43,
            };
            price = new List<int>()
            {
            200,
            100,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            100,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            100,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            200,
            };
            cartItems = new List<(string productName, int quantityInCart)>();
        }

        static void Wait()
        {
            Console.WriteLine("Press any key to continue.... or wait 5 sec.");
            for (int i = 0; i < 5; i++)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                    return;
                }

                if (i == 4)
                {
                    return;
                }
                Thread.Sleep(1000);
            }
        }

        public void AddItem(string itemNumber, string quantityy)
        {

            if (int.TryParse(itemNumber, out int number) && int.TryParse(quantityy, out int dquantity))
            {
                int selectedIndex = number - 1; // Adjust for 0-based index

                if (selectedIndex >= 0 && selectedIndex < productNames.Count)
                {
                    int selectedQuantity = quantity[selectedIndex];

                    if (dquantity <= selectedQuantity)
                    {
                        AddToCart(productNames[selectedIndex], dquantity);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient quantity!");
                        Wait();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item number! Please enter a valid item number.");
                    Wait();
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter valid numbers for item number and quantity.");
                Wait();
            }
        }
        public void RemoveItem()
        {
            if (cartItems == null || cartItems.Count == 0)
            {
                Console.WriteLine("Cart is empty. Cannot remove items.");
                Wait();
                return; // Exit the method
            }
            while (true) // Infinite loop
            {
                Console.Write("Enter item to be removed: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int itemNumber) && itemNumber >= 0 && itemNumber < cartItems.Count)
                {
                    Console.Write("Enter quantity to be added back: ");
                    string quantityInput = Console.ReadLine();

                    if (int.TryParse(quantityInput, out int addedQuantity))
                    {
                        RemoveFromCart(cartItems[itemNumber].productName, addedQuantity);
                        break; // Exit the loop if successful
                    }

                    else
                    {
                        Console.WriteLine("Invalid quantity input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid item number!");
                    ClearLine();
                }
            }
        }

        static void ClearLine()
        {
            int currentLine = Console.CursorTop; // Get the current line
            Console.SetCursorPosition(0, currentLine - 2); // Move the cursor
            for (int j = 0; j < 2; j++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }

            // Move the cursor back to the original position
            Console.SetCursorPosition(0, currentLine - 2);
        }

        public void AddToCart(string productName, int quantityy)
        {
            int index = productNames.IndexOf(productName);
            if (index != -1 && quantityy <= this.quantity[index])
            {
                this.quantity[index] -= quantityy;

                if (cartItems == null)
                {
                    cartItems = new List<(string, int)>();
                }

                var cartItem = cartItems.FirstOrDefault(item => item.productName == productName);
                if (cartItem != default)
                {
                    cartItems.Remove(cartItem);
                    cartItem.quantityInCart += quantityy;
                    cartItems.Add(cartItem);
                }
                else
                {
                    cartItems.Add((productName, quantityy));
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please try again.");
            }
        }

        public void RemoveFromCart(string productName, int quantityy)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.productName == productName);
            if (cartItem != default && quantityy <= cartItem.quantityInCart)
            {
                int index = productNames.IndexOf(productName);
                quantity[index] += quantityy;

                //quantity[productNames.IndexOf(productName)] += quantityy;

                cartItems.Remove(cartItem);

                cartItems.Add((productName, cartItem.quantityInCart - quantityy));

                // Add removed quantity to the list
                removedQuantities.Add(quantityy);

            }
            else
            {
                Console.WriteLine("Invalid input! Please try again.");
                Thread.Sleep(500);
            }


        }







        public void FindRelevance(List<string> list, string prodName)
        {
            foreach (var item in list)
            {
                if (HasRelevance(item, prodName))
                {
                    Console.WriteLine(item);

                }
            }
        }
        static bool HasRelevance(string list, string prodName)
        {
            // Define your criterion for relevance here.
            return list.IndexOf(prodName, StringComparison.OrdinalIgnoreCase) >= 0; // For example, consider names containing the targetName as relevant.
        }




    }

}

