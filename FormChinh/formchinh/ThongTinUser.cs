using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace formchinh
{
    public class ThongTinNguoiDung
    {
        public string TenDangNhap { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string? Email { get; set; }
        public DateTime? LanDangNhapCuoi { get; set; }
    }

    public static class ThongTinNguoiDungRepository
    {
        public static async Task<ThongTinNguoiDung?> LayTheoIdAsync(string chuoiKetNoi, int userId)
        {
            const string sql =
                @"SELECT TenDangNhap, HoTen, Email, LanDangNhapCuoi
                  FROM Users
                  WHERE UserId = @id";

            using var conn = new SqlConnection(chuoiKetNoi);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync())
                return null;

            return new ThongTinNguoiDung
            {
                TenDangNhap = reader.GetString(0),
                HoTen = reader.GetString(1),
                Email = reader.IsDBNull(2) ? null : reader.GetString(2),
                LanDangNhapCuoi = reader.IsDBNull(3) ? null : reader.GetDateTime(3)
            };
        }
    }
}