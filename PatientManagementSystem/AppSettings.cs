using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace PatientManagementSystem
{
    class AppSettings
    {
        SqlConnection connection;

        public AppSettings()  //connect to SQL database
        {
            string strConnectionString = "Data Source=09207524-SAKI;Initial Catalog=PatientManagementSyetem;Integrated Security=True";
            connection = new SqlConnection(strConnectionString);

            connection.Open();
        }

        //validate user and get userType
        public string validateUser(string userId, string password)
        {
            string userType = "";
            string query = "SELECT * FROM tbUser WHERE UserID = '" + userId + "' AND Password = '" + password + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                User.userID = dt.Rows[0]["UserID"].ToString();  //set the value 
                userType = dt.Rows[0]["UserType"].ToString();  //set the value 
                User.fName = dt.Rows[0]["FirstName"].ToString();
                User.lName = dt.Rows[0]["LastName"].ToString();

                System.Windows.Forms.MessageBox.Show("Login Success!!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Incorrect username or password");
            }
            connection.Close();
            return userType;
        }

        //Register patient
        public void registerPatient(string fName, string lName, string gender, string address, string dob, string occupation, int contactNo, string status)
        {
            string query = "INSERT INTO tbPatient " +
                "VALUES('" + fName + "', '" + lName + "', '" + gender + "', '" + address + "', " +
                "CONVERT(Date, '" + dob + "'), '" + occupation + "', '" + contactNo + "', '" + status + "', null, null, null)";
            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            connection.Close();
            command = null;

            System.Windows.Forms.MessageBox.Show("Registered successfully!!");
        }
            
        //get new patient data
        public DataTable getPatientData()
        {
            string query = "SELECT * FROM tbPatient";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dtRecord = new DataTable();
            sqlData.Fill(dtRecord);

            return dtRecord;
        }

        //Search patient
        public DataTable searchPatientData(string lName, string dob)
        {
            string query = "SELECT * FROM tbPatient WHERE LastName = '" + lName + "' AND DOB ='" + dob + "'";
            //string query = "SELECT * FROM tbPatient WHERE LastName = '" + lName + "' AND DOB = CONVERT(Date, '" + dob + "')";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dtRecord = new DataTable();
          
            sqlData.Fill(dtRecord);

            if(dtRecord.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No patient data");
            }
       
            return dtRecord;
        }

        //Update patient data by nurse
        public void updatePatientData(string Mproblem, decimal height, decimal weight, string notes, int patientID, string dob, int appointmentID)
        {
            string query1 = "UPDATE tbPatient SET Height = '" + height + "', [Weight] = '" + weight + "', AdditionalNotes = '" + notes + "' WHERE PatientID = '" + patientID + "' AND DOB = CONVERT(Date, '" + dob + "')";
            string query2 = "UPDATE tbAppointment SET MedicalProblem = '" + Mproblem + "' WHERE PatientID = '" + patientID + "' AND AppointmentID = '" + appointmentID + "'";
      
            SqlCommand command1 = new SqlCommand(query1, connection);
            SqlCommand command2 = new SqlCommand(query2, connection);

            int noOfRows1 = command1.ExecuteNonQuery();
            int noOfRows2 = command2.ExecuteNonQuery();

            if (noOfRows1 != 0 && noOfRows2 != 0)
            {
                System.Windows.Forms.MessageBox.Show("Updated patient successfully!!");
            }

            connection.Close();
            command1 = null;
            command2 = null;
        }

        //Get available slots
        public DataTable getAvailabbleSlots(int doctorID, string date)
        {
            string query = "select s.SlotID, Time from (SELECT SlotID, DoctorID, a.Date FROM tbAppointment a " +
                "WHERE DoctorID = '" + doctorID + "' AND a.Date = CONVERT(Date, '" + date + "' )) a " +
                "right join (select SlotID, Time from tbSlot) s on a.SlotID = s.SlotID where a.SlotID is null";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dtRecord = new DataTable();

            sqlData.Fill(dtRecord);

            if (dtRecord.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No available time");
            }

            return dtRecord;
        }

        //book appointment
        public void bookAppointment(int slotID, int patientID, int doctorID, string date)
        {
            string query = "INSERT INTO tbAppointment (SlotID, PatientID, UserID, DoctorID, Date) " +
                "VALUES('" + slotID + "', '" + patientID + "', '" + User.userID + "', '" + doctorID + "', CONVERT(Date, '" + date + "'))" ;
            Debug.WriteLine(query);

            SqlCommand command = new SqlCommand(query, connection);

            command.ExecuteNonQuery();
            connection.Close();
            command = null;

            System.Windows.Forms.MessageBox.Show("Appointment Booked!!");
        }

        //get appointment data
        public DataTable getAppointment(int patientID)
        {
            string query = "select a.AppointmentID AS ID, a.Date, s.Time from tbAppointment a " +
                "inner join tbSlot s on s.SlotID = a.SlotID where a.PatientID = '" + patientID + "'";
            Debug.WriteLine(query);

            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dtRecord = new DataTable();

            sqlData.Fill(dtRecord);

            if (dtRecord.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No appointment for this patient");
            }
            return dtRecord;
        }

        //Update patient data by Doctor
        public void updatePatientbyDoctor(string diagnosis, string prescription, string medicaltests, int patientID, int appointmentID)
        {
            string query = "UPDATE tbAppointment SET DiagnosisInfo = '" + diagnosis + "', Prescription = '" + prescription + "', MedicalTests = '" + medicaltests +
                "' WHERE PatientID = '" + patientID + "' AND AppointmentID = '" + appointmentID + "'";

            SqlCommand command1 = new SqlCommand(query, connection);
            int noOfRows = command1.ExecuteNonQuery();
    
            if (noOfRows != 0)
            {
                System.Windows.Forms.MessageBox.Show("Updated patient successfully!!");
            }

            connection.Close();
            command1 = null;
        }

        //Update payment daya by Receptionist
        public void updatePayment(string fee, string overdue, int patientID, int appointmentID)
        {
            string query = "UPDATE tbAppointment SET Fee = '" + fee + "', PaymentOverdue = '" + overdue +
                "' WHERE PatientID = '" + patientID + "' AND AppointmentID = '" + appointmentID + "'";

            SqlCommand command1 = new SqlCommand(query, connection);
            int noOfRows = command1.ExecuteNonQuery();

            if (noOfRows != 0)
            {
                System.Windows.Forms.MessageBox.Show("Updated payment successfully!!");
            }

            connection.Close();
            command1 = null;
        }

        //get payment overdue
        public void getPaymentOverdue(int patientID)
        {
            string overdue = "";
            string query = "select PaymentOverdue from tbAppointment where PaymentOverdue Like '$%' AND PatientID IN(Select PatientID from tbPatient where PatientID = '" + patientID + "')";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable dtRecord = new DataTable();

            sqlData.Fill(dtRecord);

            if (dtRecord.Rows.Count != 0)
            {
                overdue = dtRecord.Rows[0]["PaymentOverdue"].ToString();
                System.Windows.Forms.MessageBox.Show("Payment Overdue is : " + overdue);
            }
        }
    }
}
