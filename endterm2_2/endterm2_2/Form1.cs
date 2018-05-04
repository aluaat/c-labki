using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace endterm2_2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
       

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            pen = new Pen(Color.Orange, 4);
        }

       
   

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            g.DrawRectangle(pen, x, y, 20, 20);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            g.DrawArc(pen, x, y, 20, 20, 34, 76);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            g.DrawEllipse(pen, x, y, 20, 20);
          
        }

       
    }
}
