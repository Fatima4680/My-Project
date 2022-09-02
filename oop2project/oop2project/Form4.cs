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
    public partial class Form4 : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\oop2project\db\logindata.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetSellerInfo()
        {

            SqlCommand sm = new SqlCommand("Select * from SELLERINFO ", sql);
            DataTable dt2 = new DataTable();
            sql.Open();
            SqlDataReader sdr2 = sm.ExecuteReader();
            dt2.Load(sdr2);
            //conn.Close();

            dataGridView1.DataSource = dt2;

            sql.Close();

        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form3 = (Form3)Tag;
            form3.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand sm = sql.CreateCommand();
            sm.CommandType = CommandType.Text;
            sm.CommandText = "Insert into SELLERINFO values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            sm.ExecuteNonQuery();
            sql.Close();
            comboBox1.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            show();
            MessageBox.Show("Add successfully!!");
        }

        public void show()
        {
            sql.Open();
            SqlCommand sm= sql.CreateCommand();
            sm.CommandType = CommandType.Text;
            sm.CommandText = "select * from SELLERINFO";
            sm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(sm);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            sql.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            GetSellerInfo();
            show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand c3 = new SqlCommand("DELETE FROM SELLERINFO WHERE SELLERID=@sellerid", sql);


            sql.Open();
            c3.Parameters.AddWithValue("@sellerid", Convert.ToInt32(textBox3.Text));

            c3.CommandType = CommandType.Text;
            c3.ExecuteNonQuery();
            sql.Close();
            comboBox1.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            MessageBox.Show("Deleted Successfully!!");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox3.Text = row.Cells["SELLERID"].Value.ToString();
                comboBox1.Text = row.Cells["GENDER"].Value.ToString();
                textBox1.Text = row.Cells["NAME"].Value.ToString();
                textBox2.Text = row.Cells["AGE"].Value.ToString();
                textBox4.Text = row.Cells["PHONENUMBER"].Value.ToString();
                textBox5.Text = row.Cells["CITY"].Value.ToString();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GetSellerInfo();
            comboBox1.Text = string.Empty;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand c2 = new SqlCommand("update SELLERINFO set NAME='" + textBox1.Text + "',AGE='" + textBox2.Text + "',GENDER='"+comboBox1.Text+"',PHONENUMBER='" + textBox4.Text + "',CITY='"+textBox5.Text+"' where SELLERID='" + textBox3.Text + "'", sql);

            c2.CommandType = CommandType.Text;

            c2.ExecuteNonQuery();
            sql.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand sm = sql.CreateCommand();
            sm.CommandType = CommandType.Text;
            sm.CommandText = "select * from SELLERINFO where NAME='" + textBox1.Text + "'";
            sm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(sm);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

                sql.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int box_int = 0;
            Int32.TryParse(textBox2.Text, out box_int);
            if(box_int < 18 && textBox2.Text !="")
            {
                textBox2.Text = "18";
                MessageBox.Show("Seller Age Must Be 18 or Above");
            }
            else if(box_int > 75 && textBox2.Text !="")
            {
                textBox2.Text = "75";
                MessageBox.Show("Seller Age Must Be Below 76");
            }
        }
    }
}
