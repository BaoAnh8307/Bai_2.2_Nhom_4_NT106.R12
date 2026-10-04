using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyNguoiDung
{
    /// <summary>
    /// Form Đăng ký tài khoản mới (Bài tập 2.2).
    /// Trình tự: kiểm tra dữ liệu trên form -> kiểm tra trùng tên -> băm mật khẩu -> INSERT.
    /// Mọi truy vấn CSDL nằm ở lớp NguoiDungRepository, không viết trong hàm xử lý sự kiện.
    /// </summary>
    public partial class FormDangKy : Form
    {
        // Họ tên: chỉ chữ cái (kể cả tiếng Việt có dấu, dạng tổ hợp) và 1 khoảng trắng giữa các từ.
        private static readonly Regex MauHoVaTen =
            new(@"^[\p{L}\p{M}]+( [\p{L}\p{M}]+)*$", RegexOptions.Compiled);

        // Tên đăng nhập: 3-20 ký tự, chỉ chữ/số không dấu, không khoảng trắng.
        private static readonly Regex MauTenDangNhap =
            new(@"^[A-Za-z0-9]{3,20}$", RegexOptions.Compiled);

        // Email: dạng ten@mien.com.
        private static readonly Regex MauEmail =
            new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

        private const int DoDaiHoTenToiDa = 50;
        private const int DoDaiEmailToiDa = 100;
        private const int DoDaiMatKhauToiThieu = 8;
        private const int DoDaiMatKhauToiDa = 20;

        /// <summary>Tên đăng nhập vừa tạo, để form Đăng nhập điền sẵn (rỗng nếu chưa đăng ký).</summary>
        public string TenDangNhapVuaTao { get; private set; } = string.Empty;

        public FormDangKy()
        {
            InitializeComponent();

            // Người dùng gõ lại ô nào thì xoá thông báo lỗi của ô đó.
            txtHoVaTen.TextChanged += (_, _) => lblLoiHoVaTen.Text = string.Empty;
            txtTenDangNhap.TextChanged += (_, _) => lblLoiTenDangNhap.Text = string.Empty;
            txtEmail.TextChanged += (_, _) => lblLoiEmail.Text = string.Empty;
            txtMatKhau.TextChanged += (_, _) => lblLoiMatKhau.Text = string.Empty;
            txtXacNhanMatKhau.TextChanged += (_, _) => lblLoiXacNhanMatKhau.Text = string.Empty;
        }

        // ---------------------------------------------------------------- Sự kiện

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            XoaTatCaLoi();

            // Bước 1: kiểm tra dữ liệu trên form. Sai thì dừng, KHÔNG gọi xuống CSDL.
            if (!KiemTraDuLieu())
            {
                return;
            }

            string hoTen = txtHoVaTen.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text;

            DatTrangThaiDangXuLy(true);
            try
            {
                // Bước 2: kiểm tra trùng tên đăng nhập trong chương trình.
                if (await NguoiDungRepository.TenDangNhapDaTonTaiAsync(tenDangNhap))
                {
                    BaoTrungTenDangNhap();
                    return;
                }

                // Bước 3: băm mật khẩu kèm salt (PBKDF2 chậm có chủ đích) - chạy nền để form không bị đơ.
                var (salt, bam) = await Task.Run(() => MatKhau.Tao(matKhau));

                // Bước 4: INSERT. Ràng buộc UNIQUE ở CSDL chặn trường hợp 2 yêu cầu gửi gần như cùng lúc.
                KetQuaThemNguoiDung ketQua = await NguoiDungRepository.ThemAsync(
                    tenDangNhap, bam, salt, hoTen,
                    email.Length == 0 ? null : email);

                if (ketQua == KetQuaThemNguoiDung.TrungTenDangNhap)
                {
                    BaoTrungTenDangNhap();
                    return;
                }

                MessageBox.Show(this, "Đăng ký tài khoản thành công. Vui lòng đăng nhập.",
                    "Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TenDangNhapVuaTao = tenDangNhap;
                DialogResult = DialogResult.OK; // form Đăng nhập nhận OK thì quay lại màn hình Đăng nhập
            }
            catch (LoiCoSoDuLieuException ex)
            {
                lblLoi.Text = ex.Message; // thông báo tiếng Việt đã được lớp truy cập CSDL chuẩn bị
            }
            catch (Exception)
            {
                lblLoi.Text = "Đã xảy ra lỗi không mong muốn. Vui lòng thử lại.";
            }
            finally
            {
                DatTrangThaiDangXuLy(false);
            }
        }

        private void lnkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel; // quay lại form Đăng nhập
        }

        // btnHuy có DialogResult = Cancel nên tự đóng form, không cần xử lý Click.

        // ---------------------------------------------------------------- Kiểm tra dữ liệu

        /// <summary>
        /// Kiểm tra toàn bộ ô nhập, hiện lỗi cạnh từng ô sai và đặt con trỏ vào ô sai đầu tiên.
        /// </summary>
        private bool KiemTraDuLieu()
        {
            Control? oSaiDauTien = null;

            // Lưu ý: phải Clear() ô nhập TRƯỚC khi gán nhãn lỗi, vì Clear() kích hoạt TextChanged
            // (và TextChanged sẽ xoá nhãn lỗi của ô đó).
            void BaoLoi(Label nhan, Control oNhap, string noiDung)
            {
                nhan.Text = noiDung;
                oSaiDauTien ??= oNhap;
            }

            // Họ và tên
            string hoTen = txtHoVaTen.Text.Trim();
            if (hoTen.Length == 0)
                BaoLoi(lblLoiHoVaTen, txtHoVaTen, "Vui lòng nhập Họ và tên");
            else if (hoTen.Length > DoDaiHoTenToiDa)
                BaoLoi(lblLoiHoVaTen, txtHoVaTen, $"Họ và tên tối đa {DoDaiHoTenToiDa} ký tự");
            else if (!MauHoVaTen.IsMatch(hoTen))
                BaoLoi(lblLoiHoVaTen, txtHoVaTen, "Họ và tên chỉ gồm chữ cái và khoảng trắng");

            // Tên đăng nhập
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            if (tenDangNhap.Length == 0)
                BaoLoi(lblLoiTenDangNhap, txtTenDangNhap, "Vui lòng nhập Tên đăng nhập");
            else if (!MauTenDangNhap.IsMatch(tenDangNhap))
                BaoLoi(lblLoiTenDangNhap, txtTenDangNhap, "Tên đăng nhập 3-20 ký tự, chỉ gồm chữ và số không dấu");

            // Email (không bắt buộc - cột Email cho phép NULL; có nhập thì phải đúng định dạng)
            string email = txtEmail.Text.Trim();
            if (email.Length > 0 && (email.Length > DoDaiEmailToiDa || !MauEmail.IsMatch(email)))
                BaoLoi(lblLoiEmail, txtEmail, "Email không đúng định dạng (ten@mien.com)");

            // Mật khẩu
            string matKhau = txtMatKhau.Text;
            bool matKhauHopLe = false;
            if (matKhau.Length == 0)
            {
                BaoLoi(lblLoiMatKhau, txtMatKhau, "Vui lòng nhập Mật khẩu");
            }
            else if (!MatKhauDungDinhDang(matKhau))
            {
                txtMatKhau.Clear();
                BaoLoi(lblLoiMatKhau, txtMatKhau,
                    "Mật khẩu 8-20 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt");
            }
            else
            {
                matKhauHopLe = true;
            }

            // Xác nhận mật khẩu
            string xacNhan = txtXacNhanMatKhau.Text;
            if (xacNhan.Length == 0)
            {
                BaoLoi(lblLoiXacNhanMatKhau, txtXacNhanMatKhau, "Vui lòng nhập lại mật khẩu");
            }
            else if (matKhauHopLe && xacNhan != matKhau)
            {
                txtXacNhanMatKhau.Clear(); // chỉ xoá ô xác nhận
                BaoLoi(lblLoiXacNhanMatKhau, txtXacNhanMatKhau, "Mật khẩu nhập lại không khớp");
            }

            if (oSaiDauTien != null)
            {
                oSaiDauTien.Focus();
                return false;
            }
            return true;
        }

        private static bool MatKhauDungDinhDang(string matKhau)
        {
            if (matKhau.Length < DoDaiMatKhauToiThieu || matKhau.Length > DoDaiMatKhauToiDa)
                return false;

            bool coHoa = false, coThuong = false, coSo = false, coDacBiet = false;
            foreach (char c in matKhau)
            {
                if (char.IsUpper(c)) coHoa = true;
                else if (char.IsLower(c)) coThuong = true;
                else if (char.IsDigit(c)) coSo = true;
                else if (!char.IsWhiteSpace(c)) coDacBiet = true;
            }
            return coHoa && coThuong && coSo && coDacBiet;
        }

        // ---------------------------------------------------------------- Hỗ trợ giao diện

        private void BaoTrungTenDangNhap()
        {
            lblLoiTenDangNhap.Text = "Tên này đã có người dùng";
            txtTenDangNhap.Focus(); // giữ nguyên dữ liệu đã gõ
        }

        private void XoaTatCaLoi()
        {
            lblLoiHoVaTen.Text = string.Empty;
            lblLoiTenDangNhap.Text = string.Empty;
            lblLoiEmail.Text = string.Empty;
            lblLoiMatKhau.Text = string.Empty;
            lblLoiXacNhanMatKhau.Text = string.Empty;
            lblLoi.Text = string.Empty;
        }

        /// <summary>Khoá nút + đổi nhãn trong lúc chờ CSDL để tránh bấm nhiều lần tạo tài khoản trùng.</summary>
        private void DatTrangThaiDangXuLy(bool dangXuLy)
        {
            btnDangKy.Enabled = !dangXuLy;
            btnHuy.Enabled = !dangXuLy;
            lnkDangNhap.Enabled = !dangXuLy;
            btnDangKy.Text = dangXuLy ? "Đang xử lý..." : "Đăng ký";
            UseWaitCursor = dangXuLy;
        }
    }
}
