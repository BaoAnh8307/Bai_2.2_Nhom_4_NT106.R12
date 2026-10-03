# 🗄️ Phần Cơ Sở Dữ Liệu & Logic Bảo Mật

Thư mục này chứa các file cấu trúc CSDL và các lớp (class) xử lý truy vấn, băm mật khẩu.

**📌 Yêu cầu đối với thành viên phụ trách:**
- **File kịch bản SQL:** Nộp file `.sql` chứa câu lệnh `CREATE TABLE Users` với các ràng buộc theo đề bài (`UNIQUE` cho tên đăng nhập).
- **Class Truy cập dữ liệu:** Sử dụng `Microsoft.Data.SqlClient`. Mọi câu lệnh SQL đều **phải dùng tham số** (VD: `@ten`), nghiêm cấm dùng phép nối chuỗi.
- **Class Bảo mật:** Chứa file `MatKhau.cs` thực hiện hàm băm 
- *Lưu ý: Không hardcode (ghi cứng) chuỗi kết nối chứa mật khẩu thật của SQL Server vào các class trên GitHub.*