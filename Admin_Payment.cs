using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //Thêm thư viện này
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Admin_Payment : Form
    {
        Function fn = new Function();
        String query;
        public Admin_Payment()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txt_RoomNo.Text != "")
            {
                string roomNo = txt_RoomNo.Text;
                //  truy vấn
                string query = "SELECT fname, mobile FROM Student WHERE roomNo = @RoomNo";

                // Tạo đối tượng SqlCommand
                SqlCommand command = new SqlCommand(query, fn.connection);

                // Thêm tham số vào truy vấn
                command.Parameters.AddWithValue("@RoomNo", roomNo);

                // Khai báo SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Khai báo DataTable để lưu trữ dữ liệu
                DataTable dt = new DataTable();

                // Mở kết nối
                fn.connection.Open();

                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                adapter.Fill(dt);

                // Đóng kết nối
                fn.connection.Close();

                // Hiển thị dữ liệu lên DataGridView
                DataGridView_adminpayment.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sinh viên nào trong phòng này.", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_adminpayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SavePaymentRequest(string studentName, string studentMobile)
        {
            try
            {
                // Kiểm tra xem studentName và studentMobile có giá trị hợp lệ hay không
                if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(studentMobile))
                {
                    MessageBox.Show("Thông tin sinh viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem kết nối đã được khởi tạo hay chưa
                if (fn.connection == null)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra kết nối trước khi mở
                if (fn.connection.State != ConnectionState.Open)
                {
                    fn.connection.Open();
                }

                // Lấy số tiền cần thanh toán từ TextBox txt_Tienthanhtoan
                if (!decimal.TryParse(txt_Tienthanhtoan.Text, out decimal amount))
                {
                    MessageBox.Show("Số tiền cần thanh toán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = (DataTable)DataGridView_adminpayment.DataSource;
                int studentCount = dt.Rows.Count;

                // Tạo câu lệnh SQL để chèn dữ liệu vào bảng Payment_Student
                string query = "INSERT INTO Payment_Student (StudentName, mobile, Amount, PaymentDate, RoomNo) VALUES (@StudentName, @mobile, @Amount, @PaymentDate, @RoomNo)";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, fn.connection))
                {
                    // Thêm các tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@mobile", studentMobile);
                    command.Parameters.AddWithValue("@Amount", amount / studentCount); // Số tiền cần thanh toán
                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now); // Ngày hiện tại
                    command.Parameters.AddWithValue("@RoomNo", txt_RoomNo.Text); // Ngày hiện tại
                    //command.Parameters.AddWithValue("@PaySit", "NO"); // Ngày hiện tại

                    // Thực thi câu lệnh SQL
                    command.ExecuteNonQuery();
                }

                // Đóng kết nối sau khi thêm dữ liệu
                fn.connection.Close();

                // Hiển thị thông báo khi lưu thành công
                MessageBox.Show("Yêu cầu thanh toán đã được gửi thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi lưu yêu cầu thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            bool requestSent = false; // Biến để đánh dấu liệu yêu cầu đã được gửi hay chưa

            // Kiểm tra xem DataGridView_adminpayment có dữ liệu không
            if (DataGridView_adminpayment.Rows.Count > 0)
            {
                // Lặp qua từng dòng trong DataGridView
                foreach (DataGridViewRow row in DataGridView_adminpayment.Rows)
                {
                    // Kiểm tra xem dòng hiện tại có tồn tại không
                    if (row != null && row.Cells["fname"].Value != null && row.Cells["mobile"].Value != null)
                    {
                        // Lấy thông tin của sinh viên từ từng dòng
                        string studentName = row.Cells["fname"].Value.ToString();
                        string studentMobile = row.Cells["mobile"].Value.ToString();

                        // Gửi yêu cầu thanh toán tới sinh viên
                        SavePaymentRequest(studentName, studentMobile); // Sửa lại đây để truyền cả studentName và studentMobile

                        // Đánh dấu rằng đã gửi yêu cầu thành công
                        requestSent = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có sinh viên nào trong danh sách để gửi yêu cầu thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Kiểm tra nếu đã gửi yêu cầu thành công, hiển thị thông báo
            if (requestSent)
            {
                MessageBox.Show("Đã gửi yêu cầu thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txt_Tienthanhtoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Payment_Load(object sender, EventArgs e)
        {

        }

        private void btn_dsach_Click(object sender, EventArgs e)
        {
            Admin_Payment2 abc = new Admin_Payment2();
            abc.Show();
        }
    }



    public class Function //Sửa lại tên lớp thành Function và đặt nó public để có thể truy cập từ bên ngoài
    {
        public SqlConnection connection = new SqlConnection(); //Khai báo và khởi tạo biến connection

        public Function()
        {
            // Thiết lập chuỗi kết nối
            connection.ConnectionString = @"Server=DESKTOP-37T0935\VUAVUNGCAO;Database=hostel;Trusted_Connection=True;TrustServerCertificate=Yes;MultipleActiveResultSets=true";
        }
    }
}
