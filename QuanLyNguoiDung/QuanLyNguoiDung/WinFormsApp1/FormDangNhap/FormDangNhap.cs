using Microsoft.Data.SqlClient;
using FormDangNhap;
namespace QuanLyNguoiDung
{
    public partial class FormDangNhap : Form
    {
        private const string ChuoiKetNoi =
       @"Server=LAPTOP-889QHEQR;Database=QuanLyNguoiDung;Trusted_Connection=True;TrustServerCertificate=True;";
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

                // ChuoiKetNoi đã được ông khai báo sẵn trên đầu file FormDangNhap.
                // user.UserId (hoặc user.Id) lấy từ đối tượng user vừa đăng nhập thành công.
                Formchinh formTrangChu = new Formchinh(ChuoiKetNoi, user.UserId);

                this.Hide();
                formTrangChu.ShowDialog();
                this.Show();
                txtMatKhau.Clear(); 
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
            FormDangKy formDK = new FormDangKy();
            this.Hide(); // Ẩn form đăng nhập đi

            // Mở form đăng ký dưới dạng hộp thoại chờ (chờ đến khi nó đóng)
            if (formDK.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng ký thành công (trả về OK), lấy tên vừa tạo điền sẵn vào ô đăng nhập luôn
                txtTenDangNhap.Text = formDK.TenDangNhapVuaTao;
            }

            // Bất kể đăng ký xong hay bấm nút quay lại (Cancel), khi form đăng ký đóng, hiện lại form đăng nhập
            this.Show();
        }
    }
}
