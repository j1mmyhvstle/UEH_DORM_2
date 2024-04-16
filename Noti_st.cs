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
    public partial class Noti_st : Form
    {

        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public Noti_st()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string deleteAllQuery = "DELETE FROM ThongBao";
            fn.setData(deleteAllQuery, "Đã xóa hết thông tin.");

            // Sau khi xóa dữ liệu từ cơ sở dữ liệu, cập nhật lại DataGridView
            dataGridView1.Rows.Clear();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy studentId của hàng được chọn
                int ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Xóa dữ liệu từ cơ sở dữ liệu
                string deleteQuery = $"DELETE FROM ThongBao WHERE ID = {ID}";
                fn.setData(deleteQuery, "Đã xóa hàng được chọn.");

                // Sau khi xóa dữ liệu từ cơ sở dữ liệu, cập nhật lại DataGridView
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng đã chọn một hàng hợp lệ
            {
                // Lấy giá trị của các cột của hàng được chọn
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
                string TieuDe = dataGridView1.Rows[e.RowIndex].Cells["TieuDe"].Value.ToString();
               
                string LienLac = dataGridView1.Rows[e.RowIndex].Cells["LienLac"].Value.ToString();
                string GhiChu = dataGridView1.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();

                // Hiển thị thông tin trong các controls tương ứng
                tbid.Text = $"ID: {ID}";
                tbTieuDe.Text = $"Tiêu Đề:{TieuDe}";
             
                tbGhiChu.Text = $"Ghi Chú: {GhiChu}";
                tbLienLac.Text = $"Liên Lạc: {LienLac}";
                tbid.ReadOnly = true;
                tbTieuDe.ReadOnly = true;
                tbND.ReadOnly = true;
                tbGhiChu.ReadOnly = true;
                tbLienLac.ReadOnly = true;
            }


        }


        private void Noti_st_Load(object sender, EventArgs e)
        {
            query = "SELECT ID,TieuDe,GhiChu,LienLac FROM THongBao";
            DataSet ds = fn.getData(query);

            // Kiểm tra nếu có ít nhất một bảng dữ liệu trong DataSet
            if (ds.Tables.Count > 0)
            {
                // Kiểm tra nếu bảng dữ liệu có ít nhất một hàng
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Gán DataSource của dataGridView1 là bảng dữ liệu từ DataSet
                    dataGridView1.DataSource = ds.Tables[0];



                }
                else
                {
                    // Nếu không có hàng nào trong bảng dữ liệu, thông báo cho người dùng
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Nếu không có bảng dữ liệu trong DataSet, thông báo cho người dùng
                MessageBox.Show("Không có dữ liệu từ cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
