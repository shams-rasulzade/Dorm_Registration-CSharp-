using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dorm_Registration
{
    public class MySqlConnection
    {
        public SqlConnection connection()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-PE9P8LD;Initial Catalog=dorm_registration;Integrated Security=True");
            connect.Open();
            return connect;
        }
    }
}
