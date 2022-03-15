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
    }
}
