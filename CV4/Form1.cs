using CV4.Models;
using Rectangle = CV4.Models.Rectangle;

namespace CV4
{
    public partial class Form1 : Form
    {
        //Circle c1, c2;
        //List<Circle> circles = new List<Circle>();
        //List<Rectangle> rectangles = new List<Rectangle>();
        List<Geometry> geometries = new List<Geometry>();
        List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { nameof(Circle), nameof(Rectangle), nameof(Polygon) });

        }

        private void button1_Click(object sender, EventArgs e)
        {

            geometries.Add(new Circle(100, 80, 25));
            geometries.Add(new Circle(150, 220, 50));
            geometries.Add(new Rectangle(50, 50, 100, 100));
            geometries.Add(new Rectangle(200, 200, 300, 300));
            geometries.Add(new Polygon(new List<Point> { new Point(100, 100), new Point(200, 100), new Point(150, 200), new Point(200, 200) }));
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*c1?.Draw(e.Graphics);
            c2?.Draw(e.Graphics);*/
            //circles.ForEach(c => c.Draw(e.Graphics));
            //rectangles.ForEach(r => r.Draw(e.Graphics));
            geometries.ForEach(g => g.Draw(e.Graphics));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
            }


            if (points.Count == 2 && comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == nameof(Circle))
                {
                    geometries.Add(new Circle(points[0].X, points[0].Y,
                        (int)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2)), (int)numericUpDown1.Value, panel1.BackColor));
                    points.Clear();
                    Invalidate();
                }
                else if (comboBox1.SelectedItem.ToString() == nameof(Rectangle))
                {
                    geometries.Add(new Rectangle(points[0].X, points[0].Y, points[1].X, points[1].Y, (int)numericUpDown1.Value, panel1.BackColor));
                    points.Clear();
                    Invalidate();
                }
            }
            else if (points.Count > 2
                && e.Button == MouseButtons.Right
                && comboBox1.SelectedItem != null
                && comboBox1.SelectedItem.ToString() == nameof(Polygon))
            {
                geometries.Add(new Polygon(points, (int)numericUpDown1.Value, panel1.BackColor));
                points.Clear();
                Invalidate();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            points.Clear();
            Invalidate();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;

            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            foreach(var item in geometries)
            {
                var isNear = (e.X >= item.OX - 10 && e.X <= item.OX + 10 && e.Y >= item.OY - 10 && e.Y <= item.OY + 10);
                item.Selected = isNear;
            }
            Invalidate();
            
        }
    }
}
