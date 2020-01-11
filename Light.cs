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
        public void CastOn(PixelBody surface)
        {
            Body.Pixels.Clear();
            GetBody(surface);
            Body.Pixels.ForEach(p => p.Draw());
        }

        private void GetBody(PixelBody surface)
        {
            foreach (Pixel wall in surface.Pixels)
            {
                Ray ray = new Ray(source.x, source.y, wall.x, wall.y);
                Body.Pixels.AddRange(ray.Body.Pixels);
            }
        }
    }
}
