using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Minesweeper
{
    class Minefields : System.Windows.Forms.PictureBox
    {
        //fields
        private Minefield[,] mMinefields;
        private int mRows, mColumns, mCellSize;
        Random random = new Random();

        //constructor
        public Minefields()
        {
            this.mRows = 10;
            this.mColumns = 10;
            this.mCellSize = 30;

            //create the array
            mMinefields = new Minefield[mRows, mColumns];

            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    if (i == 0 && j <= 9)
                    {
                        this.mMinefields[i, j] = new Minefield(Color.Black, "Mine");
                    }

                    else
                    {
                        this.mMinefields[i, j] = new Minefield(Color.White, "Blank");
                    }
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Minefield SwitchGrid;
            int SwitchRow;
            int SwitchColumn;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < mRows; j++)
                {
                    for (int k = 0; k < mColumns; k++)
                    {
                        SwitchGrid = mMinefields[j, k];
                        SwitchRow = random.Next(0, 10);
                        SwitchColumn = random.Next(0, 10);
                        mMinefields[j, k] = mMinefields[SwitchRow, SwitchColumn];
                        mMinefields[SwitchRow, SwitchColumn] = SwitchGrid;
                    }
                }
            }
        }

        public void NumberValue()
        {
            int Counter = 0;

            for (int i = 0; i < mRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    if (mMinefields[i, j].Type == "Blank")
                    {
                        if (i + 1 < mRows)
                        {
                            if (mMinefields[i + 1, j].Type == "Mine") Counter += 1;
                        }

                        if (i - 1 >= 0)
                        {
                            if (mMinefields[i - 1, j].Type == "Mine") Counter += 1;
                        }

                        if (j + 1 < mColumns)
                        {
                            if (mMinefields[i, j + 1].Type == "Mine") Counter += 1;
                        }

                        if (j - 1 >= 0)
                        {
                            if (mMinefields[i, j - 1].Type == "Mine") Counter += 1;
                        }

                        if (i + 1 < mRows && j + 1 < mColumns)
                        {
                            if (mMinefields[i + 1, j + 1].Type == "Mine") Counter += 1;
                        }

                        if (i + 1 < mRows && j - 1 >= 0)
                        {
                            if (mMinefields[i + 1, j - 1].Type == "Mine") Counter += 1;
                        }

                        if (i - 1 > 0 && j + 1 < mColumns)
                        {
                            if (mMinefields[i - 1, j + 1].Type == "Mine") Counter += 1;
                        }

                        if (i - 1 >= 0 && j - 1 >= 0)
                        {
                            if (mMinefields[i - 1, j - 1].Type == "Mine") Counter += 1;
                        }

                        mMinefields[i, j].Type = Counter.ToString();
                        if (Counter == 0) mMinefields[i, j].Type = "Blank";
                        else if (Counter == 1) mMinefields[i, j].HiddenColour = Color.Red;
                        else if (Counter == 2) mMinefields[i, j].HiddenColour = Color.Orange;
                        else if (Counter == 3) mMinefields[i, j].HiddenColour = Color.Yellow;
                        else if (Counter == 4) mMinefields[i, j].HiddenColour = Color.Green;
                        else if (Counter == 5) mMinefields[i, j].HiddenColour = Color.Blue;
                        else if (Counter == 6) mMinefields[i, j].HiddenColour = Color.Indigo;
                        else if (Counter == 7) mMinefields[i, j].HiddenColour = Color.Violet;
                        else if (Counter == 8) mMinefields[i, j].HiddenColour = Color.Purple;
                        Counter = 0;
                    }
                }
            }
        }

        public Minefield[,] Minesweeper
        {
            set { this.mMinefields = value; }
            get { return this.mMinefields; }
        }

        //methods
        public void Draw(/*Graphics g,*/ int X, int Y)
        {
            //draw the grid starting from (X, Y) top left corner

            //co-ordinate values for looping
            int pX = X;
            int pY = Y;

            //loop through each row and column and draw the cell
            for (int i = 0; i < mRows; i++)
            {
                pY = Y + (i * this.mCellSize);
                for (int j = 0; j < mColumns; j++)
                {
                    pX = X + (j * this.mCellSize);
                    mMinefields[i, j].Draw(/*g,*/ pX, pY);
                }
            }
        }
    }
}
