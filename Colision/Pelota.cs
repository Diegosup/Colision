using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colision
{
    public class Pelota
    {
        public Size Size { get; set; }
        public Point Location { get; set; }

        public Pelota(Size size, Point location)
        {
            Size = size;
            Location = location;
        }
        public void Update()
        {
           
        }
    }
}
