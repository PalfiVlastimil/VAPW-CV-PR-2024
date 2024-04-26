using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV3.Models
{
    internal class Rectangle : Geometry
    {
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            OX = (x1 + x2) / 2;
            OY = (y1 + y2) / 2;
            this.width = x2 - x1;
            this.height = y2 - y1;
        }

        internal override void Draw(Graphics graphics)
        {
            var pen = new Pen(Color.Black, 2);
            graphics.DrawRectangle(pen, OX - (Width /2), OY - (Height /2), Width, Height);

        }


    }

    }
