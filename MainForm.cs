﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatronicMouthGUI
{
    public partial class MainForm : Form
    {
        public VirtualFaceController VirtualFace;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VirtualFace = new VirtualFaceController(FaceBox);
        }

        private void FaceBox_Click(object sender, EventArgs e)
        {
            VirtualFace.writeFace(127);
        }


    }
}
