using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    //cifri prinimaut odinakovii deistvya "pri najatie na lubboi button (0-9)->dobavyat cifru :k odnomu kliku prekripit'

    public partial class Form1 : Form
    {
        public static calcc  calcul;
        public int cnt = 0;
        public Form1() //ob'ekt 
        {
            InitializeComponent();
            calcul = new calcc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            calcul.operation = calcc.Operstions.MINUS;
            calcul.savefirstnumber(textBox1.Text);
            cnt = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calcul.operation = calcc.Operstions.DIV;
            calcul.savefirstnumber(textBox1.Text);
            cnt = 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calcul.firstnumber = 0;
            calcul.secondnumber = 0;
            textBox1.Clear();
        }
        
        private void button16_Click(object sender, EventArgs e) //klick na cifri (0-9)
        {
            //nado sozdat' ob'ekt ot button-a
            Button btn = sender as Button;
            if (calcul.operation==calcc.Operstions.NONE || calcul.operation==calcc.Operstions.NUMBER)
            {
                if (textBox1.Text=="0")
                {
                    textBox1.Text = btn.Text;
                }
                else
                {
                    textBox1.Text += btn.Text;
                }
            }
            if (calcul.operation==calcc.Operstions.PLUS)
            {
                textBox1.Text = btn.Text;
                
            }
            if (calcul.operation == calcc.Operstions.MINUS)
            {
                textBox1.Text = btn.Text;

            }
            if (calcul.operation == calcc.Operstions.MUL)
            {
                textBox1.Text = btn.Text;


            }
            if (calcul.operation == calcc.Operstions.DIV)
            {
                textBox1.Text = btn.Text;

            }
            calcul.operation = calcc.Operstions.NUMBER;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calcul.operation = calcc.Operstions.PLUS;
            calcul.savefirstnumber(textBox1.Text);
            cnt = 1;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnt = 4;
            calcul.operation = calcc.Operstions.MUL;
            calcul.savefirstnumber(textBox1.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if(calcul.operation==calcc.Operstions.NUMBER || calcul.operation==calcc.Operstions.PLUS || calcul.operation== calcc.Operstions.MUL || calcul.operation == calcc.Operstions.MINUS || calcul.operation == calcc.Operstions.DIV)
            {
                calcul.savesecondnumber(textBox1.Text);
            }
            switch (cnt)
            {
                case 1:
                    textBox1.Text = calcul.plus().ToString();
                    break;
                case 2:
                    textBox1.Text = calcul.minus().ToString();
                    break;
                case 3:
                    textBox1.Text = calcul.mul().ToString();
                    break;
                case 4:
                    textBox1.Text = calcul.div().ToString();
                    break;

            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            calcul.operation = calcc.Operstions.SQR;
            calcul.savefirstnumber(textBox1.Text);
             textBox1.Text=calcul.sqr().ToString() ;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calcul.operation = calcc.Operstions.SQRT;
            calcul.savefirstnumber(textBox1.Text);
            textBox1.Text = calcul.sqrt().ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i=0;i<length;i++)
            {
                textBox1.Text += text[i];
            }
            if(textBox1.Text.Length==0)
            {
                textBox1.Text = "0";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            calcul.memorynumber = double.Parse(textBox1.Text);
            textBox1.Clear();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text = calcul.memorynumber.ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            calcul.memorynumber = 0;

        }

        private void button24_Click(object sender, EventArgs e)
        {
            calcul.memorynumber = double.Parse(textBox1.Text) + calcul.memorynumber;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            calcul.memorynumber = calcul.memorynumber - double.Parse(textBox1.Text);
        }

        private void button26_Click(object sender, EventArgs e)
        {
           // calcul.savefirstnumber(textBox1.Text);
            double x = double.Parse(textBox1.Text);
            x = -x;

            textBox1.Text = x.ToString();



           /* if(calcul.firstnumber>0)
            {
                //textBox1.Text =( 0 - calcul.firstnumber).ToString();

                textBox1.Text = ("-" + calcul.firstnumber).ToString();
            }
            if (calcul.firstnumber < 0)
            {
                textBox1.Text = Math.Abs( calcul.firstnumber).ToString();
            }*/
        }
    }
}
