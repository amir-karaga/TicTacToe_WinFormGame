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
    public partial class Form1 : Form
    {
        public int Brojac { get; set; }
        public int BrojacIgrac1 { get; set; } = 0;
        public int BrojacIgrac2 { get; set; } = 0;
        string igrac1;
        string igrac2;
        Form2 f2;
        public Form1(Form2 forma2)
        {
            InitializeComponent();
            this.f2 = forma2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            igrac1 = f2.textBox1.Text;
            igrac2 = f2.textBox2.Text;
            lblIgrac1.Text = igrac1;
            lblIgrac2.Text = igrac2;
            PrikaziNarednogIgraca();
        }

        private void PrikaziNarednogIgraca()
        {
            lblNaredniIgrac.Text = "Naredni >> " + ((Brojac % 2 == 0) ? igrac1 : igrac2);
        }

        void NapraviPotez(object sender)
        {
            Button button = sender as Button;

            if (button.Text == "")
            {
                if (Brojac % 2 == 0)
                {
                    button.Text = "X";
                    
                }
                else
                {
                    button.Text = "O";
                    
                }
                button.Enabled = false;
                Brojac++;
                PrikaziNarednogIgraca();
                if (KrajIgre())
                {
                    OnemoguciDugmice();
                    if (Brojac % 2 != 0)
                    {
                        MessageBox.Show("Pobjednik je " + igrac1);
                        BrojacIgrac1++;
                        lblRez1.Text = BrojacIgrac1.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Pobjednik je " + igrac2);
                        BrojacIgrac2++;
                        lblRez2.Text = BrojacIgrac2.ToString();
                    }
                    if(BrojacIgrac1+BrojacIgrac2==5)
                    {
                        MessageBox.Show("Ukupan rezultat je "+BrojacIgrac1+" - "+BrojacIgrac2);
                        Application.Exit();
                    }
                }
                else if (Brojac == 9)
                    MessageBox.Show("Nerijeseno");
            }
        }

        private void OnemoguciDugmice()
        {
            try
            {
                foreach (var item in Controls)
                {
                    if (item is Button)
                    {
                        Button button = item as Button;
                        button.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private bool KrajIgre()
        {
            if (ProvjeriRedove() || ProvjeriDijagonale() || ProvjeriKolone())
                return true;
            return false;
        }

        private bool ProvjeriKolone()
        {
            if (ProvjeriDugmice(button1, button4, button7)
              || ProvjeriDugmice(button2, button5, button8)
              || ProvjeriDugmice(button3, button6, button9))
                return true;
            return false;
        }

        private bool ProvjeriDijagonale()
        {
            if (ProvjeriDugmice(button1, button5, button9)
               || ProvjeriDugmice(button3, button5, button7))
                return true;
            return false;
        }

        private bool ProvjeriRedove()
            {
            if (ProvjeriDugmice(button1, button2, button3)
                || ProvjeriDugmice(button4, button5, button6)
                || ProvjeriDugmice(button7, button8, button9))
                return true;
            return false;
        }

        private bool ProvjeriDugmice(Button button1, Button button2, Button button3)
        {
            if((button1.Text != "" && button1.Text == button2.Text && button2.Text == button3.Text))
            {
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Green;
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brojac = 0;
            try
            {
                foreach (var item in Controls)
                {
                    if (item is Button)
                    {
                        Button b = item as Button;
                        b.Enabled = true;
                        b.Text = "";
                        b.BackColor = Button.DefaultBackColor;
                        PrikaziNarednogIgraca();
                    }
                }
            }
            catch
            { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)=> Application.Exit();
        //{
        //    Application.Exit();
        //}
    }
}
