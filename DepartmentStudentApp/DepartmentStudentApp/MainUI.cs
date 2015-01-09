using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentStudentApp
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void entryStudentButton_Click(object sender, EventArgs e)
        {
            new StudentEntryUI().ShowDialog();
        }

        private void searchStudentButton_Click(object sender, EventArgs e)
        {
            new SearchStudentUI().ShowDialog();
        }
    }
}
