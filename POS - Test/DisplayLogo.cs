using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace POS___Test
{
    internal class DisplayLogo
    {

        public static void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(60, 5);
                Console.WriteLine("══════════════════════════════");
            Console.SetCursorPosition(60, 6);
            Console.WriteLine(@"  ██████╗  ██████╗ ███████╗");
            Console.SetCursorPosition(60, 7);
            Thread.Sleep(50);
                Console.WriteLine(@"  ██╔══██╗██╔═══██╗██╔════╝");
            Console.SetCursorPosition(60, 8);
            Thread.Sleep(50);
                Console.WriteLine(@"  ██████╔╝██║   ██║███████╗");
            Console.SetCursorPosition(60, 9);
            Thread.Sleep(50);
                Console.WriteLine(@"  ██╔═══╝ ██║   ██║╚════██║");
            Console.SetCursorPosition(60, 10);
            Thread.Sleep(50);
                Console.WriteLine(@"  ██║     ╚██████╔╝███████║");
            Console.SetCursorPosition(60, 11);
            Thread.Sleep(50);
                Console.WriteLine(@"  ╚═╝      ╚═════╝ ╚══════╝");
            Console.SetCursorPosition(60, 12);
            Thread.Sleep(50);
                Console.WriteLine("══════════════════════════════");
            Console.SetCursorPosition(60, 13);
            Thread.Sleep(50);
                
           
            
            //hotdog

        }
    }
}
