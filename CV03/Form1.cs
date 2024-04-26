using CV3.Models;
using Rectangle = CV3.Models.Rectangle;

namespace CV3
{
    public partial class Form1 : Form
    {
        //Circle c1, c2;
        List<Circle> circles = new List<Circle>();
        List<Rectangle> rectangles = new List<Rectangle>();
        List<Geometry> items = new List<Geometry>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            c1 = new Circle(100, 80, 25);
            c2 = new Circle(150, 220, 50);
            
            */
            circles.Add(new Circle(100, 80, 25));
            circles.Add(new Circle(150, 220, 50));


            rectangles.Add(new Rectangle(50, 50, 100,100 ));
            rectangles.Add(new Rectangle(120, 120, 200,200 ));

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*
            if(c1 is not null)
            {
                c1.Draw(e.Graphics);
            }
            c2?.Draw(e.Graphics);*/
            circles.ForEach(c => c.Draw(e.Graphics));
            rectangles.ForEach(r => r.Draw(e.Graphics));
            for (int i = 0; i < items.Count; i++)
            {
                /*
                if (items[i] is Circle)
                {
                    (items[i] as Circle).Draw(e.Graphics);
                }
                if (items[i] is Rectangle)
                {
                    (items[i] as Rectangle).Draw(e.Graphics);
                }
                */
                items[i].Draw(e.Graphics);
            }
        }
    }
}
