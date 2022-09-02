using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LT2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Tag = this;
            form2.Show();
            Hide();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                Form3 nextForm = new Form3();
                this.Hide();
                nextForm.ShowDialog();
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        int i = 0;
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            Random x = new Random();
            i++;
            Point pt = new Point(
                int.Parse(x.Next(900).ToString()),
                int.Parse(x.Next(300).ToString())

                );
            button2.Location = pt;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
