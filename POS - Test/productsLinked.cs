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

        public List<string> list = new List<string>();
        public List<string> productNames = new List<string>();
        public List<int> quantity = new List<int>();
        public List<int> price = new List<int>();
        public List<(string productName, int quantityInCart)> cartItems { get; private set; } = new List<(string, int)>();
        public List<int> removedQuantities { get; private set; } // New list to track removed quantities
        public string[] lines = { "Add", "Edit", "Remove", "Search" };
        public int currentLines = 0;
        public int currentPage = 1;
        public int pageSize = 10;


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


        public void Add(string prodName)
        {
            list.Add(prodName);
            return;
            
        }

        public void AddLast(string prodName)
        {
            list.Add(prodName);
            return;
        }

        public void Remove(string prodName)
        {
            list.Remove(prodName);
            return;
        }

    
        public void FindRelevance(List<string> list, string prodName)
        {            
            foreach (var item in list)
            {
              if(HasRelevance(item, prodName))
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




        public void Display() 
        {
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            }        
        }

    }

