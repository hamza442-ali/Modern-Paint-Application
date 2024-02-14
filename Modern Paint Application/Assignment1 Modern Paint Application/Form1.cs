using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1_Modern_Paint_Application
{
    public partial class Form1 : Form
    {
        //Fields
        bool paint = false;
        int index = 1;
        int x, y, SX, SY, cX, cY;
        Color ColorP;
        Point pointX, pointY;
        Bitmap bitmapN;
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 2);
        Pen eraser = new Pen(Color.White, 2);
        ColorDialog colorDialog = new ColorDialog();
     


        //Methods

        static Point SetPoint(PictureBox pictureBox, Point point)
        {
            float pX = 1f * pictureBox.Image.Width / pictureBox.Width;
            float pY = 1f * pictureBox.Image.Height / pictureBox.Height;

            return new Point((int)(point.X * pX), (int)(point.Y * pY));
        }
        private void Validate(Bitmap bitmap, Stack<Point> pointStack, int x, int y, Color colorNew, Color colorOld)
        {
            Color cx = bitmap.GetPixel(x, y);
            if (cx == colorOld)
            {
                pointStack.Push(new Point(x, y));

                bitmap.SetPixel(x, y, colorNew);
            }
        }

        public void FillUp(Bitmap bitmap, int x, int y, Color newColor)
        {

            Color oldColor = bitmap.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bitmap.SetPixel(x, y, newColor);
            if (oldColor == newColor) return;
            while (pixel.Count > 0)
            {
                Point point =(Point) pixel.Pop();
                if (point.X > 0 && point.Y > 0 && point.X < bitmap.Width - 1 && point.Y < bitmap.Height - 1)
                {

                    Validate(bitmap, pixel, point.X - 1, point.Y, newColor, oldColor);
                    Validate(bitmap, pixel, point.X, point.Y - 1, newColor, oldColor);
                    Validate(bitmap, pixel, point.X + 1, point.Y, newColor, oldColor);
                    Validate(bitmap, pixel, point.X, point.Y + 1, newColor, oldColor);

                }



            }






        }
        public Form1()
        {



            InitializeComponent();
            bitmapN = new Bitmap(Pic.Width, Pic.Height);
            graphics = Graphics.FromImage(bitmapN);
            graphics.Clear(Color.White);
            Pic.Image = bitmapN;
            ButtonPencil.BackColor = ButtonPenWidth1.BackColor = Color.LightGreen;




        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonPenWidth3_Click(object sender, EventArgs e)
        {

        }

        private void PenColor_Click(object sender, EventArgs e)
        {




        }

        private void ButtonPencil_Click(object sender, EventArgs e)
        {

        }

        private void ButtonEraser_Click(object sender, EventArgs e)
        {

        }

        private void ButtonFillColor_Click(object sender, EventArgs e)
        {

        }

        private void ButtonColorDropper_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLine_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRectangle_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCircle_Click(object sender, EventArgs e)
        {

        }
        private void ButtonPenWidth2_Click(object sender, EventArgs e)
        {

        }
        private void buttonPolygon_Click(object sender, EventArgs e)
        {

        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonPenWidth1_Click(object sender, EventArgs e)
        {

        }

        private void Pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics gPaint = e.Graphics;
            if (paint)
            {

                if (index == 5)
                {

                    gPaint.DrawLine(pen, cX, cY, x, y);
                }
                else if (index == 6)
                {

                    gPaint.DrawRectangle(pen, cX, cY, SX, SY);
                }
                else if (index == 7)
                {
                    gPaint.DrawEllipse(pen, cX, cY, SX, SY);
                }
                else
                {
                    //empty
                }
            }
        }
        private void ButtonColor_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            PenColor.BackColor = pen.Color = ColorP = pictureBox.BackColor;
        }
        private void ButtonColorSwitcher_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            ColorP = PenColor.BackColor = pen.Color = colorDialog.Color;

        }
        private void ButtonPenWidth_Click(object sender, EventArgs e)
        {
            foreach (var btn in panelPenWidth.Controls.OfType<Button>())
                btn.BackColor = Color.WhiteSmoke;
                Button button = (Button)sender;
                button.BackColor = Color.LightGreen;
                pen.Width = eraser.Width = Convert.ToInt32(button.Tag);
            
        }
        private void Button_Click(object sender, EventArgs e)
        {

            foreach (var btn in  Pic.Controls.OfType<Button>())
                btn.BackColor = Color.WhiteSmoke;
                Button button = (Button) sender; 
                button.BackColor = Color.LightGreen; 
                index = Convert.ToInt32(button.Tag);
            
             
        }
        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            pointY = e.Location;

            cX= e.X;
            cY= e.Y;


        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            var S= new SaveFileDialog();
            S.Filter = "Image(*.jpg)|*.jpg|(*.*)| *.*";
            if (S.ShowDialog() == DialogResult.OK)
            {

                Bitmap bmp = bitmapN.Clone(new Rectangle(0, 0, Pic.Width, Pic.Height), bitmapN.PixelFormat);
                bmp.Save(S.FileName);

            }

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            Pic.Image = bitmapN;
            foreach (var btn in panelPenWidth.Controls.OfType<Button>())
                btn.BackColor = Color.WhiteSmoke;
            foreach(var btn in tableLayoutPanel1.Controls.OfType<Button>())
                btn.BackColor=Color.WhiteSmoke;
            ButtonPencil.BackColor = ButtonPencil.BackColor = Color.LightGreen;
            pen.Width = eraser.Width = 2;
            index = 1;


        }

        private void PanalTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            SX = x - cX;
            SY = y - cY;
            if (index == 5)
            {
                graphics.DrawLine(pen, cX, cY, x, y);

            }
            if (index == 6)
            {
                graphics.DrawRectangle(pen, cX, cY, SX, SY);
            }


            if (index == 7)
            {
                graphics.DrawEllipse(pen, cX, cY, SX, SY);
            }






        }
        private void Pic_MouseClick(object sender, MouseEventArgs e)
        {

            Point point = SetPoint(Pic, e.Location);
            if (index == 3)
            {
                FillUp(bitmapN, point.X, point.Y, ColorP);
            }
            if (index == 4)
            {
                ColorP = pen.Color = PenColor.BackColor = ((Bitmap)Pic.Image).GetPixel(point.X,point.Y);
            }


        }
        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {

            if (paint)
            {
                if (index == 1)
                {
                    pointX = e.Location;
                    graphics.DrawLine(pen, pointX, pointY);
                    pointY = pointX;
                }


                if (index == 2)
                {
                    pointX = e.Location;
                    graphics.DrawLine(eraser, pointX, pointY);
                    pointY = pointX;
                }
            }
            Pic.Refresh();
            x=e.X;
            y = e.Y;
            SX=e.X - cX;
            SY=e.Y - cY;

        }
        private void ButtonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
