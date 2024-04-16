using System;
using System.Data;
using System.Data.SqlClient; //Thêm thư viện này
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Student_Payment : Form
    {
        string username;
        private Function fn = new Function();

        public Student_Payment(string id)
        {
            InitializeComponent();
            this.username = id;
        }

        private void Student_Payment_Load(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                if (fn.connection.State != ConnectionState.Open)
                    fn.connection.Open();

                // Tạo câu lệnh SQL để truy vấn
                string query = "SELECT mobile FROM Student WHERE username = @username";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, fn.connection))
                {
                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@username", username);

                    // Thực thi truy vấn và lấy kết quả
                    object result = command.ExecuteScalar();

                    if (result != null) // Kiểm tra xem có kết quả trả về hay không
                    {
                        // Hiển thị mobile lên TextBox txtMobile
                        string PhoneNumber = result.ToString();
                        string query2 = "SELECT StudentName, RoomNo, Amount FROM Payment_Student WHERE mobile = @PhoneNumber";

                        // Tạo đối tượng SqlCommand mới cho truy vấn thứ hai
                        using (SqlCommand command2 = new SqlCommand(query2, fn.connection))
                        {
                            // Thêm tham số vào câu lệnh SQL
                            command2.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                            // Thực thi truy vấn và lấy kết quả
                            SqlDataReader reader = command2.ExecuteReader();

                            if (reader.Read()) // Kiểm tra xem có dữ liệu để đọc không
                            {
                                // Hiển thị thông tin lên các TextBox
                                txt_Name.Text = reader["StudentName"].ToString();
                                txtRoomNo.Text = reader["RoomNo"].ToString();
                                txtAmount.Text = reader["Amount"].ToString();
                            }
                            reader.Close(); // Đóng đối tượng SqlDataReader
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin mobile cho tên sinh viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng xong
                fn.connection.Close();
            }
        }



        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {

            Student_Payment2 sdtp2 = new Student_Payment2(username);
            sdtp2.Show();

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoomNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }

}