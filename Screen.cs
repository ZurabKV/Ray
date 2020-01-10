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
        public Screen()
        {
            SquareA = new PlayGround(40, 15, 0, 0, '#', ConsoleColor.DarkCyan);
        }
    }
}
