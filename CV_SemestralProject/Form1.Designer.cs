namespace CV_SemestralProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label3 = new Label();
            button4 = new Button();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(407, 412);
            panel1.Name = "panel1";
            panel1.Size = new Size(114, 10);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Red;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(321, 387);
            label1.Name = "label1";
            label1.Size = new Size(73, 67);
            label1.TabIndex = 1;
            label1.Text = "IN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(114, 157);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Highlight;
            panel4.Controls.Add(panel3);
            panel4.Location = new Point(407, 221);
            panel4.Name = "panel4";
            panel4.Size = new Size(114, 157);
            panel4.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(407, 178);
            panel2.Name = "panel2";
            panel2.Size = new Size(114, 10);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.BackColor = Color.Red;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(321, 148);
            label2.Name = "label2";
            label2.Size = new Size(73, 65);
            label2.TabIndex = 5;
            label2.Text = "OUT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(590, 355);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(590, 284);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Wash";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(590, 221);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "End";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(131, 261);
            label3.Name = "label3";
            label3.Size = new Size(263, 60);
            label3.TabIndex = 9;
            label3.Text = "Empty";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button4
            // 
            button4.Location = new Point(10, 9);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(160, 30);
            button4.TabIndex = 10;
            button4.Text = "Change bindings";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(963, 609);
            Controls.Add(button4);
            Controls.Add(panel4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private Panel panel4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private Button button4;
    }
}
