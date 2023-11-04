using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS___Test
{
    internal class productsLinked
    {


        public List<string> productNames { get; set; }
        public List<int> quantity { get; set; }
        public List<int> price { get; set; }

        public List<(string productName, int quantityInCart)> cartItems { get; private set; } = new List<(string, int)>();
        public List<int> removedQuantities { get; private set; } // New list to track removed quantities
        public string[] lines = { "Add", "Edit", "Remove", "Search" };
        public int currentLines = 0;

        public int pageSize = 10;
        // Constructor
        public productsLinked()
        {
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
            quantity = new List<int>()
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
            price = new List<int>()
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
        }

        public void AddItem()
        {
            Console.Write("Enter item to be added (Item Number): ");
            string itemNumber = Console.ReadLine();
            Console.Write("Quantity: ");
            string quantityy = Console.ReadLine();
            if (int.TryParse(itemNumber, out int number) && int.TryParse(quantityy, out int dquantity))
            {
                int selectedIndex = number - 1; // Adjust for 0-based index

                int selectedQuantity = quantity[selectedIndex];

                if (dquantity <= selectedQuantity)
                {
                    AddToCart(productNames[selectedIndex], dquantity);
                }
                else
                {
                    Console.WriteLine("Insufficient quantity!");
                }
            }
        }
        public void RemoveItem()
        {
            Console.WriteLine("Note: always star from Zero[0]");
            Console.Write("Enter item to be removed: ");
            int itemNumber = int.Parse(Console.ReadLine());

            if (itemNumber >= 0 && itemNumber < cartItems.Count)
            {
                Console.Write("Enter quantity to be added back: ");
                int addedQuantity = int.Parse(Console.ReadLine());

                RemoveFromCart(productNames[itemNumber], addedQuantity);

            }

            else
            {
                Console.WriteLine("Invalid item number!");
            }
        }

        public void AddToCart(string productName, int quantity)
        {
            int index = productNames.IndexOf(productName);
            if (index != -1 && quantity <= this.quantity[index])
            {
                this.quantity[index] -= quantity;

                if (cartItems == null)
                {
                    cartItems = new List<(string, int)>();
                }

                var cartItem = cartItems.FirstOrDefault(item => item.productName == productName);
                if (cartItem != default)
                {
                    cartItems.Remove(cartItem);
                    cartItem.quantityInCart += quantity;
                    cartItems.Add(cartItem);
                }
                else
                {
                    cartItems.Add((productName, quantity));
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please try again.");
            }
        }

        public void RemoveFromCart(string productName, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(item => item.productName == productName);
            if (cartItem != default && quantity <= cartItem.quantityInCart)
            {
                this.quantity[productNames.IndexOf(productName)] += quantity;
                cartItems.Remove(cartItem);
                cartItems.Add((productName, cartItem.quantityInCart - quantity));

                // Add removed quantity to the list
                //removedQuantities.Add(quantity);

            }
            else
            {
                Console.WriteLine("Invalid input! Please try again.");
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

