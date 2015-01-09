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

namespace Database_ComboSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connectionString =
            @"Data Source = FTFL\SQLEXPRESS ; Database = StudentInfo; Integrated Security = true";



        private void Form1_Load(object sender, EventArgs e)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT id,name FROM t_Department";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {
                Student aStudent = new Student();

                aStudent.Dept_No = reader["id"].ToString();
                aStudent.Dept_Name = reader["name"].ToString();
                studentList.Add(aStudent);
            }

            reader.Close();
            connection.Close();

            comboText.Items.Clear();



            foreach (Student aStudent in studentList)
            {
                comboText.Items.Add(aStudent);
            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            comboText.DisplayMember = "Dept_Name";
            comboText.ValueMember = "Dept_No";




        }

        private void SaveButton_Click(object sender, EventArgs e)
        {


            string name = nameText.Text;
            string emailAddress = emailText.Text;

            Student selecteDepartment = (Student) comboText.SelectedItem;
            string departmentId = selecteDepartment.Dept_No;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO t_student VALUES('" + name + "','" + departmentId + "','" + emailAddress + "')";



            SqlCommand aCommand = new SqlCommand(query, connection);

            int rowAffected = aCommand.ExecuteNonQuery();

            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Succesfully Saved Data!!!");
            }
            else
            {
                MessageBox.Show("ERROR!!! Could not save Data!!!");
            }



        }

        private void SearchButtton_Click(object sender, EventArgs e)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            Student selecteDepartment = (Student) comboText.SelectedItem;
            string departmentId = selecteDepartment.Dept_No;

            string query = @"SELECT std.id, std.name, std.dept_no,std.email,dept.name as dept_name
 FROM t_Student std INNER JOIN t_Department dept ON std.dept_no=dept.id where std.dept_no='" + departmentId + "'";

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {

                Student aStudent = new Student();
                aStudent.regNo = (int) reader["id"];

                aStudent.Name = reader["name"].ToString();
                aStudent.Dept_No = reader["dept_no"].ToString();
                aStudent.Dept_Name = reader["dept_name"].ToString();
                aStudent.Email = reader["email"].ToString();

                studentList.Add(aStudent);

            }

            reader.Close();
            connection.Close();

            studentShowList.Items.Clear(); 

            foreach (var astudent in studentList)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = astudent.regNo.ToString();
               
                aListViewItem.SubItems.Add(astudent.Name);
                aListViewItem.SubItems.Add(astudent.Email);
                aListViewItem.SubItems.Add(astudent.Dept_No);
                aListViewItem.SubItems.Add(astudent.Dept_Name);

                aListViewItem.Tag = astudent;

                studentShowList.Items.Add(aListViewItem);

            }
        }
    }
}
