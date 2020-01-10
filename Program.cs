using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Program
    {
        static Screen screen = new Screen();
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Renderer.DrawScreen(screen);
        }
    }
}
