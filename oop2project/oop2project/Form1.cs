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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("invaliid");
            }
            else
            {

            
           // SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\oop2project\db\logindata.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "select * from LOGINTABLE where username='" + textBox4.Text.Trim() + "' and password='" + textBox3.Text.Trim() + "' and Type='" + comboBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, database.sqlcon);

            DataTable dtb1 = new DataTable();
                


            sda.Fill(dtb1);
                if (dtb1.Rows.Count == 1)
                {
                    string query1 = "select Type from LOGINTABLE where username='" + textBox4.Text.Trim() + "' and password='" + textBox3.Text.Trim() + "' ";
                    SqlDataAdapter sda1 = new SqlDataAdapter(query1, database.sqlcon);
                    DataTable dtb2 = new DataTable();
                    sda1.Fill(dtb2);

                    if (dtb2.Rows.Count == 1 && comboBox2.Text == "admin")
                    {
                        Form3 form3 = new Form3();
                        form3.Tag = this;
                        this.Hide();
                        form3.Show();
                        comboBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                    }

                    if (dtb2.Rows.Count == 1 && comboBox2.Text == "seller")
                    {
                        Form2 form2 = new Form2();
                        form2.Tag = this;
                        this.Hide();
                        form2.Show();
                        comboBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            double i = 0;
            if(double.TryParse(textBox3.Text, out i))
            {
                errorProvider1.SetError(textBox3, "");
            }
            else
            {
                errorProvider1.SetError(textBox3, "Password allows only number");
            }
        }
    }
}
