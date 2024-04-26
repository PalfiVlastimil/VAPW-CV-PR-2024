using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV3.Models
{
    internal class Circle : Geometry
    {
        
        private int radius;

        public int Radius
        {
            get { return radius; }
            private set { radius = value; }
        }

        public Circle(int ox, int oy, int radius)
        {
            OX = ox;
            OY = oy;
            this.radius = radius;
        }
        //implementace polygonu
        internal override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black);
            graphics.DrawEllipse(pen, OX-radius, OY - radius, radius * 2, radius * 2);
        }

    }
}
