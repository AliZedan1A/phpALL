using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace phpALL
{
    class databasecon
    {
        public MySqlConnection cn;
        public void conntion()
        {
            cn = new MySqlConnection("datasource=localhost;username=root;password=;database=271;SslMode=none");
        }
    }
}
