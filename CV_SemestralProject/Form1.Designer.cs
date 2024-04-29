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
            System.Windows.Forms.Timer timer1;
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
            timer1 = new System.Windows.Forms.Timer(components);
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(465, 549);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 13);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Red;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(367, 516);
            label1.Name = "label1";
            label1.Size = new Size(83, 89);
            label1.TabIndex = 1;
            label1.Text = "IN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(130, 209);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Highlight;
            panel4.Controls.Add(panel3);
            panel4.Location = new Point(465, 295);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(130, 209);
            panel4.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(465, 237);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 13);
            panel2.TabIndex = 4;
            // 
            // label2
            // 
            label2.BackColor = Color.Red;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(367, 197);
            label2.Name = "label2";
            label2.Size = new Size(83, 87);
            label2.TabIndex = 5;
            label2.Text = "OUT";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(674, 473);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 6;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(674, 379);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 7;
            button2.Text = "Wash";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(674, 295);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 8;
            button3.Text = "End";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(150, 348);
            label3.Name = "label3";
            label3.Size = new Size(301, 80);
            label3.TabIndex = 9;
            label3.Text = "Empty";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(183, 29);
            button4.TabIndex = 10;
            button4.Text = "Change bindings";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1101, 812);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
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
