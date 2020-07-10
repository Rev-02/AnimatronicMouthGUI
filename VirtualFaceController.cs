using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimatronicMouthGUI
{
    public class VirtualFaceController
    {
        Graphics g;
        protected int Pos;

        public VirtualFaceController(PictureBox faceBox)
        {
            faceBox.Image = Image.FromFile("bitmap.png");
            g = faceBox.CreateGraphics();
        }

        public void writeFace(int pos)
        {
            Pos = pos;
            

        }
        public void drawPercentRect()
        {
            
            SolidBrush brush = new SolidBrush(Color.DarkGray);
            Rectangle mouthArea = new Rectangle(0, 0, 435, 615);
            g.FillRectangle(brush, mouthArea);
        }

    }
}
