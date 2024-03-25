using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV4.Models
{
    public abstract class Geometry
    {
        private int _ox;
        public int OX
        {
            get { return _ox; }
            protected set { _ox = value; }
        }

        private int _oy;
        public int OY
        {
            get { return _oy; }
            protected set { _oy = value; }
        }
        public int PenWidth { get; set; } = 1;
        public Color PenColor { get; set; } = Color.Black;
        public Color FillColor { get; set; }

        protected Geometry(int ox, int oy)
        {
            _ox = ox;
            _oy = oy;
        }
       


        internal virtual void Draw(Graphics graphics) //nebo abstract
        {
            DrawPoint(graphics);
        }
        internal void DrawPoint(Graphics graphics)
        {
            Pen pen = new Pen(PenColor, PenWidth);
            graphics.DrawLine(pen, OX, OY - 5, OX, OY + 5);
            graphics.DrawLine(pen, OX - 5, OY, OX + 5, OY);
        }
    }
}
