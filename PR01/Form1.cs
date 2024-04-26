namespace PR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button2 = new Button();
            button2.Location = new Point(x, 10);
            x += 100;
            button2.Name = "button1";
            button2.Size = new Size(94, 123);
            button2.TabIndex = 0;
            button2.Text = "moje tlacitko";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonJeToJednoSJmenem;
            Controls.Add(button2);
            //
        }

        private void buttonJeToJednoSJmenem(object? sender, EventArgs e)
        {
            MessageBox.Show("Stoopid dotaz", "whuh?", MessageBoxButtons.CancelTryContinue);
        }

        
    }
}
