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
            connection.Open();
            SqlCommand command = new SqlCommand("Select name from department", connection);
            SqlDataReader read = command.ExecuteReader();

            while(read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
            }
            connection.Close();

        }
    }
}
