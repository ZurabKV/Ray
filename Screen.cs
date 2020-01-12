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
        public Wall SquareA { get; set; }
        
        public Light light { get; set; }

        public Obsticle obsticle { get; set; }
       
        public Screen()
        {
            SquareA = new Wall(50, 25, 0, 0, '#', ConsoleColor.DarkCyan);
            light = new Light(new Pixel( 20, 12));

            obsticle = new Obsticle(40, 6, 40, 10, '%', ConsoleColor.Green);

        }
    }
}
