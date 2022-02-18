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
    public partial class DoctorOperationForm : Form
    {
        int patientID;
        int appointmentID;
        string fName;
        string lName;
        string prescription;
        string medicaltests;
        DateTime date = DateTime.Now;

        public DoctorOperationForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dob = dtpDob.Value.ToString();

            AppSettings appSettings = new AppSettings();
            dgvResult.DataSource = appSettings.searchPatientData(txtLastName.Text, dob);
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvResult.CurrentRow.Selected = true;
            patientID = Convert.ToInt32(dgvResult.Rows[e.RowIndex].Cells[0].Value);
            fName = dgvResult.Rows[e.RowIndex].Cells[1].Value.ToString();
            lName = dgvResult.Rows[e.RowIndex].Cells[2].Value.ToString();

            AppSettings appSettings = new AppSettings();
            dgvAppointment.DataSource = appSettings.getAppointment(patientID);
            appSettings.getPaymentOverdue(patientID);
        }

        private void dgvAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAppointment.CurrentRow.Selected = true;
            appointmentID = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells[0].Value);
          }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                checkTextboxFormat();
                string diagnosis = txtDianosis.Text;
                prescription = txtPrescription.Text;
                medicaltests = txtMedicalTests.Text;

                AppSettings appSettings = new AppSettings();
                appSettings.updatePatientbyDoctor(diagnosis, prescription, medicaltests, patientID, appointmentID);

            }
            catch(InvalidFormatExceptions exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        public void checkTextboxFormat()
        {
            if(txtDianosis.Text == "")
            {
                throw new InvalidFormatExceptions("Please enter Diagnosis Information");
            }
        }

        private void btnPrintPre_Click(object sender, EventArgs e)
        {
            ppPrescription.Document = printPrescription;
            ppPrescription.ShowDialog();
        }

        private void printPrescription_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Prescription", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, new Point(260, 20));
            e.Graphics.DrawString("Date : " + date.ToShortDateString(), new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 110));
            e.Graphics.DrawString("Patient Name : " + fName + " " + lName, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 210));
            e.Graphics.DrawString("Prescription : ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 400));
            e.Graphics.DrawString(prescription, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 480));
            e.Graphics.DrawString("Doctor Name : " + User.fName + " " + User.lName, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 1000));
        }

        private void btnPrintMedical_Click(object sender, EventArgs e)
        {
            ppMedicalTests.Document = printMedicalTests;
            ppMedicalTests.ShowDialog();

        }

        private void printMedicalTests_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Medical Tests", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, new Point(230, 20));
            e.Graphics.DrawString("Date : " + date.ToShortDateString(), new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 110));
            e.Graphics.DrawString("Patient Name : " + fName + " " + lName, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 210));
            e.Graphics.DrawString("Medical Tests : ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 400));
            e.Graphics.DrawString(medicaltests, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 480));
            e.Graphics.DrawString("Doctor Name : " + User.fName + " " + User.lName, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(100, 1000));
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
    }
}
