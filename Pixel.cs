using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class Pixel
    {
        public int x;
        public int y;

        public char shape;

        public ConsoleColor color { get; set; } = ConsoleColor.White;

        public Pixel(int x, int y, char shape, ConsoleColor color=ConsoleColor.White)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.shape = shape;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(shape);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
