using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
            "Product1",
            "Product2",
            "Product3",
            "Product4",
            "Product5",
            "Product6",
            "Product7",
            "Product8",
            "Product9",
            "Product10",
            "Product11",
            "Product12",
            "Product13",
            "Product14",
            "Product15",
            "Product16",
            "Product17",
            "Product18",
            "Product19",
            "Product20",
            "Product21",
            "Product22",
            "Product23",
            "Product24",
            "Product25",
            "Product26",
            "Product27",
            "Product28",
            "Product29",
            "Product30",
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

        public void Find(List<string> list, string prodName)
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
