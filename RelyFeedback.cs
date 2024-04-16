using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class RelyFeedback : Form
    {
        Dashboard dashboardForm = new Dashboard();
        function fn = new function();
        String query;
        public RelyFeedback()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                // Xây dựng câu truy vấn SQL
                query = "SELECT TieuDe, NoiDungPhanHoi FROM Feedback WHERE StudentID = " + txtid.Text;

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataSet ds = fn.getData(query);

                // Kiểm tra xem DataSet có dữ liệu hay không
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Hiển thị tiêu đề và nội dung lấy được vào các TextBox tương ứng
                    tbTieuDe.Text = ds.Tables[0].Rows[0]["TieuDe"].ToString();
                    tbND.Text = ds.Tables[0].Rows[0]["NoiDungPhanHoi"].ToString();
                }
                else
                {
                    // Nếu không tìm thấy dữ liệu tương ứng, hiển thị thông báo
                    MessageBox.Show("Không tìm thấy dữ liệu cho ID này.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
