using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV4.Models
{
    internal class Polygon : Geometry
    {
        private List<Point> points = new List<Point>();
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }
        public int PenWidth { get; set; }
        public Color PenColor { get; set; }
        public Color FillColor { get; set; }
        public Polygon(List<Point> points) : base((int)points.Average(p => p.X), (int)points.Average(p => p.Y))
        {
            points.ForEach(p => this.points.Add(p));

        }
        public Polygon(List<Point> points, int penWidth)
            : this(points)
        {
            PenWidth = penWidth;
        }
        public Polygon(List<Point> points, int penWidth, Color penColor)
            : this(points, penWidth)
        {
            PenColor = penColor;
        }
        public Polygon(List<Point> points, int penWidth, Color penColor, Color fillColor)
            : this(points, penWidth, penColor)
        {
            FillColor = fillColor;
        }
        /* Metody pro získání středových souřadnic tvaru
        public Polygon(List<Point> points) : base(GetOX(points), GetOY(points))
        {
            this.points = points;
        }
        
        private static int GetOX(List<Point> points)
        {
            int sumX = 0;
            int n = points.Count;

            for (int i = 0; i < n; i++)
            {
                sumX += points[i].X;
            }

            return (sumX / n);
        }
        private static int GetOY(List<Point> points)
        {
            int sumY = 0;
            int n = points.Count;

            for (int i = 0; i < n; i++)
            {
                sumY += points[i].Y;
            }

            return (sumY / n);
        }*/

        internal override void Draw(Graphics graphics)
        {
            base.DrawPoint(graphics);
            var pen = new Pen(PenColor, PenWidth);
            graphics.DrawPolygon(pen, points.ToArray());
        }
    }
}
