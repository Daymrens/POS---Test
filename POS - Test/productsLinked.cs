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
        public List<string> order = new List<string>();
        public List<int> values = new List<int>();

      
     
       

   
        

    
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

