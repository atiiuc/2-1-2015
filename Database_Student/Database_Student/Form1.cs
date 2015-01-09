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

namespace Database_Student
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = @"server=FTFL\SQLEXPRESS; Integrated Security = true; database = StudentInfo";
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string idInput = idText.Text;
            SqlConnection connection = new SqlConnection(connectionString);
            

            connection.Open();

            string query=
@"SELECT std.id, std.name, std.dept_no,dept.name as dept_name
FROM t_Student std
INNER JOIN t_Department dept
ON std.dept_no=dept.id where std.id='"+idInput+"'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.ID = (int)reader["id"];
             
                aStudent.Name = reader["name"].ToString();
                aStudent.Dept_No = reader["dept_no"].ToString();
                aStudent.Dept_Name = reader["dept_name"].ToString();
             
                studentList.Add(aStudent);
            }

        
            studentShowList.Items.Clear();
           
            foreach (var astudent in studentList)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = astudent.ID.ToString();
                
                aListViewItem.SubItems.Add(astudent.Name);
                aListViewItem.SubItems.Add(astudent.Dept_No);
                aListViewItem.SubItems.Add(astudent.Dept_Name);

                aListViewItem.Tag = astudent; 

                studentShowList.Items.Add(aListViewItem);



        }


        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}

    }
}
}
