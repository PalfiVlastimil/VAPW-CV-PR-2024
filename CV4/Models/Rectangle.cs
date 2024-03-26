using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV4.Models
{
    internal class Rectangle : Geometry
    {

        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Rectangle(int x1, int y1, int x2, int y2) : base((x1 + x2) / 2, (y2 + y1) / 2)
        {
            _width = Math.Abs(x2 - x1);
            _height = Math.Abs(y2 - y1);
        }
        public int PenWidth { get; set; }
        public Color PenColor { get; set; }
        public Color FillColor { get; set; }

        public Rectangle(int x1, int y1, int x2, int y2, int penWidth)
            : this(x1,y1,x2,y2)
        {
            PenWidth = penWidth;
        }
        public Rectangle(int x1, int y1, int x2, int y2, int penWidth, Color penColor)
            : this(x1, y1, x2, y2, penWidth)
        {
            PenColor = penColor;
        }
        public Rectangle(int x1, int y1, int x2, int y2, int penWidth, Color penColor, Color fillColor)
            : this(x1, y1, x2, y2, penWidth, penColor)
        {
            FillColor = fillColor;
        }

        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawRectangle(pen, OX - Width / 2, OY - Height / 2, Width, Height);
        }

        protected internal override void DrawHover(Graphics graphics)
        {
            var pen = new Pen(Color.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            graphics.DrawRectangle(pen, OX - Width  / 2 - 2, OY - Height  / 2 - 2, Width+4, Height+4);


            
        }
    }
}
