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


namespace paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        // создаем пустую очередь типа string  queue<string> myQueue;
        //Инициализирует новый экземпляр класса Queue<T>, который является пустым и имеет начальную емкость по умолчанию. 
        //Queue<T>()      Queue<T>(Int32)
        Bitmap btm;
        Queue<Point> q = new Queue<Point>();
        Pen pen;
        Point  prev,cur;
        bool clicked;
        Color color, fillcolor;
        int trackbar;
        public SolidBrush brush;
        public enum Tool
        {
            PEN,
            CIRCLE ,
            RECTANGLE ,
            FILL,
            ERASER
        };
        Tool t = Tool.PEN;



        public Form1()
        {
            InitializeComponent();
            
             btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            
            g = Graphics.FromImage(btm);// sozdaet novy ob'ekt GRAPHICS iz ukazannogo  ob'ekta image=btm
            g.Clear(Color.White);
          //  pen = new Pen(Color.Violet, 5);
            clicked = false;
           // t = Tool.PEN;


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

           
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
          
            
            
            if (t == Tool.FILL)
            {
                color = btm.GetPixel(e.X, e.Y);
                q.Enqueue(new Point(e.X, e.Y));
                btm.SetPixel(e.X, e.Y, fillcolor);

                while (q.Count > 0)
                {
                    Point cur = q.Dequeue();

                    FillCheck(cur.X + 1, cur.Y);
                    FillCheck(cur.X - 1, cur.Y);
                    FillCheck(cur.X, cur.Y + 1);
                    FillCheck(cur.X, cur.Y - 1);
                }
                pictureBox1.Refresh();

            }
            
        }
       
        public void FillCheck(int x, int y)
        {
            if (x < 0 || y < 0 || x >= pictureBox1.Width || y >= pictureBox1.Height)
                return;
            if (btm.GetPixel(x, y) == color)
            {
                fillcolor = pictureBox1.BackColor;

                btm.SetPixel(x, y, fillcolor);
                q.Enqueue(new Point(x, y));

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location; //возвращает расположение указателя мыши в момент создания события мыши
            if (clicked && t==Tool.PEN ) //clicked && t -чтобы только после клика рисовался 
            {
                g.DrawLine(new Pen(pictureBox1.BackColor, trackbar), prev.X, prev.Y, cur.X, cur.Y);
                 pictureBox1.Refresh();
                
                prev = cur;
            }
           /* if (clicked && t==Tool.FILL)
            {
                g.DrawLine(new Pen(pictureBox1.BackColor, trackbar), prev.X, prev.Y, cur.X, cur.Y);
                pictureBox1.Refresh();
                prev = cur;
            }*/
            if(clicked==true && t==Tool.ERASER)
            {
                g.DrawLine(new Pen(Color.White, trackBar1.Value), prev, cur);
            }
            pictureBox1.Refresh();
        }

        public void Check(int x, int y)
        {
            if (x < 0 || y < 0 || x >= pictureBox1.Width || y >= pictureBox1.Height)
                return;

            if (btm.GetPixel(x, y) == color)
            {
                btm.SetPixel(x, y, fillcolor);
                q.Enqueue(new Point(x, y));
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (clicked && t==Tool.RECTANGLE)
            {
                int x = Math.Min(prev.X, cur.X);
                int y = Math.Min(prev.Y, cur.Y);
                int w = Math.Abs(prev.X - cur.X);
                int h = Math.Abs(prev.Y - cur.Y);
             g.DrawRectangle(new Pen(pictureBox1.BackColor, trackbar), new Rectangle(x, y, w, h));
                pictureBox1.Refresh();
                



                
            }
            if (clicked && t==Tool.CIRCLE)
            {
                int x = Math.Min(prev.X, cur.X);
                int y = Math.Min(prev.Y, cur.Y);
                int w = Math.Abs(prev.X - cur.X);
                int h = Math.Abs(prev.Y - cur.Y);
                g.DrawEllipse(new Pen(pictureBox1.BackColor, trackbar), new Rectangle(x, y, w, h));
                pictureBox1.Refresh();
            }
            clicked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = Tool.CIRCLE;
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            t = Tool.FILL;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (clicked && t == Tool.RECTANGLE)
            {
                int x = Math.Min(prev.X, cur.X);
                int y = Math.Min(prev.Y, cur.Y);
                int w = Math.Abs(prev.X - cur.X);
                int h = Math.Abs(prev.Y - cur.Y);
                e.Graphics.DrawRectangle(new Pen(pictureBox1.BackColor, trackbar), new Rectangle(x, y, w, h));
               




            }
            if (clicked && t == Tool.CIRCLE)
            {
                int x = Math.Min(prev.X, cur.X);
                int y = Math.Min(prev.Y, cur.Y);
                int w = Math.Abs(prev.X - cur.X);
                int h = Math.Abs(prev.Y - cur.Y);
                e.Graphics.DrawEllipse(new Pen(pictureBox1.BackColor, trackbar), new Rectangle(x, y, w, h));
                
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackbar = trackBar1.Value;//возвращает численное значение ползука на полосе 
        }

       

       


        private void chooseCOLOR_click(object sender, EventArgs e)
        {
             DialogResult colorResult = colorDialog1.ShowDialog();
                 if (colorResult==DialogResult.OK)
             {
                 pictureBox1.BackColor
                     = colorDialog1.Color; 
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1  = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(.BMP)|.BMP|Image Files(.JPG)|.JPG|Image Files(.GIF)|.GIF";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                btm = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = btm;
                g = Graphics.FromImage(btm);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Image Files(.BMP)|.BMP|Image Files(.JPG)|.JPG|Image Files(.GIF)|.GIF";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            t = Tool.ERASER;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            t = Tool.RECTANGLE;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
           
        }

        
    }
}
