using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.MultipixelObjects;

namespace Ray
{
    class PixelBody
    {
        public List<Pixel> Pixels { get; set; }
        public PixelBody()
        {
            Pixels = new List<Pixel>();
        }
    }
}
