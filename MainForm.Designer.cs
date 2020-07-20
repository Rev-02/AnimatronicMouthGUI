namespace AnimatronicMouthGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FaceBox = new System.Windows.Forms.PictureBox();
            this.NewsButton = new System.Windows.Forms.Button();
            this.WeatherButton = new System.Windows.Forms.Button();
            this.ChangeColButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ColPicker = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.FaceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FaceBox
            // 
            this.FaceBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.FaceBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("FaceBox.InitialImage")));
            this.FaceBox.Location = new System.Drawing.Point(15, 70);
            this.FaceBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FaceBox.Name = "FaceBox";
            this.FaceBox.Size = new System.Drawing.Size(488, 511);
            this.FaceBox.TabIndex = 0;
            this.FaceBox.TabStop = false;
            this.FaceBox.Click += new System.EventHandler(this.FaceBox_Click);
            // 
            // NewsButton
            // 
            this.NewsButton.Location = new System.Drawing.Point(676, 436);
            this.NewsButton.Name = "NewsButton";
            this.NewsButton.Size = new System.Drawing.Size(75, 23);
            this.NewsButton.TabIndex = 2;
            this.NewsButton.Text = "News";
            this.NewsButton.UseVisualStyleBackColor = true;
            this.NewsButton.Click += new System.EventHandler(this.NewsButton_Click);
            // 
            // WeatherButton
            // 
            this.WeatherButton.Location = new System.Drawing.Point(788, 436);
            this.WeatherButton.Name = "WeatherButton";
            this.WeatherButton.Size = new System.Drawing.Size(75, 23);
            this.WeatherButton.TabIndex = 3;
            this.WeatherButton.Text = "Weather";
            this.WeatherButton.UseVisualStyleBackColor = true;
            this.WeatherButton.Click += new System.EventHandler(this.WeatherButton_Click);
            // 
            // ChangeColButton
            // 
            this.ChangeColButton.Location = new System.Drawing.Point(628, 505);
            this.ChangeColButton.Name = "ChangeColButton";
            this.ChangeColButton.Size = new System.Drawing.Size(170, 23);
            this.ChangeColButton.TabIndex = 4;
            this.ChangeColButton.Text = "Change Eye Colour";
            this.ChangeColButton.UseVisualStyleBackColor = true;
            this.ChangeColButton.Click += new System.EventHandler(this.ColButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(532, 436);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(107, 23);
            this.UpdateButton.TabIndex = 1;
            this.UpdateButton.Text = "Full Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ColPicker
            // 
            this.ColPicker.Color = System.Drawing.Color.Blue;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(905, 594);
            this.Controls.Add(this.ChangeColButton);
            this.Controls.Add(this.WeatherButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.NewsButton);
            this.Controls.Add(this.FaceBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Face Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FaceBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox FaceBox;
        private System.Windows.Forms.Button NewsButton;
        private System.Windows.Forms.Button WeatherButton;
        private System.Windows.Forms.Button ChangeColButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.ColorDialog ColPicker;
    }
}

