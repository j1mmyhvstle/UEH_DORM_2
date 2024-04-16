using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class NewStudent : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            // Tạo truy vấn để lấy danh sách số phòng từ cơ sở dữ liệu
            query = "SELECT roomNo FROM rooms WHERE roomStatus = 'Available' AND Booked = 'No'";

            // Lấy dữ liệu từ cơ sở dữ liệu
            DataSet dsRooms = fn.getData(query);

            // Xóa tất cả các mục có sẵn trong combo box trước khi thêm mới
            comboRoomNo.Items.Clear();

            // Thêm từng số phòng vào combo box
            foreach (DataRow row in dsRooms.Tables[0].Rows)
            {
                comboRoomNo.Items.Add(row["roomNo"].ToString());
            }
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtPermanent.Clear();
            txtCollege.Clear();
            txtIdProof.Clear();
            txt_usname.Clear();
            txt_pw.Clear();
            comboRoomNo.SelectedIndex = -1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtName.Text != "" && txtFather.Text != "" && txtMother.Text != "" && txtEmail.Text != "" && txtPermanent.Text != "" && txtCollege.Text != "" && txtIdProof.Text != "" && txt_usname.Text !="" && txt_pw.Text != "" && comboRoomNo.SelectedIndex != -1)
            {
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String name = txtName.Text;
                String fname = txtFather.Text;
                String mname = txtMother.Text;
                String email = txtEmail.Text;
                String paddress = txtPermanent.Text;
                String college = txtCollege.Text;
                String idproof = txtIdProof.Text;
                Int64 roomNo = Int64.Parse(comboRoomNo.Text);
                string usname = txt_usname.Text;
                string pw = txt_pw.Text;



                query = "INSERT INTO Student (mobile, lname, fname, mname, email, paddress, college, idproof, roomNo, username, password) " +
        "VALUES (" + mobile + ", '" + name + "','" + fname + "','" + mname + "','" + email + "','" + paddress + "','" + college + "','" + idproof + "'," + roomNo + ",'" + usname + "','" + pw + "') " +
        "UPDATE rooms SET Booked = 'Yes' WHERE roomNo = " + roomNo;

                fn.setData(query, "Sinh viên đăng ký thành công.");

                clearAll();
            }
            else
            {
                MessageBox.Show("Vui lồng điền thông tin đầy đủ", "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            fn.back(this, dashboardForm);
        }

        private void comboRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_usname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
