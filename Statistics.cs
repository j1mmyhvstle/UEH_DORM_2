using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Statistics : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        string query;

        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            // Đảm bảo chuỗi truy vấn được viết đúng cú pháp SQL và sử dụng dấu nháy đơn (' ') cho giá trị của cột roomStatus
            query = "SELECT COUNT(*) FROM rooms WHERE roomStatus = 'Available' AND Booked = 'No';";

            // Gọi hàm getData từ đối tượng function để thực hiện truy vấn và nhận kết quả trả về vào một DataSet
            DataSet ds = fn.getData(query);

            // Sau khi nhận được kết quả, bạn có thể xử lý nó ở đây, ví dụ, hiển thị trong một TextBox:
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // Giả sử kết quả trả về là một số nguyên, bạn có thể lấy nó từ hàng đầu tiên của bảng kết quả:
                int availableRoomCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                // Hiển thị số lượng phòng trống trong một TextBox có tên là txtp
                txtp.Text = availableRoomCount.ToString();
            }

            // Thực hiện truy vấn tương tự để lấy số lượng phòng đã đặt
            query = "SELECT COUNT(*) FROM rooms WHERE roomStatus = 'Available' AND Booked = 'Yes';";

            ds = fn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int bookedRoomCount = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                // Hiển thị số lượng phòng đã đặt trong một TextBox có tên là txtpBooked
                txto.Text = bookedRoomCount.ToString();
            }
            query = "SELECT COUNT(*) FROM Student WHERE living = 'Yes';";

            ds = fn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int studentlive = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                txtsvo.Text = studentlive.ToString();
            }
            query = "SELECT COUNT(*) FROM Student WHERE living = 'No';";

            ds = fn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int studentmove = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                txtsvd.Text = studentmove.ToString();

            }
            query = "SELECT COUNT(*) FROM newEmployee WHERE working = 'No';";

            ds = fn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int unemployee = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                txtnvnl.Text = unemployee.ToString();

            }
            query = "SELECT COUNT(*) FROM newEmployee WHERE working = 'Yes';";

            ds = fn.getData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int employee = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                txtnvl.Text = employee.ToString();

            }
        }

    }
}
