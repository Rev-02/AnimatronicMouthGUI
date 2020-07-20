using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatronicMouthGUI
{
    public partial class MainForm : Form
    {
        public VirtualFaceController VirtualFace;
        public RunLogic Run;
        private Thread voiceThread = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VirtualFace = new VirtualFaceController(FaceBox);
            Run = new RunLogic(VirtualFace);
            Run.Setup();
        }

        private void FaceBox_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            voiceThread = new Thread(new ThreadStart(Run.fullUpdate)); //use thread so it is non-blocking of winform
            voiceThread.Start();
        }

        private void NewsButton_Click(object sender, EventArgs e)
        {
            voiceThread = new Thread(new ThreadStart(Run.NewsUpdate)); //use thread so it is non-blocking of winform
            voiceThread.Start();
        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {
            voiceThread = new Thread(new ThreadStart(Run.WeatherUpdate)); //use thread so it is non-blocking of winform
            voiceThread.Start();
        }

        private void ColButton_Click(object sender, EventArgs e)
        {
            if (ColPicker.ShowDialog() == DialogResult.OK)
            {
                Color chosenCol = ColPicker.Color;
                int[] col = new int[] { map(chosenCol.R,0,255,0,127), map(chosenCol.G, 0, 255, 0, 127), map(chosenCol.B, 0, 255, 0, 127) };
                Run.ChangeColour(col);
            }
            
        }

        private int map(int variable, int inMin, int inMax, int outMin, int outMax)
        {
            return (variable - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
