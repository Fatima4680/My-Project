using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace oop2project
{
    public class database
    {
        public static SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\oop2project\db\logindata.mdf;Integrated Security=True;Connect Timeout=30");
    }
}
