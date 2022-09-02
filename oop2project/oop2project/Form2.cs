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
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\oop2project\db\logindata.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetItemRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from ITEM ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            //conn.Close();

            dataGridView1.DataSource = dt;

            con.Close();

        }
        public static string itemid;
        public static string name;
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Green;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Red;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chocolate cake");
            comboBox1.Items.Add("Vanilla cake");
            comboBox1.Items.Add("Red Velvet");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Green;
            radioButton3.ForeColor = System.Drawing.Color.Red;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Brown Bread");
            comboBox1.Items.Add("Milk Bread");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Green;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Dry Cake");
            comboBox1.Items.Add("Cookies");
            comboBox1.Items.Add("Pineapple Bicuits");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Chocolate Cake")
            {
              PriceTxt.Text = "500";

            }
            else if (comboBox1.SelectedItem.ToString() == "Vanilla Cake")
            {
                PriceTxt.Text = "400";
            }
            else if (comboBox1.SelectedItem.ToString() == "Red Velvet")
            {
                PriceTxt.Text = "750";
            }
            else if (comboBox1.SelectedItem.ToString() == "Brown Bread")
            {
                PriceTxt.Text = "175";
            }
            else if (comboBox1.SelectedItem.ToString() == "Milk Bread")
            {
                PriceTxt.Text = "60";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dry Cake")
            {
                PriceTxt.Text = "200";
            }
            else if (comboBox1.SelectedItem.ToString() == "Cookies")
            {
                PriceTxt.Text = "100";
            }
            else if (comboBox1.SelectedItem.ToString() == "Pineapple Bicuits")
            {
                PriceTxt.Text = "60";
            }

            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Quantitytxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into ITEM values('"+comboBox1.Text+"','"+Quantitytxt.Text+"','"+PriceTxt.Text+"','"+Totaltxt.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            comboBox1.Text = "";
            Quantitytxt.Text = "";
            PriceTxt.Text = "";
            Totaltxt.Text = "";

            dis_data();
            MessageBox.Show("Add successfully!!");
        }
        public void dis_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ITEM";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void buttonremove_Click(object sender, EventArgs e)
        {
            SqlCommand cl = new SqlCommand("DELETE FROM ITEM WHERE ITEMID=@itemid", con);


            con.Open();
            cl.Parameters.AddWithValue("@itemid", Convert.ToInt32(textBox1.Text));

            cl.CommandType = CommandType.Text;
            cl.ExecuteNonQuery();
            con.Close();

            comboBox1.Text = string.Empty;
            textBox1.Clear();
            Quantitytxt.Clear();
            PriceTxt.Clear();
            Totaltxt.Clear();



            MessageBox.Show("Deleted Successfully!!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetItemRecord();
            dis_data();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ITEMID"].Value.ToString();
                
                Quantitytxt.Text = row.Cells["QUANTITY"].Value.ToString();
                PriceTxt.Text = row.Cells["PRICE"].Value.ToString();
                Totaltxt.Text = row.Cells["TOTAL"].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetItemRecord();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cl = new SqlCommand("update ITEM set ITEM_NAME='" + comboBox1.Text + "',QUANTITY='" + Quantitytxt.Text + "',PRICE='" + PriceTxt.Text + "',TOTAL='" + Totaltxt.Text + "' where ITEMID='" + textBox1.Text + "'", con);

            cl.CommandType = CommandType.Text;

            cl.ExecuteNonQuery();
            con.Close();
            comboBox1.Text = string.Empty;
            textBox1.Clear();
            Quantitytxt.Clear();
            PriceTxt.Clear();
            Totaltxt.Clear();
            MessageBox.Show(" Update Successfully!!");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            }

        private void button5_Click(object sender, EventArgs e)
        {
            

            
        }
    }
}
