namespace QuanLyNguoiDung
{
    internal static class Program
    {
        // Chỉ để chạy thử riêng form Đăng ký. Khi ghép project của nhóm thì bỏ file này.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormDangKy());
        }
    }
}
