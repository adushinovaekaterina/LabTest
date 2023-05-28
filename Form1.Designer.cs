
namespace WindowsFormsApp
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelCentimeters = new System.Windows.Forms.Label();
            this.labelRadius = new System.Windows.Forms.Label();
            this.trackBarOfGeometricShapes = new System.Windows.Forms.TrackBar();
            this.labelAreaDescription = new System.Windows.Forms.Label();
            this.labelAreaCalculation = new System.Windows.Forms.Label();
            this.labelSizeOfGeometricShapes = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOfGeometricShapes)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(348, 359);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // numericUpDown
            // 
            this.numericUpDown.DecimalPlaces = 3;
            this.numericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown.Location = new System.Drawing.Point(9, 49);
            this.numericUpDown.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(87, 20);
            this.numericUpDown.TabIndex = 3;
            this.numericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelCentimeters
            // 
            this.labelCentimeters.AutoSize = true;
            this.labelCentimeters.Location = new System.Drawing.Point(102, 50);
            this.labelCentimeters.Name = "labelCentimeters";
            this.labelCentimeters.Size = new System.Drawing.Size(21, 13);
            this.labelCentimeters.TabIndex = 4;
            this.labelCentimeters.Text = "см";
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(6, 19);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(109, 13);
            this.labelRadius.TabIndex = 5;
            this.labelRadius.Text = "Радиус окружности:";
            // 
            // trackBarOfGeometricShapes
            // 
            this.trackBarOfGeometricShapes.Location = new System.Drawing.Point(5, 133);
            this.trackBarOfGeometricShapes.Name = "trackBarOfGeometricShapes";
            this.trackBarOfGeometricShapes.Size = new System.Drawing.Size(124, 45);
            this.trackBarOfGeometricShapes.SmallChange = 2;
            this.trackBarOfGeometricShapes.TabIndex = 1;
            this.trackBarOfGeometricShapes.Value = 5;
            this.trackBarOfGeometricShapes.ValueChanged += new System.EventHandler(this.trackBarOfGeometricShapes_ValueChanged);
            // 
            // labelAreaDescription
            // 
            this.labelAreaDescription.AutoSize = true;
            this.labelAreaDescription.Location = new System.Drawing.Point(6, 198);
            this.labelAreaDescription.Name = "labelAreaDescription";
            this.labelAreaDescription.Size = new System.Drawing.Size(94, 39);
            this.labelAreaDescription.TabIndex = 7;
            this.labelAreaDescription.Text = "Площадь \r\nзаштрихованной \r\nобласти:";
            // 
            // labelAreaCalculation
            // 
            this.labelAreaCalculation.AutoSize = true;
            this.labelAreaCalculation.Location = new System.Drawing.Point(6, 246);
            this.labelAreaCalculation.Name = "labelAreaCalculation";
            this.labelAreaCalculation.Size = new System.Drawing.Size(26, 13);
            this.labelAreaCalculation.TabIndex = 8;
            this.labelAreaCalculation.Text = "S = ";
            // 
            // labelSizeOfGeometricShapes
            // 
            this.labelSizeOfGeometricShapes.AutoSize = true;
            this.labelSizeOfGeometricShapes.Location = new System.Drawing.Point(6, 101);
            this.labelSizeOfGeometricShapes.Name = "labelSizeOfGeometricShapes";
            this.labelSizeOfGeometricShapes.Size = new System.Drawing.Size(134, 26);
            this.labelSizeOfGeometricShapes.TabIndex = 9;
            this.labelSizeOfGeometricShapes.Text = "Размер геометрических \r\nфигур:\r\n";
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.labelSizeOfGeometricShapes);
            this.groupBox.Controls.Add(this.labelAreaCalculation);
            this.groupBox.Controls.Add(this.labelAreaDescription);
            this.groupBox.Controls.Add(this.trackBarOfGeometricShapes);
            this.groupBox.Controls.Add(this.labelRadius);
            this.groupBox.Controls.Add(this.labelCentimeters);
            this.groupBox.Controls.Add(this.numericUpDown);
            this.groupBox.Location = new System.Drawing.Point(349, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(135, 359);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 359);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(399, 398);
            this.Name = "Form";
            this.Text = "Вычисление площади";
            this.ResizeBegin += new System.EventHandler(this.Form_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOfGeometricShapes)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label labelCentimeters;
        private System.Windows.Forms.Label labelRadius;
        private System.Windows.Forms.TrackBar trackBarOfGeometricShapes;
        private System.Windows.Forms.Label labelAreaDescription;
        private System.Windows.Forms.Label labelAreaCalculation;
        private System.Windows.Forms.Label labelSizeOfGeometricShapes;
        private System.Windows.Forms.GroupBox groupBox;
    }
}

