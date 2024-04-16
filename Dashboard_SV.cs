using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Dashboard_SV : Form
    {
        function fn = new function();
        string username;
        public Dashboard_SV(string id)
        {
            InitializeComponent();
            this.username = id;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }
        private void bntPay_Click(object sender, EventArgs e)
        {
            Student_Payment abc = new Student_Payment(username);
            abc.Show();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            Reply_st rl = new Reply_st();
            rl.Show();
        }
        private void btnNoti_Check_Click(object sender, EventArgs e)
        {
            Noti_st tbt = new Noti_st();
            tbt.Show();
        }
        private void btnRoommates_Click(object sender, EventArgs e)
        {
            try
            {
                // xem thu ban cung phong la ai ?
                string smallquery = $"select roomNo from Student where username = '{username}'";
                DataSet ds = fn.getData(smallquery);
                string roomNO = ds.Tables[0].Rows[0][0].ToString();
                string query = $"select CONCAT_WS(' ',fname,mname,lname) as 'Họ và tên'," +
                    $" email as 'Email'," +
                    $" mobile as 'SĐT'" +
                    $" from Student" +
                    $" where roomNo = '" + roomNO + "'";
                DataSet ds1 = fn.getData(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txbMSSV.Text = $"Danh sách thành viên phòng {roomNO}";
                    guna2DataGridView1.DataSource = ds1.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không có bạn cùng phòng !");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(username);
        }
        private void Dashboard_SV_Load(object sender, EventArgs e)
        {
            txbMSSV.Text = "Mã số sinh viên: " + username;
            string query =
            $"select concat_ws(' ',fname,mname,lname) as 'Họ và tên', " +
            $"email as Email, mobile as SĐT, roomNo as 'Phòng' " +
            $"from Student " +
            $"where living = 'Yes' and username = '" + username + "'";
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            RelyFeedback rl = new RelyFeedback();
            rl.Show();
        }
    }
}


