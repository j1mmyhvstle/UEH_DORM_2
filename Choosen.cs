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
    public partial class Choosen : Form
    {   Danhchosinhvien login2 = new Danhchosinhvien();
        DanhChoQuanLy login1 = new DanhChoQuanLy();
        function fn = new function();
        public Choosen()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            
            login1.Show();
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            
            login2.Show();
        }
    }
}
