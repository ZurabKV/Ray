using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray
{
    static class Renderer
    {
        public static void DrawScreen(Screen screen)
        {
            Console.Clear();
            screen.SquareA.Draw();
            screen.light.CastOn(screen.SquareA.Body);
        }
    }
}
