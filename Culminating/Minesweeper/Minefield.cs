using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
    class Minefield : System.Windows.Forms.PictureBox
    {
        //Fields
        private int mSize;
        private Color mBackgroundColour;
        private Color mBorderColour;
        private Color mHiddenColour;
        private int mBorderThickness;
        private bool mCovered;
        private string mType;

        //Constructors
        public Minefield(Color HiddenColour, string Type)
        {
            this.mSize = 30;
            this.mBackgroundColour = Color.White;
            this.mBorderColour = Color.Black;
            this.mCovered = true;
            this.mHiddenColour = HiddenColour;
            this.mType = Type;
        }

        //Properties
        public Color BackgroundColour
        {
            set { this.mBackgroundColour = value; }
            get { return this.mBackgroundColour; }
        }

        public Color HiddenColour
        {
            set { this.mHiddenColour = value; }
            get { return this.mHiddenColour; }
        }

        public int BorderThickness
        {
            set { this.mBorderThickness = value; }
            get { return this.mBorderThickness; }
        }

        public bool Covered
        {
            set { this.mCovered = value; }
            get { return this.mCovered; }
        }

        public string Type
        {
            set { this.mType = value; }
            get { return this.mType; }
        }

        //Methods
        public void Draw(/*Graphics g,*/ int X, int Y)
        {
            //create a Pen and a Brush
            //Pen BorderPen = new Pen(this.mBorderColour, mBorderThickness);
            //SolidBrush BackBrush = new SolidBrush(this.mBackgroundColour);

            ////draw tile
            //g.FillRectangle(BackBrush, X, Y, this.mSize, this.mSize);
            //g.DrawRectangle(BorderPen, X, Y, this.mSize, this.mSize);

            ////dispose drawing tools
            //BorderPen.Dispose();
            //BackBrush.Dispose();

            System.Windows.Forms.PictureBox picture = new System.Windows.Forms.PictureBox();

            picture = new System.Windows.Forms.PictureBox();
            //picture[i, j].ImageLocation = @"C:\\Users\\HP Envy\\Downloads\\Image\\mine.jpg";
            picture.BackColor = Color.Black;
            picture.Visible = true;
            picture.Location = new Point(X, Y);
            picture.Size = new Size(30, 30);
            this.Controls.Add(picture);
        }
    }
}
