using System;
using System.Windows.Forms;

namespace formchinh
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string chuoiKetNoi =
                @"Server=.\SQLEXPRESS;Database=TenDatabase;Integrated Security=True;TrustServerCertificate=True;";

            int userId = 1; // Chỉ là ID ví dụ

            Application.Run(new Formchinh(chuoiKetNoi, userId));
        }
    }
}