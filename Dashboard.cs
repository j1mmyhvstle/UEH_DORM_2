using System;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKyTuXa_Version3
{
    public partial class Dashboard : Form
    {
        function fn = new function() { };
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            fn.close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DanhChoQuanLy fn = new DanhChoQuanLy();
            fn.Show();
            this.Close();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom anr = new AddNewRoom();
            anr.Show();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            

            NewStudent nst = new NewStudent();
            nst.Show();
        }

        private void btnUpdateDeleteStudent_Click(object sender, EventArgs e)
        {
            
            UpdateDeleteStudent uds = new UpdateDeleteStudent();
            uds.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            
            Admin_Payment abc = new Admin_Payment();
            abc.Show();
            
        }

        private void btnAllStudentLiving_Click(object sender, EventArgs e)
        {
            
            AllStudentLiving asl = new AllStudentLiving();
            asl.Show();
        }

        private void btnLeavedStudent_Click(object sender, EventArgs e)
        {
            
            LeavedStudent lsn = new LeavedStudent();
            lsn.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            
            NewEmployee ne = new NewEmployee();
            ne.Show();
        }

        private void btnUpdateDeletedEmployee_Click(object sender, EventArgs e)
        {
            
            UpdateDeleteEmployee ude = new UpdateDeleteEmployee();
            ude.Show();
        }

        private void btnEmployeePayment_Click(object sender, EventArgs e)
        {
            
            EmployeePayment eep = new EmployeePayment();
            eep.Show();
        }

        private void btnAllEmployeeWorking_Click(object sender, EventArgs e)
        {
            
            AllEmployeeWorking aew = new AllEmployeeWorking();
            aew.Show();
        }

        private void btnLeavedEmployee_Click(object sender, EventArgs e)
        {
            
            LeavedEmployee lde = new LeavedEmployee();
            lde.Show();
        }

       

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Noti nt = new Noti();
            nt.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
          
            FeedBack fb = new FeedBack();
            fb.Show();
        }

        private void thongke_Click(object sender, EventArgs e)
        {
            Statistics st = new Statistics();
            st.Show();
        }
    }
}
