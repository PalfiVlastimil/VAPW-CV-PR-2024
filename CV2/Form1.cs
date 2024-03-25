namespace CV2
{
    public partial class Form1 : Form
    {

        A a;// = new A();
        int red;
        int green;
        int blue;
        Random rand = new Random();
        public Form1()
        {
            a = new A();
            int h = a.Cislo; //getter
            a.Cislo = -11; //setter
            InitializeComponent();
        }
        /*
        private void panel1_Click(object sender, EventArgs e)
        {
            if (panel1.BackColor == System.Drawing.Color.Red)
            {
                panel1.BackColor = System.Drawing.Color.Black;
                return;
            }
            panel1.BackColor = System.Drawing.Color.Red;

        }*/

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            red = rand.Next(0, 255);
            green = rand.Next(0, 255);
            blue = rand.Next(0, 255);
            panel1.BackColor = Color.FromArgb(red, green, blue);
           
        }
    }
}
