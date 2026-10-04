using System;
using System.Security.Cryptography;

namespace QuanLyNguoiDung
{
    /// <summary>
    /// Băm mật khẩu bằng PBKDF2-HMAC-SHA256, 600.000 vòng lặp (khuyến nghị OWASP), salt ngẫu nhiên 16 byte.
    /// </summary>
    public static class MatKhau
    {
        private const int VONG_LAP = 600_000;

        // Gọi khi đăng ký
        public static (string Salt, string Bam) Tao(string matKhau)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] bam = Rfc2898DeriveBytes.Pbkdf2(
                matKhau, salt, VONG_LAP, HashAlgorithmName.SHA256, 32);
            return (Convert.ToBase64String(salt), Convert.ToBase64String(bam));
        }

        // Gọi khi đăng nhập
        public static bool KiemTra(string matKhau, string saltLuu, string bamLuu)
        {
            byte[] salt = Convert.FromBase64String(saltLuu);
            byte[] bamCu = Convert.FromBase64String(bamLuu);
            byte[] bamMoi = Rfc2898DeriveBytes.Pbkdf2(
                matKhau, salt, VONG_LAP, HashAlgorithmName.SHA256, 32);
            return CryptographicOperations.FixedTimeEquals(bamCu, bamMoi);
        }
    }
}
