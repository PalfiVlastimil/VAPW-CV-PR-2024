namespace PR07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("eat my grapes");
            
            form2.Text2 = "nastav text2";

            DialogResult dr;
            dr = form2.ShowDialog();
            if(dr == DialogResult.OK)
            {
                button1.Text = "OK" + form2.Text2;
            }
            else if( dr == DialogResult.Cancel)
            {
                button1.Text = "CANCEL" + form2.Text2;
            }
            else
            {
                button1.Text = "" + dr;
            }

        }
    }
}
