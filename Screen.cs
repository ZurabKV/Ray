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
        public PlayGround SquareA { get; set; }
        
        public Light light { get; set; }

        public Obsticle obsticle { get; set; }
       
        public Screen()
        {
            SquareA = new PlayGround(60, 25, 0, 0, '#', ConsoleColor.DarkCyan);
            light = new Light(new Pixel(20, 15));

            obsticle = new Obsticle(40, 8, 40, 18, '%', ConsoleColor.Green);

        }
    }
}
