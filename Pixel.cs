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

        private bool IsLit { get; set; } = false;

        public char shape;

        public ConsoleColor color { get; set; } = ConsoleColor.White;

        public Pixel(int x, int y, char shape = '.', ConsoleColor color=ConsoleColor.White)
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

        public double DistanceToAnotherPixel(Pixel anotherPixel)
        {
            double distance = Math.Sqrt(Math.Pow(anotherPixel.x - x, 2) + Math.Pow(anotherPixel.y - y, 2));
            return distance;
        }

        public bool IsNotDiagonalToAnotherNearestPixel(Pixel anotherPixel)
        {
            var distanceToAnotherPixel = DistanceToAnotherPixel(anotherPixel);
            return DistanceToAnotherPixel(anotherPixel) == 1;
        }

        public void ChangeLightState()
        {
            IsLit = !IsLit;
        }

        public void Move(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
            }
        }

    }
}
