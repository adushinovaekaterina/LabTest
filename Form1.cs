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
    public partial class Form : System.Windows.Forms.Form
    {
        private int vertices = 4; // количество вершин
        private double pix = 37.936; // размер фигур домножается на это
        int _oldWidth, _oldHeight; // 
        int _oldTrackBar; //

        public Form()
        {
            InitializeComponent();

            double radius = (double)numericUpDown.Value * pix; // радиус считывается из numericUpDown
            DrawSquareAndEllipse(radius); // вызов метода для отрисовки квадрата и эллипса по радиусу эллипса
            _oldTrackBar = trackBarOfGeometricShapes.Value; // размер считывается из trackBar
        }

        // метод для отрисовки квадрата и эллипса по радиусу эллипса
        private void DrawSquareAndEllipse (double radius)
        {
            int angle = 0; // начальный угол отрисовки квадрата

            Point center = new Point(pictureBox.Width / 2, pictureBox.Height / 2); // точка центра фигур по центру pictureBox

            Point[] verticies = CalculateVertices (radius, angle, center); // точки квадрата вычисляются методом 

            Bitmap square = new Bitmap (pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            // конструкция using оформляет блок кода и создает объект некоторого типа, который реализует интерфейс IDisposable,
            // в частности, его метод Dispose. При завершении блока кода у объекта вызывается метод Dispose

            // создание нового объекта Graphics из указанного объекта square
            using (Graphics g = Graphics.FromImage(square))
            {
                // визуализация со сглаживанием
                g.SmoothingMode = SmoothingMode.HighQuality;

                // кисть для закрашивания области, площадь которой надо найти
                HatchBrush hBrush = new HatchBrush(
                  HatchStyle.ForwardDiagonal,
                  Color.Black,
                  Color.White
                  );

                g.DrawRectangle(Pens.Blue, (int)(center.X - Math.Sqrt(2) * (int)radius), (int)(center.Y - Math.Sqrt(2) * (int)radius), (int)(Math.Sqrt(2) * 2 * (int)radius), (int)(Math.Sqrt(2) * 2 * (int)radius));
                
                g.DrawPolygon(new Pen(Color.Red, 2), verticies); // отрисовка квадрата, определяемого массивом verticies

                g.FillPolygon(hBrush, verticies);

                g.DrawEllipse(new Pen(Color.Black, 2), center.X - (int)radius, center.Y - (int)radius, (int)(2 * radius), (int)(2 * radius));

                g.FillEllipse(new SolidBrush(Color.White), center.X - (int)radius, center.Y - (int)radius, (int)(2 * radius), (int)(2 * radius));
            }

            pictureBox.Image = square;

            // метод для расчета площади выводится в лэйбл
            labelAreaCalculation.Text = "S = " + AreaCalculation((double)numericUpDown.Value).ToString();
        }

        // вычисление точек квадрата
        private Point[] CalculateVertices (double radius, int startingAngle, Point center)
        {
            // список точек
            List<Point> points = new List<Point>();
            float step = 360.0f / vertices; // значение, которое будет прибавляться к предыдущему углу и в котором будет строиться следующая вершина = 90
            float angle = startingAngle; // угол поворота, который должен увеличиваться на 90 градусов

            // 4 раза отрабатывает
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) // квадрат строится вокруг окружности
            {
                Point xy = new Point();
                double radians = angle * Math.PI / 180.0; 
                xy.X = (int)(Math.Cos(radians) * Math.Sqrt(2) * radius + center.X);
                xy.Y = (int)(Math.Sin(-radians) * Math.Sqrt(2) * radius + center.Y);
                points.Add(xy);
                angle += step;
            }
            return points.ToArray();
            // координаты точек: (273; 222) (правая точка)
            //                   (166; 114) (нижняя точка)
            //                   (58;  222) (левая точка)
            //                   (165; 329) (верхняя точка)
        }

        // метод для расчета площади заштрихованной области
        private double AreaCalculation (double radius)
        {
            // округление до 3 числе после запятой
            return Math.Round(AreaCalculationSquare(radius) - AreaCalculationEllipse(radius), 3);
        }

        // метод для расчета площади окружности
        private double AreaCalculationEllipse (double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        // метод для расчета площади квадрата
        private double AreaCalculationSquare (double radius)
        {
            double a = 2 * radius;
            return Math.Pow(a, 2);
        }

        // обработчик события изменения значения trackBar
        private void trackBarOfGeometricShapes_ValueChanged(object sender, EventArgs e)
        {
            radiusChanged (trackBarOfGeometricShapes.Value, _oldTrackBar);
            double radius = (double)numericUpDown.Value * pix;
            DrawSquareAndEllipse(radius);
            _oldTrackBar = trackBarOfGeometricShapes.Value;
        }

        // метод для изменения радиуса
        private void radiusChanged (int a, int b)
        {
            // если новое значение trackBar больше старого
            if (a > b)
            {
                numericUpDown.Value = numericUpDown.Value + (numericUpDown.Value * (decimal)0.1);
            }

            // если новое значение trackBar меньше старого
            else if (a < b)
            {
                numericUpDown.Value = numericUpDown.Value - (numericUpDown.Value * (decimal)0.1);
            }
        }

        // обработчик события изменения значения numericUpDown
        private void numericUpDown_ValueChanged (object sender, EventArgs e)
        {
            // берется значение из numericUpDown, приравнивается к радиусу и перерисовываются фигуры
            double radius = (double)numericUpDown.Value * pix;
            DrawSquareAndEllipse(radius);
        }

        // обработчик события изменения размера формы
        private void Form_Resize (object sender, EventArgs e)
        {
            double radius = (double)numericUpDown.Value * pix;
            DrawSquareAndEllipse(radius);
        }

        // событие ResizeBegin возникает, когда пользователь начинает изменять размер формы,
        // это действие помещает форму в модальный цикл изменения размера до завершения операции изменения размера
        private void Form_ResizeBegin (object sender, EventArgs e)
        {
            _oldWidth = Width;
            _oldHeight = Height;
        }

        // событие ResizeEnd возникает, когда пользователь завершает изменение размера формы
        private void Form_ResizeEnd (object sender, EventArgs e)
        {
            // Control - базовый класс для элементов управления, являющихся компонентами с визуальным представлением
            Control control = (Control)sender;

            // если изменилась ширина с прошлого раза
            if (_oldWidth != Width)
            {
                double koeff = (double)control.Size.Width / (double)_oldWidth;
                numericUpDown.Value = numericUpDown.Value * (decimal)koeff;
            }
            // если изменилась высота с прошлого раза
            if (_oldHeight != Height)
            {
                double koeff = (double)control.Size.Height / (double)_oldHeight;
                numericUpDown.Value = numericUpDown.Value * (decimal)koeff;
            }
        }
    }
}