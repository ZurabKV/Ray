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

        public Light(Pixel lightSource)
        {
            Body = new RayBody();
            source = lightSource;
        }
        public void CastOn(PixelBody surface)
        {
            Body.rays.Clear();
            GetBody(surface);
            Body.rays.ForEach(r => r.Draw());

        }

        private void GetBody(PixelBody surface)
        {
            foreach (Pixel wall in surface.Pixels)
            {
                LightRay ray = new LightRay(source.x, source.y, wall.x, wall.y);
                Body.rays.Add(ray);
            }
        }
    }
}
