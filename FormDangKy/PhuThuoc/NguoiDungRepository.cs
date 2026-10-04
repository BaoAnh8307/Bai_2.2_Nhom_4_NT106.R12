using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuanLyNguoiDung
{
    public enum KetQuaThemNguoiDung
    {
        ThanhCong,
        TrungTenDangNhap
    }

    /// <summary>Lỗi CSDL đã được đổi sang thông báo tiếng Việt, an toàn để hiện cho người dùng.</summary>
    public class LoiCoSoDuLieuException : Exception
    {
        public LoiCoSoDuLieuException(string thongBao, Exception? loiGoc = null)
            : base(thongBao, loiGoc) { }
    }

    /// <summary>
    /// Lớp truy cập bảng Users (phần đăng ký). Toàn bộ SQL dùng tham số, không nối chuỗi.
    /// Ở đồ án, lớp này chuyển sang phía server gần như nguyên vẹn.
    /// </summary>
    public static class NguoiDungRepository
    {
        // Nên chuyển sang tệp cấu hình riêng và khai báo trong .gitignore.
        private const string ChuoiKetNoi =
            @"Server=localhost\SQLEXPRESS;Database=QuanLyNguoiDung;" +
            @"Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=5;";

        private const string ThongBaoLoiKetNoi =
            "Không kết nối được tới cơ sở dữ liệu. Vui lòng kiểm tra dịch vụ SQL Server rồi thử lại.";

        // Mã lỗi SQL Server khi vi phạm UNIQUE / PRIMARY KEY
        private const int LoiTrungKhoaUnique = 2627;
        private const int LoiTrungChiMucUnique = 2601;

        public static async Task<bool> TenDangNhapDaTonTaiAsync(string tenDangNhap)
        {
            const string sql = "SELECT COUNT(1) FROM Users WHERE TenDangNhap = @ten";
            try
            {
                using var conn = new SqlConnection(ChuoiKetNoi);
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 20).Value = tenDangNhap;

                await conn.OpenAsync();
                object? ketQua = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(ketQua) > 0;
            }
            catch (Exception ex) when (ex is SqlException or InvalidOperationException)
            {
                throw new LoiCoSoDuLieuException(ThongBaoLoiKetNoi, ex);
            }
        }

        public static async Task<KetQuaThemNguoiDung> ThemAsync(
            string tenDangNhap, string matKhauBam, string salt, string hoTen, string? email)
        {
            const string sql =
                "INSERT INTO Users (TenDangNhap, MatKhauBam, Salt, HoTen, Email) " +
                "VALUES (@ten, @bam, @salt, @hoTen, @email)";
            try
            {
                using var conn = new SqlConnection(ChuoiKetNoi);
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 20).Value = tenDangNhap;
                cmd.Parameters.Add("@bam", SqlDbType.NVarChar, 64).Value = matKhauBam;
                cmd.Parameters.Add("@salt", SqlDbType.NVarChar, 32).Value = salt;
                cmd.Parameters.Add("@hoTen", SqlDbType.NVarChar, 50).Value = hoTen;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value =
                    (object?)email ?? DBNull.Value;

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                return KetQuaThemNguoiDung.ThanhCong;
            }
            catch (SqlException ex) when (ex.Number is LoiTrungKhoaUnique or LoiTrungChiMucUnique)
            {
                return KetQuaThemNguoiDung.TrungTenDangNhap;
            }
            catch (Exception ex) when (ex is SqlException or InvalidOperationException)
            {
                throw new LoiCoSoDuLieuException(ThongBaoLoiKetNoi, ex);
            }
        }
    }
}
