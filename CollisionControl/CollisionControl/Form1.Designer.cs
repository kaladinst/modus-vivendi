namespace CollisionControl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel = new Panel();
            startBt = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            collisionLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.Control;
            panel.Location = new Point(0, 27);
            panel.Name = "panel";
            panel.Size = new Size(797, 422);
            panel.TabIndex = 0;
            panel.Paint += panel1_Paint;
            // 
            // startBt
            // 
            startBt.Location = new Point(0, -2);
            startBt.Name = "startBt";
            startBt.Size = new Size(75, 23);
            startBt.TabIndex = 1;
            startBt.Text = "Start";
            startBt.UseVisualStyleBackColor = true;
            startBt.Click += startBt_Click;
            // 
            // collisionLabel
            // 
            collisionLabel.AutoSize = true;
            collisionLabel.Location = new Point(315, -2);
            collisionLabel.Name = "collisionLabel";
            collisionLabel.Size = new Size(139, 15);
            collisionLabel.TabIndex = 2;
            collisionLabel.Text = "Collision will appear here";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(collisionLabel);
            Controls.Add(startBt);
            Controls.Add(panel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel;
        private Button startBt;
        private System.Windows.Forms.Timer timer1;
        private Label collisionLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
