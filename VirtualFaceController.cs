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
        private int pPos = 3; //backing field for Pos
        protected int Pos
        {
            get
            {
                return pPos;
            }
            set
            {
                if (value > 3)
                {
                    pPos = value;
                }
                else
                {
                    pPos = 3;
                }
            }
        }
        PictureBox FaceBox;
        private int limit = 250;  //Sets  the highest point of the rectanlge image
        private int lowerPad = 5; //Sets the paddding around rectangle mouth

        public VirtualFaceController(PictureBox faceBox)
        {
            FaceBox = faceBox;
            FaceBox.Paint += new System.Windows.Forms.PaintEventHandler(drawPercentRect);
            Image blankimage = Image.FromFile("bitmap.png");
            FaceBox.Image = blankimage;
            Console.WriteLine(blankimage.Height);
            Console.WriteLine(blankimage.Width);
            Console.WriteLine(faceBox.Width);
        }

        public void writeFace(int pos)
        {
            Pos = (pos / 127) * (FaceBox.Height - limit - lowerPad);
            FaceBox.Refresh();            

        }
        public void drawPercentRect(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.DarkGray);
            Rectangle mouthArea = new Rectangle(5, limit,FaceBox.Width - 10, Pos);
            g.FillRectangle(brush, mouthArea);
        }

    }
}
