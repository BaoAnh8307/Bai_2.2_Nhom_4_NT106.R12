namespace QuanLyNguoiDung
{
    partial class FormDangKy
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblHoVaTen = new System.Windows.Forms.Label();
            txtHoVaTen = new System.Windows.Forms.TextBox();
            lblLoiHoVaTen = new System.Windows.Forms.Label();
            lblTenDangNhap = new System.Windows.Forms.Label();
            txtTenDangNhap = new System.Windows.Forms.TextBox();
            lblLoiTenDangNhap = new System.Windows.Forms.Label();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblLoiEmail = new System.Windows.Forms.Label();
            lblMatKhau = new System.Windows.Forms.Label();
            txtMatKhau = new System.Windows.Forms.TextBox();
            lblLoiMatKhau = new System.Windows.Forms.Label();
            lblXacNhanMatKhau = new System.Windows.Forms.Label();
            txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            lblLoiXacNhanMatKhau = new System.Windows.Forms.Label();
            lblLoi = new System.Windows.Forms.Label();
            btnDangKy = new System.Windows.Forms.Button();
            btnHuy = new System.Windows.Forms.Button();
            lnkDangNhap = new System.Windows.Forms.LinkLabel();
            SuspendLayout();
            //
            // lblHoVaTen
            //
            lblHoVaTen.AutoSize = true;
            lblHoVaTen.Location = new System.Drawing.Point(20, 24);
            lblHoVaTen.Name = "lblHoVaTen";
            lblHoVaTen.Size = new System.Drawing.Size(66, 20);
            lblHoVaTen.TabIndex = 0;
            lblHoVaTen.Text = "Họ và tên";
            //
            // txtHoVaTen
            //
            txtHoVaTen.Location = new System.Drawing.Point(150, 20);
            txtHoVaTen.MaxLength = 50;
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.PlaceholderText = "Nguyễn Văn A";
            txtHoVaTen.Size = new System.Drawing.Size(220, 27);
            txtHoVaTen.TabIndex = 1;
            //
            // lblLoiHoVaTen
            //
            lblLoiHoVaTen.ForeColor = System.Drawing.Color.Firebrick;
            lblLoiHoVaTen.Location = new System.Drawing.Point(150, 50);
            lblLoiHoVaTen.Name = "lblLoiHoVaTen";
            lblLoiHoVaTen.Size = new System.Drawing.Size(220, 34);
            lblLoiHoVaTen.TabIndex = 2;
            //
            // lblTenDangNhap
            //
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new System.Drawing.Point(20, 94);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new System.Drawing.Size(99, 20);
            lblTenDangNhap.TabIndex = 3;
            lblTenDangNhap.Text = "Tên đăng nhập";
            //
            // txtTenDangNhap
            //
            txtTenDangNhap.Location = new System.Drawing.Point(150, 90);
            txtTenDangNhap.MaxLength = 20;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "3-20 ký tự";
            txtTenDangNhap.Size = new System.Drawing.Size(220, 27);
            txtTenDangNhap.TabIndex = 4;
            //
            // lblLoiTenDangNhap
            //
            lblLoiTenDangNhap.ForeColor = System.Drawing.Color.Firebrick;
            lblLoiTenDangNhap.Location = new System.Drawing.Point(150, 120);
            lblLoiTenDangNhap.Name = "lblLoiTenDangNhap";
            lblLoiTenDangNhap.Size = new System.Drawing.Size(220, 34);
            lblLoiTenDangNhap.TabIndex = 5;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(20, 164);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(46, 20);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.Location = new System.Drawing.Point(150, 160);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "ten@mien.com";
            txtEmail.Size = new System.Drawing.Size(220, 27);
            txtEmail.TabIndex = 7;
            //
            // lblLoiEmail
            //
            lblLoiEmail.ForeColor = System.Drawing.Color.Firebrick;
            lblLoiEmail.Location = new System.Drawing.Point(150, 190);
            lblLoiEmail.Name = "lblLoiEmail";
            lblLoiEmail.Size = new System.Drawing.Size(220, 34);
            lblLoiEmail.TabIndex = 8;
            //
            // lblMatKhau
            //
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new System.Drawing.Point(20, 234);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new System.Drawing.Size(67, 20);
            lblMatKhau.TabIndex = 9;
            lblMatKhau.Text = "Mật khẩu";
            //
            // txtMatKhau
            //
            txtMatKhau.Location = new System.Drawing.Point(150, 230);
            txtMatKhau.MaxLength = 20;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Tối thiểu 8 ký tự";
            txtMatKhau.Size = new System.Drawing.Size(220, 27);
            txtMatKhau.TabIndex = 10;
            txtMatKhau.UseSystemPasswordChar = true;
            //
            // lblLoiMatKhau
            //
            lblLoiMatKhau.ForeColor = System.Drawing.Color.Firebrick;
            lblLoiMatKhau.Location = new System.Drawing.Point(150, 260);
            lblLoiMatKhau.Name = "lblLoiMatKhau";
            lblLoiMatKhau.Size = new System.Drawing.Size(220, 34);
            lblLoiMatKhau.TabIndex = 11;
            //
            // lblXacNhanMatKhau
            //
            lblXacNhanMatKhau.AutoSize = true;
            lblXacNhanMatKhau.Location = new System.Drawing.Point(20, 304);
            lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            lblXacNhanMatKhau.Size = new System.Drawing.Size(124, 20);
            lblXacNhanMatKhau.TabIndex = 12;
            lblXacNhanMatKhau.Text = "Xác nhận mật khẩu";
            //
            // txtXacNhanMatKhau
            //
            txtXacNhanMatKhau.Location = new System.Drawing.Point(150, 300);
            txtXacNhanMatKhau.MaxLength = 20;
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PlaceholderText = "Nhập lại mật khẩu";
            txtXacNhanMatKhau.Size = new System.Drawing.Size(220, 27);
            txtXacNhanMatKhau.TabIndex = 13;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            //
            // lblLoiXacNhanMatKhau
            //
            lblLoiXacNhanMatKhau.ForeColor = System.Drawing.Color.Firebrick;
            lblLoiXacNhanMatKhau.Location = new System.Drawing.Point(150, 330);
            lblLoiXacNhanMatKhau.Name = "lblLoiXacNhanMatKhau";
            lblLoiXacNhanMatKhau.Size = new System.Drawing.Size(220, 34);
            lblLoiXacNhanMatKhau.TabIndex = 14;
            //
            // lblLoi
            //
            lblLoi.ForeColor = System.Drawing.Color.Firebrick;
            lblLoi.Location = new System.Drawing.Point(20, 370);
            lblLoi.Name = "lblLoi";
            lblLoi.Size = new System.Drawing.Size(350, 40);
            lblLoi.TabIndex = 15;
            //
            // btnDangKy
            //
            btnDangKy.Location = new System.Drawing.Point(150, 416);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new System.Drawing.Size(105, 34);
            btnDangKy.TabIndex = 16;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            //
            // btnHuy
            //
            btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnHuy.Location = new System.Drawing.Point(265, 416);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(105, 34);
            btnHuy.TabIndex = 17;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = true;
            //
            // lnkDangNhap
            //
            lnkDangNhap.AutoSize = true;
            lnkDangNhap.Location = new System.Drawing.Point(150, 466);
            lnkDangNhap.Name = "lnkDangNhap";
            lnkDangNhap.Size = new System.Drawing.Size(170, 20);
            lnkDangNhap.TabIndex = 18;
            lnkDangNhap.TabStop = true;
            lnkDangNhap.Text = "Đã có tài khoản? Đăng nhập";
            lnkDangNhap.LinkClicked += lnkDangNhap_LinkClicked;
            //
            // FormDangKy
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new System.Drawing.Size(394, 505);
            Controls.Add(lnkDangNhap);
            Controls.Add(btnHuy);
            Controls.Add(btnDangKy);
            Controls.Add(lblLoi);
            Controls.Add(lblLoiXacNhanMatKhau);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(lblXacNhanMatKhau);
            Controls.Add(lblLoiMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(lblLoiEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblLoiTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblTenDangNhap);
            Controls.Add(lblLoiHoVaTen);
            Controls.Add(txtHoVaTen);
            Controls.Add(lblHoVaTen);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDangKy";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHoVaTen;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.Label lblLoiHoVaTen;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblLoiTenDangNhap;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblLoiEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblLoiMatKhau;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.Label lblLoiXacNhanMatKhau;
        private System.Windows.Forms.Label lblLoi;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.LinkLabel lnkDangNhap;
    }
}
