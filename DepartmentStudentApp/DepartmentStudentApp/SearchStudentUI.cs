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
    public partial class SearchStudentUI : Form
    {
        public SearchStudentUI()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=lict\sqlexpress; Database=UniversityDB; Integrated Security=True";
        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Student> studentList = new List<Student>();
            searchResultListView.Items.Clear();
            int inputId;
            
            if (!String.IsNullOrEmpty(idTextBox.Text))
            {
              inputId = Convert.ToInt32(idTextBox.Text);
            }
            else
            {
                inputId = 0;
            }

            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();

            string query;

            if (inputId==0)
            {
                if(deptComboBox.Text!=String.Empty)
                {
                    Department selecteDepartment = (Department)deptComboBox.SelectedItem;
                    int inputDept = selecteDepartment.ID;
                    query = "SELECT std.id, std.name, std.email_address, std.address, std.phone_number, dept.name dept_name FROM t_student std LEFT JOIN t_department dept ON std.dept_id = dept.id WHERE std.dept_id='" + inputDept + "'";
                }
                else
                {
                    query = "SELECT std.id, std.name, std.email_address, std.address, std.phone_number, dept.name dept_name FROM t_student std LEFT JOIN t_department dept ON std.dept_id = dept.id";
                }
            }
            else
            {
                
                query = "SELECT std.id, std.name, std.email_address, std.address, std.phone_number, dept.name dept_name FROM t_student std LEFT JOIN t_department dept ON std.dept_id = dept.id WHERE std.id='" + inputId + "'";
            }

            SqlCommand aCommand = new SqlCommand(query, aConnection);

            SqlDataReader aReader = aCommand.ExecuteReader();

            while (aReader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int)aReader["id"];
                aStudent.Name = aReader["name"].ToString();
                aStudent.EmailAddress = aReader["email_address"].ToString();
                aStudent.Address = aReader["address"].ToString();
                aStudent.PhoneNumber = aReader["phone_number"].ToString();
                aStudent.DepartmentName = aReader["dept_name"].ToString();
                studentList.Add(aStudent);
            }

            foreach (Student aStudent in studentList)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = aStudent.Id.ToString();
                aListViewItem.SubItems.Add(aStudent.Name);
                aListViewItem.SubItems.Add(aStudent.EmailAddress);
                aListViewItem.SubItems.Add(aStudent.Address);
                aListViewItem.SubItems.Add(aStudent.PhoneNumber);
                aListViewItem.SubItems.Add(aStudent.DepartmentName);

                aListViewItem.Tag = aStudent;

                searchResultListView.Items.Add(aListViewItem);
            }

            idTextBox.Text = String.Empty;
            deptComboBox.Text = String.Empty;
            aConnection.Close();
        }

        private void searchResultListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = searchResultListView.SelectedItems[0];
            Student selectedStudent = (Student)selectedItem.Tag;

            string message = "ID:\t" + selectedStudent.Id + "\nName:\t" + selectedStudent.Name +
                             "\nEmail:\t" + selectedStudent.EmailAddress + "\nAddress:\t" + selectedStudent.Address +
                             "\nPhone:\t" + selectedStudent.PhoneNumber + "\nDept:\t" +
                             selectedStudent.DepartmentName;

            MessageBox.Show(message);
        }

        private void SearchStudentUI_Load(object sender, EventArgs e)
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
                aDepartment.ID = (int)aReader["id"];
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
    }
}
