using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dorm_Registration
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dorm_registrationDataSet1.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dorm_registrationDataSet1.student);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_label.Text = DateTime.Now.ToLongDateString();
            time_label.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
