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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();
            //  String userType = appSettings.checkUserType(txtUserID.Text, txtPassword.Text);
            string userType = appSettings.validateUser(txtUserID.Text, txtPassword.Text);

            if (userType.Equals("Receptionist"))
            {
                MessageBox.Show("Welcome Receptionist!");
                ReceptionistForm receptionistForm = new ReceptionistForm();
                receptionistForm.Show();
            }

            else if (userType.Equals("Nurse"))
            {
                MessageBox.Show("Welcome Nurse!");
                EditPatientForm editPatientForm = new EditPatientForm();
                editPatientForm.Show();
            }

            else if (userType.Equals("Doctor"))
            {
                MessageBox.Show("Welcome Doctor!");
                DoctorOperationForm doctorOperationForm = new DoctorOperationForm();
                doctorOperationForm.Show();
            }

        }
    }
}
