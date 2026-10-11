using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace formchinh
{
    public partial class Formchinh : Form
    {
        private readonly string _chuoiKetNoi;
        private readonly int _userId;
        public Formchinh(string chuoiKetNoi, int userId)
        {
            InitializeComponent();
            _chuoiKetNoi = chuoiKetNoi;
            _userId = userId;

            Text = "Trang Chinh";
        }

        private async void formchinh_Load(object? sender, EventArgs e)
        {
            // Xoá chữ mẫu trong Designer trong lúc chờ CSDL
            lbhello.Text = "Xin chào,";
            lbname.Text = "Tên đăng nhập:";
            lbemail.Text = "Email:";
            lbdate.Text = string.Empty;

            try
            {
                ThongTinNguoiDung? tt =
                    await ThongTinNguoiDungRepository.LayTheoIdAsync(_chuoiKetNoi, _userId);

                if (tt == null)
                {
                    MessageBox.Show(this, "Không tìm thấy tài khoản.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }

                lbhello.Text = $"Xin chào, {tt.HoTen}";
                lbname.Text = $"Tên đăng nhập: {tt.TenDangNhap}";
                lbemail.Text = $"Email: {(string.IsNullOrWhiteSpace(tt.Email) ? "(chưa cập nhật)" : tt.Email)}";
                lbdate.Text = tt.LanDangNhapCuoi.HasValue
                    ? tt.LanDangNhapCuoi.Value.ToString("dd/MM/yyyy  HH:mm")
                    : "Chưa có";
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                MessageBox.Show(this, "Không tải được thông tin người dùng. Vui lòng thử lại.",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
