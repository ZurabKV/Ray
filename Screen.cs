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
        public Line lineA { get; set; }
        public Screen()
        {
            SquareA = new PlayGround(40, 30, 0, 0, '#', ConsoleColor.DarkCyan);
            lineA = new Line(3, 16, 9, 3);
        }
    }
}
