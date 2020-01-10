using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class PlayGround
    {
        private int SizeX;

        private int SizeY;

        private int StartingX;

        private int StartingY;

        private char Shape;

        private ConsoleColor Color { get; set; }

        private PixelBody Body { get; set; }

        public PlayGround(int sizeX, int sizeY, int startX, int startY, char shape, ConsoleColor color)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            StartingX = startX;
            StartingY = startY;
            Shape = shape;
            Color = color;
            Body = new PixelBody();
            GenerateBody();
        }

        public void Draw()
        {
            Body.Pixels.ForEach(p => p.Draw());
        }

        private void GenerateBody()
        {
            int topBorder = StartingY+1;
            int bottomBorder = StartingY + SizeY;
            int leftBorder = StartingX+1;
            int RightBorder = StartingX + SizeX;

            for (int cursorY = topBorder; cursorY <= bottomBorder; cursorY++)
            {
                for (int cursorX = leftBorder; cursorX <= RightBorder; cursorX++)
                {
                    if (cursorY == topBorder || cursorY == bottomBorder || cursorX == leftBorder || cursorX == RightBorder) //checks if cursor is on first or last position
                    {
                        Body.Pixels.Add(new Pixel(cursorX - 1, cursorY - 1, Shape));
                    }
                }
            }
        }
    }
}
