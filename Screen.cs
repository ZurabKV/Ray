using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.MultipixelObjects;

namespace Ray
{
    class Screen
    {
        public Walls SquareA { get; set; }
        
        public Light light { get; set; }

        public Obsticle obsticle { get; set; }
       
        public Screen()
        {
            SquareA = new Walls(50, 25, 0, 0, '#', ConsoleColor.DarkCyan);
            light = new Light(new Pixel(20, 12, 'O', ConsoleColor.Cyan), '.', ConsoleColor.DarkYellow);

            obsticle = new Obsticle('%', ConsoleColor.Green);
            obsticle.AddLineBody(new Pixel(33, 6, '%', ConsoleColor.DarkGreen), new Pixel(40, 20));

        }
    }
}
