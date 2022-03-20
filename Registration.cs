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
        
        MySqlConnection mySqlConnection = new MySqlConnection();

        private void Registration_Load(object sender, EventArgs e)
        {
            //Showing the departments

            SqlCommand department_command = new SqlCommand("Select name from department", mySqlConnection.connection());
            SqlDataReader read_dep = department_command.ExecuteReader();

            while(read_dep.Read())
            {
                department_comboBox.Items.Add(read_dep[0].ToString());
            }
            mySqlConnection.connection().Close();



            //Showing the available rooms

            SqlCommand room_command = new SqlCommand("Select no from room where capacity!=present", mySqlConnection.connection());
            SqlDataReader read_room = room_command.ExecuteReader();
            while (read_room.Read())
            {
                room_comboBox.Items.Add(read_room[0].ToString());
            }
            mySqlConnection.connection().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand add_student_command = new SqlCommand("insert into student (name,surname,birthday,department,room,phone,email,parent,parent_phone,parent_address) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", mySqlConnection.connection());

                add_student_command.Parameters.AddWithValue("@p1", name_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p2", surname_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p3", birthday_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p4", department_comboBox.Text);
                add_student_command.Parameters.AddWithValue("@p5", room_comboBox.Text);
                add_student_command.Parameters.AddWithValue("@p6", phone_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p7", email_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p8", parent_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p9", parent_phone_textBox.Text);
                add_student_command.Parameters.AddWithValue("@p10", address_textBox.Text);
                add_student_command.ExecuteNonQuery();

                mySqlConnection.connection().Close();

                MessageBox.Show("Added Succesfully");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Department department_form = new Department();
            department_form.Show();
        }
    }
}
