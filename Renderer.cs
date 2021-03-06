﻿using System;
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
            screen.SquareA.Unlight();
            screen.obsticle.Unlight();
            Console.Clear();

            screen.light.CastOn(screen.SquareA.Body, screen.obsticle);
            screen.SquareA.Draw();
            screen.obsticle.Draw();
        }
    }
}
