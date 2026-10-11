using Microsoft.Data.SqlClient;
namespace FormDangNhap
{
    public partial class FormDangNhap : Form
    {
        private const string ChuoiKetNoi =
       @"Server=TEN_SERVER;Database=TEN_DATABASE;Trusted_Connection=True;TrustServerCertificate=True;";
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = "";

            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                lblThongBao.Text = "Vui lòng nhập tên đăng nhập";
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                lblThongBao.Text = "Vui lòng nhập mật khẩu";
                txtMatKhau.Focus();
                return;
            }

            try
            {
                // Tạo lớp truy cập database
                UserRepository repo = new UserRepository(ChuoiKetNoi);

                // Tìm tài khoản theo tên đăng nhập
                UserLoginInfo? user = repo.TimTheoTenDangNhap(tenDangNhap);

                // Không tồn tại tài khoản
                if (user == null)
                {
                    lblThongBao.Text =
                        "Tên đăng nhập hoặc mật khẩu không đúng";

                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                // Kiểm tra mật khẩu bằng PBKDF2
                bool matKhauDung = MatKhau.KiemTra(
                    matKhau,
                    user.Salt,
                    user.MatKhauBam
                );

                if (!matKhauDung)
                {
                    lblThongBao.Text =
                        "Tên đăng nhập hoặc mật khẩu không đúng";

                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                // Đăng nhập thành công
                MessageBox.Show(
                    "Đăng nhập thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                lblThongBao.Text = "Lỗi kết nối cơ sở dữ liệu";
            }
            catch (Exception)
            {
                lblThongBao.Text = "Đã xảy ra lỗi, vui lòng thử lại";
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Form đăng ký sẽ ghép vào sau.");
        }
    }
}
