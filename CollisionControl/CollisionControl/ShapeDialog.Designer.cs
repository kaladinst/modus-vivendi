namespace CollisionControl
{
    partial class ShapeDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            shapeComboBox = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label4 = new Label();
            okBt = new Button();
            cancelBt = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // shapeComboBox
            // 
            shapeComboBox.FormattingEnabled = true;
            shapeComboBox.Items.AddRange(new object[] { "Point", "Quadrilateral", "Sphere", "Cylinder", "Rectangle", "RectangularPrism", "Surface", "Circle" });
            shapeComboBox.Location = new Point(314, 90);
            shapeComboBox.Name = "shapeComboBox";
            shapeComboBox.Size = new Size(121, 23);
            shapeComboBox.TabIndex = 0;
            shapeComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(329, 61);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 7;
            label4.Text = "Select Object 1 ";
            // 
            // okBt
            // 
            okBt.Location = new Point(255, 222);
            okBt.Name = "okBt";
            okBt.Size = new Size(75, 23);
            okBt.TabIndex = 8;
            okBt.Text = "OK";
            okBt.UseVisualStyleBackColor = true;
            okBt.Click += okBt_Click;
            // 
            // cancelBt
            // 
            cancelBt.Location = new Point(414, 222);
            cancelBt.Name = "cancelBt";
            cancelBt.Size = new Size(75, 23);
            cancelBt.TabIndex = 9;
            cancelBt.Text = "Cancel";
            cancelBt.UseVisualStyleBackColor = true;
            cancelBt.Click += cancelBt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(165, 258);
            label1.Name = "label1";
            label1.Size = new Size(394, 15);
            label1.TabIndex = 10;
            label1.Text = "For more accurate visuals and calculations try to limit the values below 20";
            // 
            // ShapeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(cancelBt);
            Controls.Add(okBt);
            Controls.Add(label4);
            Controls.Add(shapeComboBox);
            Name = "ShapeDialog";
            Text = "ShapeDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox shapeComboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label4;
        private Button okBt;
        private Button cancelBt;
        private Label label1;
    }
}