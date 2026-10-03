# Bài tập 2.2: Xây dựng ứng dụng quản lý người dùng

**Môn học:** Lập trình mạng căn bản (NT106.R12)
**Nhóm thực hiện:** Nhóm 4

## 👥 Danh sách thành viên

| STT | MSSV | Họ và tên | Phân công dự kiến |
| :---: | :--- | :--- | :--- |
| 1 | 25520440 | Phạm Lê Minh Duy | |
| 2 | 25520906 | Nguyễn Đăng Khôi | |
| 3 | 25520053 | Huỳnh Trần Duy Bảo Anh | |
| 4 | 25521161 | Nguyễn Hoài Nam | |
| 5 | 25520932 | Bùi Trọng Kiên | |

## 📝 Giới thiệu đồ án
Đây là Bài tập 2.2: Xây dựng ứng dụng quản lý người dùng có chức năng đăng ký và đăng nhập. Ứng dụng Windows Forms thực hiện kết nối trực tiếp tới cơ sở dữ liệu SQL Server với các tính năng:
- **Đăng ký:** Kiểm tra tính hợp lệ dữ liệu, băm mật khẩu kèm Salt ngẫu nhiên trước khi lưu.
- **Đăng nhập:** So khớp mật khẩu bằng hàm băm, xử lý ngoại lệ an toàn và gom chung thông báo lỗi để bảo mật thông tin.
- **Trang chính:** Hiển thị thông tin phiên làm việc của người dùng.