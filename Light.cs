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

        private PixelBody Body { get; set; }

        public Light(Pixel lightSource)
        {
            Body = new PixelBody();
            source = lightSource;
        }
        public void LightOn(PixelBody surface)
        {
            GetBody(surface);
            Body.Pixels.ForEach((p) => { p.Draw(); Thread.Sleep(5); });
        }

        private void GetBody(PixelBody surface)
        {
            foreach (Pixel wall in surface.Pixels)
            {
                Line ray = new Line(source.x, source.y, wall.x, wall.y);
                Body.Pixels.AddRange(ray.Body.Pixels);
            }
        }
    }
}
