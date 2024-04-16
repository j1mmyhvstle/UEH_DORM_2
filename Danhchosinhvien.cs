using System;
using System.Data;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Danhchosinhvien : Form
    {
        
        public Danhchosinhvien()
        {
            InitializeComponent();
        }
        function fn = new function();
        public string id;

        public void txbTendangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                if (string.IsNullOrWhiteSpace(txbTendangnhap.Text))
                {
                    errorPic1.Visible = true;
                    MessageBox.Show("Thiếu tên đăng nhập hoặc mật khẩu !");
                }
            }
        }

        public void txbMatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txbMatkhau.Text))
                {
                    errorPic2.Visible = true;
                    MessageBox.Show("Thiếu tên đăng nhập hoặc mật khẩu !");
                }
                else
                {
                    CheckLogin();
                }

            }
        }
        public void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbTendangnhap.Text) || string.IsNullOrWhiteSpace(txbMatkhau.Text))
            {
                errorPic1.Visible = true;
                errorPic2.Visible = true;
                MessageBox.Show("Thiếu tên đăng nhập hoặc mật khẩu !");
            }
            else
            {
                CheckLogin();
            }


        }
        // Hàm riêng, dùng để add vào function.cs
        // 01
        public void CheckLogin()
        {
            string name = txbTendangnhap.Text; //mssv
            string password = txbMatkhau.Text;

            // Tạo câu lệnh SQL để kiểm tra tên đăng nhập và mật khẩu
            string query = $"SELECT COUNT(*) FROM Student WHERE username = '{name}' AND password = '{password}'";
            try
            {
                // Sử dụng hàm getData để thực thi câu lệnh SQL và lấy kết quả
                DataSet ds = fn.getData(query);
                int result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                // Kiểm tra kết quả
                if (result > 0)
                {
                    // Lấy ra mã số sinh viên để dùng cho những form khác
                    id = name;
                    // Tên đăng nhập và mật khẩu hợp lệ
                    MessageBox.Show("Đăng nhập thành công!");
                    // Form hiện ra sau khi đăng nhập 
                    Dashboard_SV dbsv = new Dashboard_SV(id);
                    dbsv.Show();
                }
                else
                {
                    // Tên đăng nhập hoặc mật khẩu không đúng
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public ToolTip tt = new ToolTip();
        public void label2_MouseHover(object sender, EventArgs e)
        {
            tt.Show("Hãy nhập mã số sinh viên và mật khẩu được gửi về trong hộp thư đến của bạn!", label2);
        }

        public void label2_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(label2);
        }

        public void label1_MouseHover(object sender, EventArgs e)
        {
            tt.Show("Liên hệ trường bạn nhé!", label1);
        }
        
        public void label1_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(label1);
        }

        public void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                txbMatkhau.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txbMatkhau.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        public void txbTendangnhap_TextChanged(object sender, EventArgs e)
        {

        }
         

        public void label2_Click(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void btnBack_Click(object sender, EventArgs e)
        {

        }

        public void btnBack_Click_1(object sender, EventArgs e)
        {
            Choosen choosen = new Choosen();
            fn.backtochoosen(this, choosen);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fn.close();
        }
    }
}
