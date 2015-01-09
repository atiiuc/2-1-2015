using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentStudentApp
{
    public partial class StudentEntryUI : Form
    {
        public StudentEntryUI()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=lict\sqlexpress; Database=UniversityDB; Integrated Security=True";
        private void StudentEntryUI_Load(object sender, EventArgs e)
        {
            List<Department> departmentList = new List<Department>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();

            string query = "SELECT * FROM t_department";
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            while (aReader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.ID = (int) aReader["id"];
                aDepartment.Name = aReader["name"].ToString();
                aDepartment.Location = aReader["location"].ToString();
                departmentList.Add(aDepartment);
            }

            aReader.Close();
            aConnection.Close();

            deptComboBox.Items.Clear();

            foreach (Department aDepartment in departmentList)
            {
                deptComboBox.Items.Add(aDepartment);
            }

            deptComboBox.DisplayMember = "name";
            deptComboBox.ValueMember = "id";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string emailAddress = emailAddressTextBox.Text;
            string address = addressTextBox.Text;
            string phoneNumber = phoneNumberTextBox.Text;
            Department selecteDepartment = (Department)deptComboBox.SelectedItem;
            int departmentId = selecteDepartment.ID;

            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();
            string query = "INSERT INTO t_student VALUES('" + name + "','" + emailAddress + "','" + address + "','" +
                           phoneNumber + "','" + departmentId + "')";

            SqlCommand aCommand = new SqlCommand(query, aConnection);

            int rowAffected = aCommand.ExecuteNonQuery();

            aConnection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Succesfully Saved Data!!!");
            }
            else
            {
                MessageBox.Show("ERROR!!! Could not save Data!!!");
            }
        }
    }
}
