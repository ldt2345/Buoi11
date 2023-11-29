using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BT1
{
    public class Ketnoi
    {
        public SqlConnection conn;
        public Ketnoi()
        {
            conn = new SqlConnection("Data Source=A209PC49;Initial Catalog=QLSV;Integrated Security=True");
        }
        public Ketnoi(string ketnoi)
        {
            conn = new SqlConnection(ketnoi);
        }

    }
}
