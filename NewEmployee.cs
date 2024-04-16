using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class NewEmployee : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 131);
        }

        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmaild.Clear();
            txtPernament.Clear();
            txtDesignation.SelectedIndex = -1;
            txtUniqueId.Clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
                try
                {
                    string mobile = txtMobile.Text;
                    string name = txtName.Text;
                    string fname = txtFather.Text;
                    string mname = txtMother.Text;
                    string email = txtEmaild.Text;
                    string address = txtPernament.Text;
                    string designation = txtDesignation.Text;
                    string id = txtUniqueId.Text;

                    // Sử dụng tham số để tránh tấn công SQL Injection
                    string query = "INSERT INTO newEmployee(emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) VALUES (@mobile, @name, @fname, @mname, @email, @address, @id, @designation)";

                    // Tạo mảng các đối tượng SqlParameter
                    SqlParameter[] sqlParams =
                    {
                new SqlParameter("@mobile", mobile),
                new SqlParameter("@name", name),
                new SqlParameter("@fname", fname),
                new SqlParameter("@mname", mname),
                new SqlParameter("@email", email),
                new SqlParameter("@address", address),
                new SqlParameter("@id", id),
                new SqlParameter("@designation", designation)
            };

                    // Gọi hàm setData với truy vấn, thông điệp và mảng tham số tương ứng
                    fn.setData(query, "Đã thêm nhân viên mới thành công", sqlParams);

                    // Xóa nội dung của các trường nhập liệu sau khi thêm thành công
                    clearAll();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }


       

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
