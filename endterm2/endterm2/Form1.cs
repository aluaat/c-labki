using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace endterm2
{
    public partial class Form1 : Form
    {
        List<string> gmails = new List<string>();

        List<string> password = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[0] == '@')
            {
                // textBox1.Text[100] s = new string[];

                //string gmail = textBox1.Text;
                MessageBox.Show("SAFE");
                gmails.Add(textBox1.Text);
                password.Add(textBox2.Text);


            }
            else
            {
                MessageBox.Show("please ,enter a valid email address");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gmails.Count(); i++)
            {
                if (textBox4.Text == gmails[i])
                {
                    for (int j = 0; j < password.Count(); j++)
                    {
                        if (textBox3.Text == password[i])
                        {
                            MessageBox.Show("OK");
                        }
                        else
                        {
                            MessageBox.Show("incorrect password or gmail ");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("incorrect password or gmail ");
                }
                

            




                

            }
        }
    }
}
