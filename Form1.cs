using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form : System.Windows.Forms.Form
    {
        private int vertices = 4; // количество вершин
        private double pix = 43; // радиус домножается на это
        int _oldWidth, _oldHeight;
        int _oldTrackBar;

        public Form()
        {
            InitializeComponent();

            double radius = (double)numericUpDown.Value * pix; // радиус считывается из numericUpDown
            DrawSquareAndEllipse(radius); // вызов метода для отрисовки квадрата и эллипса по радиусу эллипса
            _oldTrackBar = trackBarOfGeometricShapes.Value; // размер считывается из trackBar
        }

        private void DrawSquareAndEllipse (double radius) // метод для отрисовки квадрата и эллипса по радиусу эллипса
        {
            int angle = 0; // начальный угол отрисовки квадрата

            Point center = new Point(pictureBox.Width / 2, pictureBox.Height / 2); // точка центра фигур по центру pictureBox

            Point[] verticies = CalculateVertices (radius, angle, center); // точки квадрата вычисляются методом 

            Bitmap figures = new Bitmap (pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);

            using (Graphics g = Graphics.FromImage(figures))
            {                
                g.SmoothingMode = SmoothingMode.HighQuality; // визуализация со сглаживанием
                                
                HatchBrush hBrush = new HatchBrush( // кисть для закрашивания области, площадь которой надо найти
                  HatchStyle.ForwardDiagonal,
                  Color.Black,
                  Color.White
                  );
                
                g.DrawRectangle(Pens.Blue, (float)(center.X - Math.Sqrt(2) * radius), (float)(center.Y - Math.Sqrt(2) * radius), (float)(Math.Sqrt(2) * 2 * radius), (float)(Math.Sqrt(2) * 2 * radius)); // внешний квадрат

                g.DrawPolygon(new Pen(Color.Red, 2), verticies); // отрисовка внутреннего квадрата, определяемого массивом verticies
                               
                g.FillPolygon(hBrush, verticies); // заливка внутреннего квадрата
                
                g.DrawEllipse(new Pen(Color.Black, 2), (float)(center.X - radius), (float)(center.Y - radius), (float)(2 * radius), (float)(2 * radius)); // окружность
               
                g.FillEllipse(new SolidBrush(Color.White), (float)(center.X - radius), (float)(center.Y - radius), (float)(2 * radius), (float)(2 * radius)); // заливка окружности
            }

            pictureBox.Image = figures; 
                        
            labelAreaCalculation.Text = "S = " + AreaCalculation((double)numericUpDown.Value).ToString(); // метод для расчета площади выводится в лэйбл
        }
        
        private Point[] CalculateVertices (double radius, int startingAngle, Point center) // вычисление вершин квадрата
        {            
            List<Point> points = new List<Point>(); // список точек
            float step = 360.0f / vertices; // значение, которое будет прибавляться к предыдущему углу и в котором будет строиться следующая вершина = 90
            float angle = startingAngle; // угол начала поворота, который должен увеличиваться на 90 градусов
                        
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) // квадрат строится вокруг окружности, 4 раза отрабатывает
            {
                Point xy = new Point();
                double radians = angle * Math.PI / 180.0; 
                xy.X = (int)(Math.Cos(radians) * Math.Sqrt(2) * radius + center.X);
                xy.Y = (int)(Math.Sin(-radians) * Math.Sqrt(2) * radius + center.Y);
                points.Add(xy);
                angle += step;
            }
            return points.ToArray(); // координаты точек: (273; 222 - правая точка), (166; 114 - нижняя точка), (58;  222 - левая точка), (165; 329 - верхняя точка)       
        }
                
        private double AreaCalculation (double radius) // метод для расчета площади заштрихованной области
        {           
            return Math.Round(AreaCalculationSquare(radius) - AreaCalculationEllipse(radius), 3); // округление до 3 числе после запятой
        }

        private double AreaCalculationSquare(double radius) // метод для расчета площади квадрата
        {
            double a = 2 * radius;
            var s = Math.Pow(a, 2);
            return s;
        }

        private double AreaCalculationEllipse (double radius) // метод для расчета площади окружности
        {
            var e = Math.PI * Math.Pow(radius, 2);
            return e;
        }
        
        private void trackBarOfGeometricShapes_ValueChanged(object sender, EventArgs e) // обработчик события изменения значения trackBar
        {
            try
            {
                radiusChanged(trackBarOfGeometricShapes.Value, _oldTrackBar);
                double radius = (double)numericUpDown.Value * pix;
                DrawSquareAndEllipse(radius);
                _oldTrackBar = trackBarOfGeometricShapes.Value;
            }
            catch(Exception)
            {
                MessageBox.Show("Некорректное значение радиуса. Радиус должен быть в пределах от " + numericUpDown.Minimum + " см до " + numericUpDown.Maximum + " см. Увеличьте или уменьшите размер геометрических фигур с помощью ползунка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void radiusChanged (int a, int b) // метод для изменения радиуса
        {            
            if (a > b) // если новое значение trackBar больше старого
            {
                numericUpDown.Value = numericUpDown.Value + (numericUpDown.Value * (decimal)0.1);
            }
           
            else if (a < b) // если новое значение trackBar меньше старого
            {
                numericUpDown.Value = numericUpDown.Value - (numericUpDown.Value * (decimal)0.1);
            }
        }
        
        private void numericUpDown_ValueChanged (object sender, EventArgs e) // обработчик события изменения значения numericUpDown
        {
            if (numericUpDown.Value > numericUpDown.Minimum && numericUpDown.Value < numericUpDown.Maximum)
            {
                double radius = (double)numericUpDown.Value * pix; // берется значение из numericUpDown, приравнивается к радиусу 
                DrawSquareAndEllipse(radius); // и перерисовываются фигуры
            }
            else
            {
                numericUpDown.Value = 2;
                MessageBox.Show("Некорректное значение радиуса. Радиус должен быть в пределах от " + numericUpDown.Minimum + " см до " + numericUpDown.Maximum + " см.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void Form_Resize (object sender, EventArgs e) // обработчик события изменения размера формы
        {
            double radius = (double)numericUpDown.Value * pix;
            DrawSquareAndEllipse(radius);
        }

        private void Form_ResizeBegin (object sender, EventArgs e) // событие ResizeBegin возникает, когда пользователь начинает изменять размер формы
        {
            _oldWidth = Width;
            _oldHeight = Height;
        }
                
        private void Form_ResizeEnd (object sender, EventArgs e) // событие ResizeEnd возникает, когда пользователь завершает изменение размера формы
        {
            try
            {                 
                Control control = (Control)sender; // Control - базовый класс для элементов управления, являющихся компонентами с визуальным представлением
                               
                if (_oldWidth != Width)  // если изменилась ширина с прошлого раза
                {
                    double koeff = (double)control.Size.Width / (double)_oldWidth;
                    numericUpDown.Value = numericUpDown.Value * (decimal)koeff;
                }
                
                if (_oldHeight != Height) // если изменилась высота с прошлого раза
                {
                    double koeff = (double)control.Size.Height / (double)_oldHeight;
                    numericUpDown.Value = numericUpDown.Value * (decimal)koeff;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Некорректное значение радиуса. Радиус должен быть в пределах от " + numericUpDown.Minimum + " см до " + numericUpDown.Maximum + " см. Увеличьте или уменьшите размер окна.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}