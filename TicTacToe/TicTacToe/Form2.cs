using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                
                Form1 f1 = new Form1(this);
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Unesite oba igraca");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox2.Focus();
            }
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPlay.Focus();
            }
            else if (e.KeyCode == Keys.Up)
                textBox1.Focus();
            else if (e.KeyCode == Keys.Down)
                btnPlay.Focus();
        }

        private void btnPlay_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Form1 f1 = new Form1(this);
                f1.ShowDialog();
            }
        }
    }
}
