namespace formchinh
{
    partial class Formchinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbhello = new Label();
            panel1 = new Panel();
            lbtieude = new Label();
            lbname = new Label();
            lbemail = new Label();
            lblast = new Label();
            lbdate = new Label();
            exit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbhello
            // 
            lbhello.AutoSize = true;
            lbhello.Font = new Font("Segoe UI", 13F);
            lbhello.Location = new Point(21, 144);
            lbhello.Name = "lbhello";
            lbhello.Size = new Size(71, 30);
            lbhello.TabIndex = 0;
            lbhello.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(lbtieude);
            panel1.Location = new Point(-4, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(802, 116);
            panel1.TabIndex = 1;
            // 
            // lbtieude
            // 
            lbtieude.AutoSize = true;
            lbtieude.Font = new Font("Segoe UI", 13F);
            lbtieude.ForeColor = SystemColors.Control;
            lbtieude.Location = new Point(25, 36);
            lbtieude.Name = "lbtieude";
            lbtieude.Size = new Size(71, 30);
            lbtieude.TabIndex = 6;
            lbtieude.Text = "label6";
            // 
            // lbname
            // 
            lbname.AutoSize = true;
            lbname.Font = new Font("Segoe UI", 13F);
            lbname.Location = new Point(21, 214);
            lbname.Name = "lbname";
            lbname.Size = new Size(71, 30);
            lbname.TabIndex = 2;
            lbname.Text = "label2";
            // 
            // lbemail
            // 
            lbemail.AutoSize = true;
            lbemail.Font = new Font("Segoe UI", 13F);
            lbemail.Location = new Point(21, 273);
            lbemail.Name = "lbemail";
            lbemail.Size = new Size(71, 30);
            lbemail.TabIndex = 3;
            lbemail.Text = "label3";
            // 
            // lblast
            // 
            lblast.AutoSize = true;
            lblast.Font = new Font("Segoe UI", 13F);
            lblast.Location = new Point(21, 323);
            lblast.Name = "lblast";
            lblast.Size = new Size(71, 30);
            lblast.TabIndex = 4;
            lblast.Text = "label4";
            // 
            // lbdate
            // 
            lbdate.AutoSize = true;
            lbdate.Font = new Font("Segoe UI", 13F);
            lbdate.Location = new Point(21, 386);
            lbdate.Name = "lbdate";
            lbdate.Size = new Size(71, 30);
            lbdate.TabIndex = 5;
            lbdate.Text = "label5";
            // 
            // exit
            // 
            exit.Location = new Point(619, 361);
            exit.Name = "exit";
            exit.Size = new Size(132, 50);
            exit.TabIndex = 6;
            exit.Text = "Đăng xuất";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // Formchinh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exit);
            Controls.Add(lbdate);
            Controls.Add(lblast);
            Controls.Add(lbemail);
            Controls.Add(lbname);
            Controls.Add(panel1);
            Controls.Add(lbhello);
            Name = "Formchinh";
            Text = "formchinh";
            Load += formchinh_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbhello;
        private Panel panel1;
        private Label lbtieude;
        private Label lbname;
        private Label lbemail;
        private Label lblast;
        private Label lbdate;
        private Button exit;
    }
}