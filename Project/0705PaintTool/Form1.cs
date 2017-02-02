using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0705PaintTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(pic.Width, pic.Height);

            btn1.BackColor = Color.Red;
            btn2.BackColor = Color.Orange;
            btn3.BackColor = Color.Yellow;
            btn4.BackColor = Color.Green;
            btn5.BackColor = Color.Blue;
            btn6.BackColor = Color.Indigo;
            btn7.BackColor = Color.Purple;
            btn8.BackColor = Color.White;
            btn9.BackColor = Color.Black;

            // ●太さのデフォルト
            cmbWidth.SelectedIndex = 0;
        }

        Bitmap _bitmap = null;

        private void button1_Click(object sender, EventArgs e)
        {
            //using (Graphics g = pic.CreateGraphics())
            //{
            //    g.DrawLine(Pens.Blue, 100, 100, 300, 200);
            //}

            //using (Graphics g = Graphics.FromImage(_bitmap))
            //{
            //    g.DrawLine(Pens.Blue, 100, 100, 300, 200);
            //}
            //pic.Image = _bitmap;
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            oldLocation = e.Location;

            drawFlg = true;
        }

        bool drawFlg = false;
        Point oldLocation = new Point();
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawFlg == false) return;

            int penWidth = Int32.Parse(cmbWidth.SelectedItem.ToString());
            Pen pen = new Pen(_selectedColor, penWidth);

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                  g.DrawLine(pen, oldLocation, e.Location);
               // g.FillEllipse(Brushes.Red, e.Location.X, e.Location.Y, 20,20);

            }
            pic.Image = _bitmap;

            // ●新しい位置を保存する
            oldLocation = e.Location;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            drawFlg = false;
        }

        Color _selectedColor = Color.Black;
        private void btn_Click(object sender, EventArgs e)
        {
            _selectedColor = ((Button)sender).BackColor;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Point xy1 = new Point(100, 100);
            Point xy2 = new Point(300, 200);

            int penWidth = 20;

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                Rectangle rect = new Rectangle(xy1.X, xy1.Y, penWidth, penWidth);               
                g.FillEllipse(Brushes.Red, rect);
            }
            pic.Image = _bitmap;
        }
    }
}
