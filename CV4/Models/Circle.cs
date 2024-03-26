using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV4.Models
{
    internal class Circle : Geometry
    {
        private int _radius;
        public int Radius
        {
            get { return _radius; }
            private set { _radius = value; }
        }
        public int PenWidth { get; set; }
        public Color PenColor { get; set; }
        public Color FillColor { get; set; }

        public Circle(int ox, int oy)
            : base (ox, oy)
        {
        }
        public Circle(int ox, int oy, int radius)
            : this(ox, oy)
        {
            Radius = radius;
        }
        public Circle(int ox, int oy, int radius, int penWidth)
            : this(ox, oy, radius)
        {
            PenWidth = penWidth;
        }
        public Circle(int ox, int oy, int radius, int penWidth, Color penColor)
            : this(ox, oy, radius, penWidth)
        {
            PenColor = penColor;
        }
        public Circle(int ox, int oy, int radius, int penWidth, Color penColor, Color fillColor)
            : this(ox, oy, radius, penWidth)
        {
            FillColor = fillColor;
        }

        internal override void Draw(Graphics graphics)
        {
            DrawPoint(graphics);
            graphics.DrawEllipse(new Pen(PenColor, PenWidth), OX - Radius, OY - Radius, 2 * Radius, 2 * Radius);
        }

        protected internal override void DrawHover(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
