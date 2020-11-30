using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool SpaceLeft = true;
        int size = 4;
        int counter1 = 0;
        int queens = 0;
        int numboard=0;
        int SolutionNum = -1;
        bool ShowingSol = false;
        Button[,] Board;
        int[][] Solustion = new int[0][];
        int[,] Board1;
        public Form1()
        {
            InitializeComponent();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("press solve and then possible outcomes- press multiple times for next outcome ");
            int ButtonSize = 70;
            //this.Size = new Size(size * ButtonSize + 20, size * ButtonSize + 80);
            //string s = textBox1.Text;                                    
            //int size = int.Parse(s);
            panel1.Size = new Size(size * ButtonSize, size * ButtonSize);
            panel1.Location = new Point(0, 35);
            Board = new Button[size, size];
            Board1 = new int[9, 9];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Board[i, j] = new Button();
                    Board[i, j].Width = panel1.Width / size;
                    Board[i, j].Height = panel1.Height / size;
                    Board[i, j].Location = new Point(Board[i, j].Height * i, Board[i, j].Width * j);
                    Board[i, j].Click += Form1_Click;
                    Board[i, j].Tag = i * size + j;
                    Board[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    panel1.Controls.Add(Board[i, j]);
                }
            }
            UpdateScreen();            
        }
        void UpdateScreen()
        {
            //numboard++;
            //MessageBox.Show("x"+numboard.ToString());
            //if (numboard ==4)
            //{
            //    MessageBox.Show("Test");
            //    for (int i = 0; i < size; i++)
            //    {
            //        if (Board1[1, i] == 1)
            //        {
            //            MessageBox.Show(i.ToString());
            //        }

            //    }
            //}
            SpaceLeft = false;
            int ind = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (Board1[i, j] == 1)
                        Board[i, j].Text = "queen ";
                    if (Board1[i, j] == -1)
                        Board[i, j].BackColor = Color.Blue;
                    if (Board1[i, j] == 0)
                    {
                        SpaceLeft = true;
                        Board[i, j].Text = null;
                        if (ind % 2 == 0)
                            Board[i, j].BackColor = Color.Red;
                        else
                            Board[i, j].BackColor = Color.White;
                    }
                    ind++;
                }
                if (size % 2 == 0)
                    ind++;
            }
            if (SpaceLeft == false && queens == size && ShowingSol == false)
            {
                DialogResult bla = MessageBox.Show("Great! You succeded! Restart?", "Winner!", MessageBoxButtons.YesNo);
                if (bla == DialogResult.Yes)
                    button1.PerformClick();
                else
                    this.Close();
            }
            else if (SpaceLeft == false && queens < size && !ShowingSol)
            {
                DialogResult bla = MessageBox.Show("Loser!!!", ":(", MessageBoxButtons.YesNo);
                if (bla == DialogResult.Yes)
                    button1.PerformClick();
                else
                    this.Close();
            }
        }
        void ArrayToScreen()
        {
            button1.PerformClick();
            for (int i = 0; i < size; i++)
            {
                Board1[i, Solustion[SolutionNum][i]] = 1;
            }
        }
        #region Click Manage
        private void Form1_Click(object sender, EventArgs e)
        {
            int index = int.Parse(((Button)(sender)).Tag.ToString());
            int col = index % size;
            int row = index / size;
            if (Board1[row, col] == 0 && ShowingSol == false)
            {
                queens += 1;
                Board1[row, col] = 1;
                for (int i = row + 1; i < size; i++)
                    Board1[i, col] = -1;
                for (int i = row - 1; i >= 0; i--)
                    Board1[i, col] = -1;
                for (int j = col + 1; j < size; j++)
                    Board1[row, j] = -1;
                for (int j = col - 1; j >= 0; j--)
                    Board1[row, j] = -1;
                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                    Board1[i, j] = -1;
                for (int i = row + 1, j = col + 1; i < size && j < size; i++, j++)
                    Board1[i, j] = -1;
                for (int i = row - 1, j = col + 1; i >= 0 && j < size; i--, j++)
                    Board1[i, j] = -1;
                for (int i = row + 1, j = col - 1; i < size && j >= 0; i++, j--)
                    Board1[i, j] = -1;
            }

            UpdateScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queens = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Board1[i, j] = 0;
            UpdateScreen();
            ShowingSol = false;
        }
        #endregion
        #region Recursion
        void Solve()
        {           
            int[] Arr = new int[size];// makes a new array 
            for (int i = 0; i < size; i++)
            Arr[i] = -1;// fills it with -1s 
            CheckQueens(Arr, 0);
            MessageBox.Show("There are " + Solustion.Length.ToString() + " Solutions To a Board Sized " + size.ToString() + "x" + size.ToString());
           // counter1--;
            MessageBox.Show(counter1.ToString());
        }
        bool CheckQueens(int[] Arr, int current)
        {
            if (current == size)
            {
                Array.Resize(ref Solustion, Solustion.GetLength(0) + 1);
                if (Solustion.GetLength(0) ==6)
                {
                  
                    for (int i = 0; i < size; i++)
                    {
                        if (Arr[i] == 0)
                        {
                            int newi = i + 1;
                           //MessageBox.Show(newi.ToString());
                        }

                    }
                }

                Solustion[Solustion.GetLength(0) - 1] = new int[size];
                Dup(Arr, Solustion[Solustion.GetLength(0) - 1]);
                if (Arr[size - 1] == size - 1 && Arr[0] == size - 1)
                    return true; //if didnt finish - keep searching
                //counter1++;
                return false;
                
            }
            else
            {
                int[] Arr1 = new int[size];
                Dup(Arr, Arr1);
                for (int i = 0; i < size; i++)
                {
                    Arr1[current] = i;
                    if (NoProblem(Arr1, current))
                    {
                        if (CheckQueens(Arr1, current + 1))// next = 
                            return true;
                    }
                }
            }
            counter1++;
            return false;
            
        }
        bool NoProblem(int[] Arr, int current)
        {
            for (int i = 0; i < current; i++)
            {
                if (Arr[i] == Arr[current]) //if the same row -> Problem
                    return false;
                else if (current - i == Math.Abs(Arr[i] - Arr[current])) // if the same slope -> problem
                    return false;
            }
            return true;
        }
        #endregion
        #region copy Functions
        void Dup(int[] Old, int[] New)
        {
            for (int i = 0; i < Old.Length; i++)
                New[i] = Old[i];
        }
        #endregion
          private void button2_Click_1(object sender, EventArgs e)
        {
            SolutionNum += 1;
            if (SolutionNum == Solustion.Length)
            {
                SolutionNum = 0;
            }
            ArrayToScreen();
            ShowingSol = true;
            UpdateScreen();
        }
          private void button4_Click_1(object sender, EventArgs e)
        {
            Solve();
            button4.Enabled = false;
            button2.Enabled = true;

        }
    }
}
