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
    public partial class EditPatientForm : Form
    {
        int patientID;
        string patientLastName;
        string patientDob;
        int appointmentID;
       
        public EditPatientForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dob = dpDob.Value.ToString();

            AppSettings appSettings = new AppSettings();
            dgvResult.DataSource = appSettings.searchPatientData(txtLastName.Text, dob);
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvAppointmentResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAppointmentResult.CurrentRow.Selected = true;
            appointmentID = Convert.ToInt32(dgvAppointmentResult.Rows[e.RowIndex].Cells[0].Value);
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvResult.CurrentRow.Selected = true;
            patientID = Convert.ToInt32(dgvResult.Rows[e.RowIndex].Cells[0].Value);
            patientLastName = dgvResult.Rows[e.RowIndex].Cells[2].Value.ToString();
            patientDob = dgvResult.Rows[e.RowIndex].Cells[5].Value.ToString();

            AppSettings appSettings = new AppSettings();
            dgvAppointmentResult.DataSource = appSettings.getAppointment(patientID);
            appSettings.getPaymentOverdue(patientID);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkTextboxFormat();
                decimal height = Convert.ToDecimal(txtHeight.Text);
                decimal weight = Convert.ToDecimal(txtWeight.Text);

                AppSettings appSettings = new AppSettings();
                appSettings.updatePatientData(txtMedicalProblem.Text, height, weight, txtNotes.Text, patientID, patientDob, appointmentID);
            }

            catch(InvalidFormatExceptions exp)
            {
                MessageBox.Show(exp.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
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

        public void checkTextboxFormat()
        {
          if (txtMedicalProblem.Text == "" || txtHeight.Text == "" || txtWeight.Text == "")
            {
                throw new InvalidFormatExceptions("Please enter information");
            }
        }

        
    }
}
