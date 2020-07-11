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
        int[][] ColorArray = new int[][]
        {
            new int[] {0,0,0},
            new int[] {0,0,0}
        };
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
            FaceBox.Paint += new System.Windows.Forms.PaintEventHandler(drawFace);
            Image blankimage = Image.FromFile("bitmap.png");
            FaceBox.Image = blankimage;
        }

        public void writeFace(string strpos, int[][] colorArray)
        {
            int pos = Convert.ToInt32(strpos);
            float percent = (float)pos/(127);
            Pos = Convert.ToInt32(percent * (FaceBox.Height - limit - lowerPad));
            for (int i = 0; i < 2; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    ColorArray[i][a] = colorArray[i][a];
                }
            }
            FaceBox.Refresh();            

        }
        private void drawFace(object sender, PaintEventArgs e)
        {
            g = e.Graphics; //generate graphics area from picturebox
            Color LeftColour = new Color(); //left eyecolour
            Color RightColour = new Color(); //right eye colour
            LeftColour = Color.FromArgb(map(ColorArray[0][0],0,128,0,255), map(ColorArray[0][1], 0, 128, 0, 255),
                map(ColorArray[0][2], 0, 128, 0, 255)); //Copy colours from array and map to ARGB
            RightColour = Color.FromArgb(map(ColorArray[1][0],0,128,0,255), map(ColorArray[1][1], 0, 128, 0, 255),
                map(ColorArray[1][2], 0, 128, 0, 255)); //Copy colours from array and map to ARGB
            SolidBrush Mouthbrush = new SolidBrush(Color.DarkGray); //Dark gray colour for mouth rectanlge
            SolidBrush Leftbrush = new SolidBrush(LeftColour); //Left eye colour
            SolidBrush Rightbrush = new SolidBrush(RightColour); // right eye colour
            Rectangle mouthArea = new Rectangle(5, limit, FaceBox.Width - 10, Pos);
            Rectangle LeftEye = new Rectangle(80, 120, 10, 10); //has coordiantes for eye position
            Rectangle RightEye = new Rectangle(273,120, 10, 10);
            g.FillRectangle(Mouthbrush, mouthArea);
            g.FillEllipse(Leftbrush, LeftEye);
            g.FillEllipse(Rightbrush, RightEye);
        }

        private int map(int variable,int inMin,int inMax,int outMin, int outMax)
        {
            return (variable - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }
    }
}
