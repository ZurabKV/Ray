using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray.MultipixelObjects
{

    abstract class MultipixelObject
    {
        protected char Shape;
        protected ConsoleColor Color;

        public PixelBody Body;

        public MultipixelObject(char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new PixelBody();
        }

        public virtual void Draw()
        {
            Body.Pixels.Where(p=>p.IsLit).ToList().ForEach(p => p.Draw());
        }

        public void Unlight()
        {
            Body.Pixels.ForEach(p=>p.IsLit=false);
        }

        public List<Pixel> GetSurroundingCells(Pixel pixel)
        {
            return new List<Pixel>
            {
                new Pixel(pixel.x-1,pixel.y-1),
                new Pixel(pixel.x,  pixel.y-1),
                new Pixel(pixel.x+1,pixel.y-1),
                new Pixel(pixel.x-1,pixel.y),
                new Pixel(pixel.x+1,pixel.y),
                new Pixel(pixel.x-1,pixel.y+1),
                new Pixel(pixel.x,  pixel.y+1),
                new Pixel(pixel.x+1,pixel.y+1),
            };
        }
    }
}
