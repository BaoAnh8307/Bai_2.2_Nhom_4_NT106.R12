namespace FormDangNhap
{
    public class UserLoginInfo
    {
        public int UserId { get; set; }

        public string TenDangNhap { get; set; } = "";

        public string MatKhauBam { get; set; } = "";

        public string Salt { get; set; } = "";

        public string HoTen { get; set; } = "";
    }
}
