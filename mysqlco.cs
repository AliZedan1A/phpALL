using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace phpALL
{
    class mysqlco
    {
        public MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=allowusers;SslMode=none");


        public MySqlDataReader login(string uid, string pass)
        {
            MySqlCommand cm = new MySqlCommand("select * from users where username=@uid and password=@pass", con);
            cm.Parameters.AddWithValue("@uid", uid);
            cm.Parameters.AddWithValue("@pass", pass);
            con.Open();
            MySqlDataReader dr = cm.ExecuteReader();
            return dr;

        }
    }
}
