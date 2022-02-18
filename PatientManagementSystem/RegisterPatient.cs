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
    public partial class RegisterPatient : Form
    {
        public RegisterPatient()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string dob = dpDob.Value.ToString();
                int contact = Convert.ToInt32(txtContact.Text);

                AppSettings appSettings = new AppSettings();
                appSettings.registerPatient(txtFname.Text, txtLname.Text, cbGender.Text, txtAddress.Text, dob, txtOccupation.Text, contact, cbStatus.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please fill all information");
            }
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOccupation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnShowPatient_Click(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();
            dgvResults.DataSource = appSettings.getPatientData();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReceptionistForm receptionistForm = new ReceptionistForm();
            receptionistForm.Show();
        }

        private void RegisterPatient_Load(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();
            dgvResults.DataSource = appSettings.getPatientData();
        }
    }
}

