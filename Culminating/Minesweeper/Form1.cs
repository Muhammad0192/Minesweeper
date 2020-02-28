using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Minefields minefields = new Minefields();
        int FirstClick = 0;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            minefields.NumberValue();
            minefields.Draw(/*g,*/ 20, 50);

            //dispose graphics object
            g.Dispose();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = (e.Y - 50) / 30;
            int Y = (e.X - 20) / 30;
            FirstClick += 1;

            if (X >= 0 && X < 10 && Y >= 0 && Y < 10)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (minefields.Minesweeper[X, Y].Covered == true)
                    {
                        if (FirstClick == 1)
                        {
                            while (minefields.Minesweeper[X, Y].Type != "Blank")
                            {
                                minefields.Shuffle();

                                for (int i = 0; i < 10; i++)
                                {
                                    for (int j = 0; j < 10; j++)
                                    {
                                        if (minefields.Minesweeper[i, j].Type != "Mine")
                                        {
                                            minefields.Minesweeper[i, j].Type = "Blank";
                                            minefields.Minesweeper[i, j].HiddenColour = Color.White;
                                            minefields.NumberValue();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Reveal(X, Y);
                }

                else if (e.Button == MouseButtons.Right)
                {
                    if (minefields.Minesweeper[X, Y].Type == "Blank" || minefields.Minesweeper[X, Y].Type == "Mine")
                    {
                        minefields.Minesweeper[X, Y].Type = "Flagged";
                        minefields.Minesweeper[X, Y].BackgroundColour = Color.Gray;
                    }
                }
            }

            this.Refresh();
        }

        public void Reveal(int X, int Y)
        {
            if (minefields.Minesweeper[X, Y].Covered && minefields.Minesweeper[X, Y].Type == "Blank")
            {
                minefields.Minesweeper[X, Y].Covered = false;
                if (X + 1 < 10)
                {
                    Reveal(X + 1, Y);

                    if (minefields.Minesweeper[X + 1, Y].Type != "Blank" && minefields.Minesweeper[X + 1, Y].Type != "Mine")
                    {
                        minefields.Minesweeper[X + 1, Y].BackgroundColour = minefields.Minesweeper[X + 1, Y].HiddenColour;
                        minefields.Minesweeper[X + 1, Y].BorderThickness = 4;
                    }
                }

                if (X - 1 >= 0)
                {
                    Reveal(X - 1, Y);

                    if (minefields.Minesweeper[X - 1, Y].Type != "Blank" && minefields.Minesweeper[X - 1, Y].Type != "Mine")
                    {
                        minefields.Minesweeper[X - 1, Y].BackgroundColour = minefields.Minesweeper[X - 1, Y].HiddenColour;
                        minefields.Minesweeper[X - 1, Y].BorderThickness = 4;
                    }
                }

                if (Y + 1 < 10)
                {
                    Reveal(X, Y + 1);

                    if (minefields.Minesweeper[X, Y + 1].Type != "Blank" && minefields.Minesweeper[X, Y + 1].Type != "Mine")
                    {
                        minefields.Minesweeper[X, Y + 1].BackgroundColour = minefields.Minesweeper[X, Y + 1].HiddenColour;
                        minefields.Minesweeper[X, Y + 1].BorderThickness = 4;
                    }
                }

                if (Y - 1 >= 0)
                {
                    Reveal(X, Y - 1);

                    if (minefields.Minesweeper[X, Y - 1].Type != "Blank" && minefields.Minesweeper[X, Y - 1].Type != "Mine")
                    {
                        minefields.Minesweeper[X, Y - 1].BackgroundColour = minefields.Minesweeper[X, Y - 1].HiddenColour;
                        minefields.Minesweeper[X, Y - 1].BorderThickness = 4;
                    }
                }

                if (!minefields.Minesweeper[X, Y].Covered)
                {
                    minefields.Minesweeper[X, Y].BackgroundColour = minefields.Minesweeper[X, Y].HiddenColour;
                    minefields.Minesweeper[X, Y].BorderThickness = 4;
                }
            }

            else if (minefields.Minesweeper[X, Y].Type != "Blank" && minefields.Minesweeper[X, Y].Type != "Mine")
            {
                minefields.Minesweeper[X, Y].BackgroundColour = minefields.Minesweeper[X, Y].HiddenColour;
                minefields.Minesweeper[X, Y].BorderThickness = 4;
            }

            else if (minefields.Minesweeper[X, Y].Type == "Mine")
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        minefields.Minesweeper[i, j].BackgroundColour = minefields.Minesweeper[i, j].HiddenColour;
                    }
                }
            }
        }
    }
}
