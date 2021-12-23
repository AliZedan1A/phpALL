using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace phpALL
{ 

    public partial class login : Form
    {
        Form1 frm = new Form1();
        mysqlco sql = new mysqlco();

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int isuserAdmin =1;
            MySqlDataReader dr = sql.login(textBox2.Text, textBox1.Text);
            if (dr.Read())
            {
                MySqlConnection con1a = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=allowusers;SslMode=none");
        string commandstring = "SELECT isAdmin FROM `users` WHERE password";
                MySqlCommand cmm = new MySqlCommand(commandstring, con1a);
                con1a.Open();
                MySqlDataReader drm = cmm.ExecuteReader();
                if(drm.Read())
                {
                    MessageBox.Show("the admin  " + textBox2.Text);
                    this.Hide();
                    frm.ShowDialog();
                    sql.con.Close();
                    con1a.Close();

                }
                MessageBox.Show("welcome " + textBox2.Text);
                this.Hide();
                frm.ShowDialog();
                sql.con.Close();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ضع اسم المستخدم !");
                sql.con.Close();
                return;

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("ضع كلمة المرور!");
                sql.con.Close();
                return;
            }
            else
            {
                MessageBox.Show("كلمة المرور او اسم المستخدم خطأ");
                sql.con.Close();
                return;
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          MySqlConnection cons = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=allowusers;SslMode=none");
            cons.Open();
        string comand = "INSERT INTO `users`(`id`, `username`, `password`) VALUES ('3','"+textBox2.Text+"','"+textBox1.Text+"')";
            MySqlCommand cm1 = new MySqlCommand(comand,cons);
            string hereornot = "SELECT username FROM `users`";
            MySqlCommand commandyn = new MySqlCommand(hereornot,cons);

            try
            {
                
                cm1.ExecuteNonQuery();
                cons.Close();
                button2.Visible = false;
                label3.Visible = true;

            }       
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

                    

                

            


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

