namespace QuanLyNguoiDung
{
    partial class FormDangNhap
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
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            lblThongBao = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            lnkDangKy = new LinkLabel();
            lblTieuDe = new Label();
            SuspendLayout();
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(62, 56);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(85, 15);
            lblTenDangNhap.TabIndex = 0;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(62, 113);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(57, 15);
            lblMatKhau.TabIndex = 1;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.ForeColor = Color.Red;
            lblThongBao.Location = new Point(62, 159);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(64, 15);
            lblThongBao.TabIndex = 2;
            lblThongBao.Text = "Thông báo";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(153, 53);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(213, 23);
            txtTenDangNhap.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(153, 110);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(213, 23);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(136, 189);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(75, 23);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(281, 189);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 23);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lnkDangKy
            // 
            lnkDangKy.AutoSize = true;
            lnkDangKy.Location = new Point(165, 233);
            lnkDangKy.Name = "lnkDangKy";
            lnkDangKy.Size = new Size(154, 15);
            lnkDangKy.TabIndex = 7;
            lnkDangKy.TabStop = true;
            lnkDangKy.Text = "Chưa có tài khoản? Đăng ký";
            lnkDangKy.LinkClicked += lnkDangKy_LinkClicked;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.BorderStyle = BorderStyle.FixedSingle;
            lblTieuDe.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(175, -2);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(144, 32);
            lblTieuDe.TabIndex = 8;
            lblTieuDe.Text = "ĐĂNG NHẬP";
            // 
            // FormDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnThoat;
            ClientSize = new Size(504, 311);
            Controls.Add(lblTieuDe);
            Controls.Add(lnkDangKy);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblThongBao);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTenDangNhap);
            Name = "FormDangNhap";
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDangNhap;
        private Label lblMatKhau;
        private Label lblThongBao;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
        private LinkLabel lnkDangKy;
        private Label lblTieuDe;
    }
}
