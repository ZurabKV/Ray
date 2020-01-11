using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Input
    {
        public static void AcceptInput(Screen screen)
        {

            ConsoleKeyInfo key = Console.ReadKey();

            screen.light.source.Move(key);
        }
    }
}
