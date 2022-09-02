using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace oop2project
{
    public partial class Form3 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\oop2project\db\logindata.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetItemInfo()
        {

            SqlCommand cmds = new SqlCommand("Select * from ITEMINFO ", conn);
            DataTable dt1 = new DataTable();
            conn.Open();
            SqlDataReader sdr1 = cmds.ExecuteReader();
            dt1.Load(sdr1);
            //conn.Close();

            dataGridView1.DataSource = dt1;

            conn.Close();

        }
        public static string itemid;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Tag = this;
            form4.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmds = conn.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "Insert into ITEMINFO values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmds.ExecuteNonQuery();
            conn.Close();
            display();
            MessageBox.Show("Add successfully!!");
        }
        public void display()
        {
            conn.Open();
            SqlCommand cmds = conn.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from ITEMINFO";
            cmds.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmds);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
                
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            display();
            GetItemInfo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand c2 = new SqlCommand("DELETE FROM ITEMINFO WHERE ITEMID=@itemid", conn);


            conn.Open();
            c2.Parameters.AddWithValue("@itemid", Convert.ToInt32(textBox4.Text));

            c2.CommandType = CommandType.Text;
            c2.ExecuteNonQuery();
            conn.Close();

            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();


            MessageBox.Show("Deleted Successfully!!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox4.Text = row.Cells["ITEMID"].Value.ToString();

                textBox1.Text = row.Cells["ITEMNAME"].Value.ToString();
                textBox2.Text = row.Cells["CATEGORY"].Value.ToString();
                textBox3.Text = row.Cells["PRICE"].Value.ToString();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetItemInfo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cl = new SqlCommand("update ITEMINFO set ITEMNAME='" + textBox1.Text + "',category='" + textBox2.Text + "',PRICE='" + textBox3.Text + "' where ITEMID='" + textBox4.Text + "'", conn);

            cl.CommandType = CommandType.Text;

            cl.ExecuteNonQuery();
            conn.Close();
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            MessageBox.Show(" Update Successfully!!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmds = conn.CreateCommand();
            cmds.CommandType = CommandType.Text;
            cmds.CommandText = "select * from ITEMINFO where ITEMNAME='"+textBox1.Text+"'";
            cmds.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmds);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            conn.Close();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Enter only Character");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Enter only Character");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Enter only digit");
            }
        }
    }
}
