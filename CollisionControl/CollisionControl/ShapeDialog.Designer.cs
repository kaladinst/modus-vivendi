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
            label4.Location = new Point(354, 60);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Shape";
            // 
            // okBt
            // 
            okBt.Location = new Point(249, 415);
            okBt.Name = "okBt";
            okBt.Size = new Size(75, 23);
            okBt.TabIndex = 8;
            okBt.Text = "OK";
            okBt.UseVisualStyleBackColor = true;
            okBt.Click += okBt_Click;
            // 
            // cancelBt
            // 
            cancelBt.Location = new Point(396, 415);
            cancelBt.Name = "cancelBt";
            cancelBt.Size = new Size(75, 23);
            cancelBt.TabIndex = 9;
            cancelBt.Text = "Cancel";
            cancelBt.UseVisualStyleBackColor = true;
            cancelBt.Click += cancelBt_Click;
            // 
            // ShapeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}