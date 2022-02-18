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
    public partial class PaymentForm : Form
    {
        int patientID;
        int appointmentID;
        string fName;
        string lName;
        string fee;
        string overdue;
        string status;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dob = dpDob.Value.ToString();

            AppSettings appSettings = new AppSettings();
            dgvResult.DataSource = appSettings.searchPatientData(txtLastName.Text, dob);
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvResult.CurrentRow.Selected = true;
            patientID = Convert.ToInt32(dgvResult.Rows[e.RowIndex].Cells[0].Value);
            fName = dgvResult.Rows[e.RowIndex].Cells[1].Value.ToString();
            lName = dgvResult.Rows[e.RowIndex].Cells[2].Value.ToString();
            status = dgvResult.Rows[e.RowIndex].Cells[8].Value.ToString();

            checkImmigrationStatus();

            AppSettings appSettings = new AppSettings();
            dgvAppointmentResult.DataSource = appSettings.getAppointment(patientID);
            appSettings.getPaymentOverdue(patientID);
        }

        private void dgvAppointmentResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAppointmentResult.CurrentRow.Selected = true;
            appointmentID = Convert.ToInt32(dgvAppointmentResult.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fee = txtFee.Text;
            overdue = cbOverdue.SelectedItem.ToString();

            AppSettings appSettings = new AppSettings();
            appSettings.updatePayment(fee, overdue, patientID, appointmentID);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ppReceipt.Document = printReceipt;
            ppReceipt.ShowDialog();
        }

        private void printReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            e.Graphics.DrawString("Receipt", new Font("Arial", 40, FontStyle.Bold), Brushes.Black, new Point(270, 20));
            e.Graphics.DrawString(dateTime.ToShortDateString(), new Font("Arial", 24, FontStyle.Bold), Brushes.Black, new Point(550, 60));
            e.Graphics.DrawString("Patient Name : " + fName + " " + lName, new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(150, 210));
            e.Graphics.DrawString("--------------------------------------", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(150, 300));
            e.Graphics.DrawString("Item Name ", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(170, 340));
            e.Graphics.DrawString("Price ", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(450, 340));
            e.Graphics.DrawString("--------------------------------------", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(150, 370));
            e.Graphics.DrawString("Consultation fee : ", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(170, 400));
            e.Graphics.DrawString(fee, new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(450, 400));
            e.Graphics.DrawString("-------------------------------------", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(150, 460));
            e.Graphics.DrawString("Total : ", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(170, 500));
            e.Graphics.DrawString(fee, new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(450, 500));
            e.Graphics.DrawString("Receptionist Name :" + User.fName + " " + User.lName, new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(150, 800));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReceptionistForm receptionistForm = new ReceptionistForm();
            receptionistForm.Show();
        }
        
        public void checkImmigrationStatus()
        {
            if (status == "Citizen" || status == "Permanent residents")
            {
                txtFee.Text = "$10";
            }
            else if (status == "Workers")
            {
                txtFee.Text = "$20";
            }
            else if (status == "Student" || status == "Visitor")
            {
                txtFee.Text = "$15";
            }
        }

    }
}
