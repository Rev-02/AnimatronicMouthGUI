﻿namespace AnimatronicMouthGUI
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(905, 594);
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
    }
}

