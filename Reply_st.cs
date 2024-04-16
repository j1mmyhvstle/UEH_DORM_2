using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Reply_st : Form
    {
        Dashboard dashboardForm = new Dashboard();

        function fn = new function();
        String query;
        public Reply_st()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
       
            txtNd.Clear();
            txtID.Clear();
            txtName.Clear();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Trích xuất tiêu đề, nội dung, ID, và tên từ txtBox
                string noidung = txtNd.Text;
                string id = txtID.Text;
                string name = txtName.Text;
                string time = monthDateTime.Text;
                string type = comboBox1.SelectedItem.ToString();
                // Tạo câu lệnh SQL INSERT để chèn dữ liệu mới vào bảng Feedback
                string queryInsert = "INSERT INTO Feedback (StudentID, Name,FeedbackText,FeedbackDate,fbType) VALUES (@id, @name, @noidung,@time, @type)";

                // Khởi tạo mảng các tham số SqlParameter
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@id", SqlDbType.Int) { Value = id, Direction = ParameterDirection.Input },
                    new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = name, Direction = ParameterDirection.Input },
                    new SqlParameter("@noidung", SqlDbType.NVarChar, 500) { Value = noidung, Direction = ParameterDirection.Input },
                    new SqlParameter("@time", SqlDbType.DateTime) { Value = time, Direction = ParameterDirection.Input },
                    new SqlParameter("@type", SqlDbType.NVarChar, 250) { Value = type, Direction = ParameterDirection.Input }
                };

                // Gọi phương thức setData từ đối tượng fn để thực thi câu lệnh SQL INSERT
                fn.setData(queryInsert, "Gửi  thành công!", parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadDataIntoComboBox()
        {
            string query = "SELECT fbType FROM FBTYPE";
            DataSet fbTypeData = fn.getData(query);
            if (fbTypeData.Tables.Count > 0)
            {
                DataTable fbTypeTable = fbTypeData.Tables[0];
                foreach (DataRow row in fbTypeTable.Rows)
                {
                    comboBox1.Items.Add(row["fbType"].ToString());
                }
            }
        }

        private void Reply_st_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBox();
        }
    }
}
