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
    public partial class Form1 : Form
    {
        databasecon con = new databasecon();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            con.conntion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            timer1.Enabled = true;
            MessageBox.Show("عليك اختيار  تحديث الفاكشنات او الحسابات لتبدأ بلعمل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            try
            {
                con.cn.Open();
                command = new MySqlCommand("select * from accounts", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
                panel3.Visible = false;
                panel1.Visible = true;
                MessageBox.Show("تم تحديث الحسابات");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }

        }


        private void BTNm_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void BTNC_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            try
            {
                con.cn.Open();
                command = new MySqlCommand("select * from factions", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
                panel1.Visible = false;
                panel3.Visible = true;
                MessageBox.Show("تم تحديث الفاكشنات");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("select * from emailaccounts", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
                MessageBox.Show("تم تحديث اللوج");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.cn.Close();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (accAdmin.Text != "" || accEmail.Text != "" || accFrindMessge.Text != "" || accPass.Text != "" || accSuport.Text != "" || accUser.Text != "")
            {
                MySqlConnection cons = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=271;SslMode=none");
                cons.Open();
                if (accUser.Text == "")
                {
                    accUser.Text = "SELECT `username` FROM `accounts` WHERE id = " + int.Parse(accID.Text);

                }
                else if (accAdmin.Text == "")
                {
                    accAdmin.Text = "SELECT `admin` FROM `accounts` WHERE id = " + int.Parse(accID.Text);

                }
                string upd = "UPDATE `accounts` SET `username`='" + accUser.Text + "',`email`='" + accEmail.Text + "',`password`='" + accPass.Text + "',`admin`='" + accAdmin.Text + "',`supporter`='" + accSuport.Text + "',`friendsmessage`='" + accFrindMessge.Text + "' WHERE id = " + int.Parse(accID.Text);
                try
                {


                    MySqlCommand command = new MySqlCommand(upd, cons);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("update data");
                    }
                    else
                    {
                        MessageBox.Show("no");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cons.Close();
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("يرجى ملئ الحقول", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            aba.Left = aba.Left + 10;
        }

        private void factionN_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {


                MySqlConnection conf = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=271;SslMode=none");
                conf.Open();


            string fupd = "UPDATE `factions` SET `name`='" + int.Parse(factionN.Text) + "',`bankbalance`='" + int.Parse(factionB.Text) + "',`type`='" + int.Parse(factionT.Text) + "',`motd`='" + int.Parse(factionM.Text) + "',`fnote`='" + factionNote.Text + "',`phone`='" + factionPhon.Text + "' WHERE idF =" + int.Parse(factionID.Text);
                try
                {


                    MySqlCommand command = new MySqlCommand(fupd, conf);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("update data");
                    }
                    else
                    {
                        MessageBox.Show("no");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conf.Close();
                panel1.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تود حذف الحساب؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MySqlConnection cond = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=271;SslMode=none");
                string delet = "DELETE FROM `accounts` WHERE id =" + accID.Text;
                cond.Open();
                try
                {
                    MySqlCommand comd = new MySqlCommand(delet, cond);
                    if (comd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم الحذف");

                    }
                    else
                    {
                        MessageBox.Show("نعتذر,حصل خطأ ما");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("تم تخطي الحذف");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد انك تود حذف الحساب؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {


                MySqlConnection cond = new MySqlConnection("datasource=127.0.0.1;username=root;password=;database=271;SslMode=none");
                string delet = "DELETE FROM `accounts` WHERE id =" + factionID.Text;
                cond.Open();
                try
                {
                    MySqlCommand comd = new MySqlCommand(delet, cond);
                    if (comd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("تم الحذف");

                    }
                    else
                    {
                        MessageBox.Show("نعتذر,حصل خطأ ما");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("تم تخطي عملية الحذف");
            }
        }
        

        private void pb1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("عليك اختيار  تحديث الفاكشنات او الحسابات لتبدأ بلعمل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
