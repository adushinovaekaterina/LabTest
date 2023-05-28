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

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private int vertices = 4; // количество вершин
        private double pix = 37.936; // размер фигур
        int _oldWidth, _oldHeight; // 
        int _oldTrackBar; // 
        float proportion = 1f; //

        public Form1()
        {
            InitializeComponent();

            double radius = (double)numericUpDown.Value * pix; // радиус считывается из numericUpDown
            DrawPolygon_Ellipse(radius); // вызов метода для отрисовки квадрата и эллипса по радиусу эллипса
            _oldTrackBar = trackBar.Value; // размер считывается из trackBar
        }

        // метод для отрисовки квадрата и эллипса по радиусу эллипса
        private void DrawPolygon_Ellipse(double radius)
        {
            int angle = 0; // начальный угол отрисовки квадрата

            Point center = new Point(pictureBox.Width / 2, pictureBox.Height / 2); // точка центра фигур по центру pictureBox

            Point[] verticies = CalculateVertices(radius, angle, center); // точки квадрата

            Bitmap polygon = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            // конструкция using оформляет блок кода и создает объект некоторого типа, который реализует интерфейс IDisposable,
            // в частности, его метод Dispose. При завершении блока кода у объекта вызывается метод Dispose

            // создание нового объекта Graphics из указанного объекта polygon
            using (Graphics g = Graphics.FromImage(polygon))
            {
                // визуализация со сглаживанием
                g.SmoothingMode = SmoothingMode.HighQuality;

                // кисть для закрашивания области, площадь которой надо найти
                HatchBrush hBrush = new HatchBrush(
                  HatchStyle.ForwardDiagonal,
                  Color.Black,
                  Color.White
                  );

                g.DrawEllipse(Pens.Black, center.X - (int)radius, center.Y - (int)radius, 2 * (int)radius, 2 * (int)radius);
                g.FillEllipse(hBrush, center.X - (int)radius, center.Y - (int)radius, 2 * (int)radius, 2 * (int)radius);

                g.DrawPolygon(Pens.Red, verticies); // отрисовка квадрата, определяемого массивом verticies

                SolidBrush brush = new SolidBrush(Color.White);
                g.FillPolygon(brush, verticies);

                //g.DrawEllipse(Pens.Blue, center.X, center.Y-50, 3, 3);
            }

            pictureBox.Image = polygon;

            label4.Text = "S=" + AreaCalculation((double)numericUpDown.Value).ToString();
        }

        // вычисление точек квадрата
        private Point[] CalculateVertices(double radius, int startingAngle, Point center)
        {
            // список точек
            List<Point> points = new List<Point>();
            float step = 360.0f / vertices; // значение, которое будет прибавляться к предыдущему углу и в котором будет строиться следующая вершина = 90
            float angle = startingAngle; // угол поворота, который должен увеличиваться на 90 градусов

            // i = 0; i < 0 + 360; i = 0 + 90
            // i = 90; i < 0 + 360; i = 0 + 90
            // i = 0; i < 0 + 360; i = 0 + 90
            // i = 0; i < 0 + 360; i = 0 + 90

            for (double i = startingAngle; i < startingAngle + 360.0; i += step) // квадрат строится вокруг окружности
            {
                Point xy = new Point();
                double radians = angle * Math.PI / 180.0;
                xy.X = (int)(Math.Cos(radians) * radius + center.X);
                xy.Y = (int)(Math.Sin(-radians) * radius + center.Y);
                points.Add(xy);
                angle += step;
            }
            return points.ToArray();
        }

        private double AreaCalculation(double radius)
        {
            return Math.Round(AreaCalculationEllipse(radius) - AreaCalculationPolygon(radius), 3);
        }

        private double AreaCalculationEllipse(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        private double AreaCalculationPolygon(double radius)
        {
            double a = radius * 10 / (Math.Sqrt(50 + 10 * Math.Sqrt(5)));
            return Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 4 * Math.Pow(a, 2);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            radiusChanged(trackBar.Value, _oldTrackBar);
            double radius = (double)numericUpDown.Value * pix;
            DrawPolygon_Ellipse(radius);
            _oldTrackBar = trackBar.Value;
        }

        private void radiusChanged(int a, int b)
        {
            if (a > b)
            {
                numericUpDown.Value = numericUpDown.Value + (numericUpDown.Value * (decimal)0.1);
            }
            else if (a < b)
            {
                numericUpDown.Value = numericUpDown.Value - (numericUpDown.Value * (decimal)0.1);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double radius = (double)numericUpDown.Value * pix;
            DrawPolygon_Ellipse(radius);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            double radius = (double)numericUpDown.Value * pix;
            DrawPolygon_Ellipse(radius);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            _oldWidth = Width;
            _oldHeight = Height;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            // если изменилась ширина с прошлого раза
            if (_oldWidth != Width)
            {
                control.Size = new Size(control.Size.Width, (int)(control.Size.Width * 1f / proportion));
                double koeff = (double)control.Size.Width / (double)_oldWidth;
                numericUpDown.Value = (numericUpDown.Value * (decimal)koeff);

            }
            // если изменилась высота с прошлого раза
            if (_oldHeight != Height)
            {
                control.Size = new Size((int)(control.Size.Height * proportion), control.Size.Height);
                double koeff = (double)control.Size.Height / (double)_oldHeight;
                numericUpDown.Value = numericUpDown.Value * (decimal)koeff;
            }
        }
    }
}
