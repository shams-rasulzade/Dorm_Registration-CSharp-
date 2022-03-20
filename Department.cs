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

        MySqlConnection mySqlConnection = new MySqlConnection();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand add_department_command = new SqlCommand("insert into Department (name) values (@p1)", mySqlConnection.connection());
                add_department_command.Parameters.AddWithValue("@p1", department_name_textBox.Text);
                add_department_command.ExecuteNonQuery();


                mySqlConnection.connection().Close();                this.departmentTableAdapter.Fill(this.dorm_registrationDataSet.department);

                MessageBox.Show("Department Added");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR Occured");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand delete_department_command = new SqlCommand("delete from Department where id=@p1", mySqlConnection.connection());
                delete_department_command.Parameters.AddWithValue("@p1", department_id_textBox);
                delete_department_command.ExecuteNonQuery();

                mySqlConnection.connection().Close();

                this.departmentTableAdapter.Fill(this.dorm_registrationDataSet.department);
                MessageBox.Show("Department Deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR Occured");
            }
            
        }

        int choosen;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id, department_name;

            choosen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            department_name = dataGridView1.Rows[choosen].Cells[1].Value.ToString();

            department_id_textBox.Text = id;
            department_name_textBox.Text = department_name;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand edit_department_command = new SqlCommand("update Deparment Set name=@p2 where id=@p1", mySqlConnection.connection());
                edit_department_command.Parameters.AddWithValue("@p1", department_id_textBox);
                edit_department_command.Parameters.AddWithValue("@p2", department_name_textBox);
                edit_department_command.ExecuteNonQuery();

                mySqlConnection.connection().Close();

                this.departmentTableAdapter.Fill(this.dorm_registrationDataSet.department);

                MessageBox.Show("Department Edited");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR Occured");
            }
        }
    }
}
