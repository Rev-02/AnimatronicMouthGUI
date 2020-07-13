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
            Console.WriteLine("Update");
        }

        private void NewsButton_Click(object sender, EventArgs e)
        {

        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {

        }

        private void ColButton_Click(object sender, EventArgs e)
        {
            int[] col = new int[] { 58, 96, 23 };
            Run.ChangeColour(col);
        }
    }
}
