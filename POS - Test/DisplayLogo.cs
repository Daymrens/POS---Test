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
            Console.WriteLine("══════════════════════════════");
            Console.WriteLine(@"  ██████╗  ██████╗ ███████╗");
            Thread.Sleep(50);
            Console.WriteLine(@"  ██╔══██╗██╔═══██╗██╔════╝");
            Thread.Sleep(50);
            Console.WriteLine(@"  ██████╔╝██║   ██║███████╗");
            Thread.Sleep(50);            
            Console.WriteLine(@"  ██╔═══╝ ██║   ██║╚════██║");
            Thread.Sleep(50);
            Console.WriteLine(@"  ██║     ╚██████╔╝███████║");
            Thread.Sleep(50);
            Console.WriteLine(@"  ╚═╝      ╚═════╝ ╚══════╝");
            Thread.Sleep(50);
            Console.WriteLine("══════════════════════════════");
            Thread.Sleep(50);
            //hotdog

        }
    }
}
