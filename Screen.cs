using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Screen
    {
        public PlayGround SquareA { get; set; }
        
        public Light light { get; set; }
       
        public Screen()
        {
            SquareA = new PlayGround(80, 20, 0, 0, '#', ConsoleColor.DarkCyan);

            light = new Light(new Pixel(20, 15));
        }
    }
}
