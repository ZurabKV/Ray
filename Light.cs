using Ray.MultipixelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ray
{
     
    class Light
    {
        public Pixel source { get; set; }

        private RayBody Body { get; set; }

        private char Shape;
        private ConsoleColor Color;

        public Light(Pixel lightSource, char shape, ConsoleColor color)
        {
            Shape = shape;
            Color = color;
            Body = new RayBody();
            source = lightSource;
        }
        public void CastOn(PixelBody wall, MultipixelObject obsticle)
        {
            Body.rays.Clear();
            GetBody(wall, obsticle);
            Body.rays.ForEach(r => r.Draw());
            source.Draw();
        }

        private void GetBody(PixelBody wallBody, MultipixelObject obsticle)
        {
            foreach (Pixel wall in wallBody.Pixels)
            {
                LightRay ray = new  LightRay(source, wall, obsticle, Shape, Color);
                Body.rays.Add(ray);
            }
        }
    }
}
