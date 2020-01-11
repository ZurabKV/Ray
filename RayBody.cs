using Ray.MultipixelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    class RayBody
    {
        public List<LightRay> rays { get; set; }
        public RayBody()
        {
            rays = new List<LightRay>();
        }
    }
}
