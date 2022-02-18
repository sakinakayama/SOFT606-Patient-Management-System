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
    public partial class AppointmentForm : Form
    {
        int doctorID;
        int slotID;
        int patientID;
        
        public AppointmentForm()
        {
            InitializeComponent();

            tbDoctorAdapter.Fill(tbDoctorDataSet.tbDoctor);
            tbDoctorBindingSource.DataSource = tbDoctorDataSet.tbDoctor;
            dgvDoctor.DataSource = tbDoctorBindingSource;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dob = dpDOB.Value.ToString("yyyy-MM-dd");

            AppSettings appSettings = new AppSettings();
            dgvPatientResult.DataSource = appSettings.searchPatientData(txtLastName.Text, dob);
        }

        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbDoctorDataSet.tbDoctor' table. You can move, or remove it, as needed.
            this.tbDoctorAdapter.Fill(this.tbDoctorDataSet.tbDoctor);
        }

        private void btnShowSlots_Click(object sender, EventArgs e)
        {
            try
            {
                chkDay();
                string date = dtpDate.Value.ToString();
                AppSettings appSettings = new AppSettings();
                dgvSlots.DataSource = appSettings.getAvailabbleSlots(doctorID, date);
            }
            catch(InvalidDayException exp)
            {
                MessageBox.Show(exp.Message);
            }   
        }

        private void dgvDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDoctor.CurrentRow.Selected = true;
            doctorID = Convert.ToInt32(dgvDoctor.Rows[e.RowIndex].Cells[0].Value);
        }

        private void dgvPatientResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPatientResult.CurrentRow.Selected = true;
            patientID = Convert.ToInt32(dgvPatientResult.Rows[e.RowIndex].Cells[0].Value);
            AppSettings appSettings = new AppSettings();
            appSettings.getPaymentOverdue(patientID);
        }

        private void dgvSlots_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSlots.CurrentRow.Selected = true;
            slotID = Convert.ToInt32(dgvSlots.Rows[e.RowIndex].Cells[0].Value);
        }


        private void btnBook_Click(object sender, EventArgs e)
        {
            string date = dtpDate.Value.ToString();
            AppSettings appSettings = new AppSettings();
            appSettings.bookAppointment(slotID, patientID, doctorID, date);
        }

        public void chkDay()
        {
            System.DayOfWeek date = dtpDate.Value.DayOfWeek;

            if (date == DayOfWeek.Saturday || date == DayOfWeek.Sunday)
            {
                throw new InvalidDayException("We are closed on Weekends");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReceptionistForm receptionistForm = new ReceptionistForm();
            receptionistForm.Show();
        }
    }
}
