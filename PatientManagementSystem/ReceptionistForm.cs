using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientManagementSystem
{
    public partial class ReceptionistForm : Form
    {
        public ReceptionistForm()
        {
            InitializeComponent();
        }

        private void brnAppo_Click(object sender, EventArgs e)
        {
            AppointmentForm appointment = new AppointmentForm();
            appointment.Show();

            this.Hide();
             
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPatient registerPatient = new RegisterPatient();
            registerPatient.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you OK to sign out?", "Sign out", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Good bye, " + User.fName + " !!");
                this.Close();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                this.Show();
             }
        }
    }
}
