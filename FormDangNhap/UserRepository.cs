using Microsoft.Data.SqlClient;

namespace FormDangNhap
{
    public class UserRepository
    {
        private readonly string chuoiKetNoi;

        public UserRepository(string chuoiKetNoi)
        {
            this.chuoiKetNoi = chuoiKetNoi;
        }

        public UserLoginInfo? TimTheoTenDangNhap(string tenDangNhap)
        {
            const string sql =
                @"SELECT UserId, TenDangNhap, MatKhauBam, Salt, HoTen
                  FROM Users
                  WHERE TenDangNhap = @ten";

            using SqlConnection conn = new SqlConnection(chuoiKetNoi);
            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.Add(
                "@ten",
                System.Data.SqlDbType.NVarChar,
                20
            ).Value = tenDangNhap;

            conn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new UserLoginInfo
            {
                UserId = reader.GetInt32(0),
                TenDangNhap = reader.GetString(1),
                MatKhauBam = reader.GetString(2),
                Salt = reader.GetString(3),
                HoTen = reader.GetString(4)
            };
        }
    }
}