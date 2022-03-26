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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dorm_registrationDataSet2.loan' table. You can move, or remove it, as needed.
            this.loanTableAdapter.Fill(this.dorm_registrationDataSet2.loan);

        }
    }
}
