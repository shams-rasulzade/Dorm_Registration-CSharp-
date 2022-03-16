using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dorm_Registration
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void Department_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dorm_registrationDataSet.department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.dorm_registrationDataSet.department);

        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-PE9P8LD;Initial Catalog=dorm_registration;Integrated Security=True");


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand add_department_command = new SqlCommand("insert into Department (name) values (@p1)", connection);
                add_department_command.Parameters.AddWithValue("@p1", department_name_textBox.Text);
                add_department_command.ExecuteNonQuery();

                connection.Close();

                this.departmentTableAdapter.Fill(this.dorm_registrationDataSet.department);

                MessageBox.Show("Department Added");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR Occured");

            }
        }
    }
}
