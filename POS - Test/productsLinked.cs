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
        public LinkedList<int> cart = new LinkedList<int>();
        public Stack<int> order = new Stack<int>();
        public bool repeat = false;

        public void ProductsinCart(int value)
        {
            cart.AddLast(value); 
        }
        public void Quantity(int qty)
        {
            order.Push(qty);
        }
        public void DisplayProductName()
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
           
        }

        public void DisplayQuantity()
        {
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
        }

        public void DisplayPrice()
        {
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

        public void AddFirst(string prodName)
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

        public void Find(List<string> listt, string prodNumber)
        {
            
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
            int count = 0;
            string pad = "║";
            foreach (var item in list)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    count++;
                    break;
                }
                Console.Write("[{0}]" + item + pad.PadLeft(20) + "\n " + pad.PadLeft(2), count);
            }        
        }

    }
}
