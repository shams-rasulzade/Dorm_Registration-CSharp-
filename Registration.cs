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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }


        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-PE9P8LD;Initial Catalog=dorm_registration;Integrated Security=True");




        
        private void Registration_Load(object sender, EventArgs e)
        {
            //Showing the departments

            connection.Open();
            SqlCommand department_command = new SqlCommand("Select name from department", connection);
            SqlDataReader read_dep = department_command.ExecuteReader();

            while(read_dep.Read())
            {
                comboBox1.Items.Add(read_dep[0].ToString());
            }
            connection.Close();



            //Showing the available rooms

            connection.Open();
            SqlCommand room_command = new SqlCommand("Select no from room where capacity!=present", connection);
            SqlDataReader read_room = room_command.ExecuteReader();
            while (read_room.Read())
            {
                comboBox2.Items.Add(read_room[0].ToString());
            }
            connection.Close();
        }
    }
}
