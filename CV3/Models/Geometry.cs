using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV3.Models
{
    public abstract class Geometry
    {
        private int ox;

        public int OX
        {
            get { return ox; }
            protected set { ox = value; }
        }
        private int oy;

        public int OY
        {
            get { return oy; }
            protected set { oy = value; }
        }

        internal abstract void Draw(Graphics graphics);
    }
}
