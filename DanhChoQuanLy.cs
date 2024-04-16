using System;
using System.Data;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class DanhChoQuanLy : Form
    {
        function fn = new function();
        public DanhChoQuanLy()
        {
            InitializeComponent();
        }      
        public void CheckLogin()
        {
            string name = txtUsername.Text;
            string password = txtPassword.Text;

            // Tạo câu lệnh SQL để kiểm tra tên đăng nhập và mật khẩu
            string query = $"SELECT COUNT(*) FROM ADMIN WHERE Username_ = '{name}' AND Password_ = '{password}'";
            try
            {
                // Sử dụng hàm getData để thực thi câu lệnh SQL và lấy kết quả
                DataSet ds = fn.getData(query);
                int result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                // Kiểm tra kết quả
                if (result > 0)
                {
                    // Tên đăng nhập và mật khẩu hợp lệ
                    MessageBox.Show("Đăng nhập thành công!");

                    // Form hiện ra sau khi đăng nhập
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();

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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
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
        public ToolTip tt = new ToolTip();
        public void label4_MouseHover(object sender, EventArgs e)
        {
            
        }

        public void label4_MouseLeave(object sender, EventArgs e)
        {
            tt.Hide(label4);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            tt.Show("Nếu chưa có tài khoản vui lòng đăng ký, Nếu quên mật khẩu vui lòng liên hệ quản lý", label4);
        }

        private void txtSignup_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Ẩn mật khẩu
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Choosen choosen = new Choosen();
            fn.backtochoosen(this, choosen);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
