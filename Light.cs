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
        public void CastOn(PixelBody wall, MultipixelObject obsticle)
        {
            Body.rays.Clear();
            GetBody(wall, obsticle);
            Body.rays.ForEach(r => r.Draw());

        }

        private void GetBody(PixelBody wallBody, MultipixelObject obsticle)
        {
            foreach (Pixel wall in wallBody.Pixels)
            {
                LightRay ray = new  LightRay(source, wall, obsticle);
                Body.rays.Add(ray);
            }
        }
    }
}
