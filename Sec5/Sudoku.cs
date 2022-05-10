using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sec5
{
    public partial class Sudoku : Form
    {
        int[,] level = {
            { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },

            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },

            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            { 0, 0, 5, 2, 0, 6, 3, 0, 0 },
           };
        TextBox[,] textBoxes = new TextBox[9, 9];
        string[] cellValues = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", };
        List<int[,]> solutionPath = new List<int[,]>();
        Node CurrentNode;
        public Sudoku()
        {
            InitializeComponent();
            createGame();


        }

        

        void createGame()
        {
            var allBoxes = Controls.OfType<TextBox>();
            var boxes = allBoxes.ToArray();
            //TextBox[,] textBoxes = new TextBox[9, 9]; 

            for (byte i = 0; i < 9; i++)
            {
                for (byte j = 0; j < 9; j++)
                {   
                    textBoxes[i, j] = boxes[((9 * i) + j)];
                    textBoxes[i, j].BorderStyle = BorderStyle.Fixed3D;
                    textBoxes[i, j].Location = new Point(i * 50 + 25, j * 50 + 25);
                    textBoxes[i, j].Size = new Size(50, 30);
                    textBoxes[i, j].TextAlign = HorizontalAlignment.Center;
                    textBoxes[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    textBoxes[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? Color.Cyan : Color.LightGreen;
                    textBoxes[i, j].TextChanged += new System.EventHandler(this.TextChange);
                }
            }
            showState(level);
            richTextBox2.Text = "";
            //CurrentNode = null;
        }

        private void restart(object sender, EventArgs e)
        {
            createGame();
        }

        private void TextChange(object sender, EventArgs e)
        {
            string res = Array.Find(cellValues, s => s.Equals((sender as TextBox).Text));
            if (res == null)
                (sender as TextBox).Text = "";

        }
  

        private void solveDFS(object sender, EventArgs e)
        {
            Boolean solved = SolveUsing_DFS();
            if (solved)
            {
                
                foreach(var step in solutionPath)
                {
                    for(byte row = 0; row < 9; row++)
                    {
                        for (byte col = 0; col < 9; col++)
                        {
                            richTextBox2.Text += step[row, col] + " ";
                            
                        }
                        richTextBox2.Text += "\n";
                        
                    }
                    richTextBox2.Text += "\n\n";
                }

                MessageBox.Show("Congratulation");
            }
            else
            {
                MessageBox.Show("can't solve");
            }
        }
       
        private Boolean SolveUsing_DFS()
        {
            Stack<Node> DFS_Stack = new Stack<Node>();
            Node InitialState = new Node(level);
            DFS_Stack.Push(InitialState);

            while (DFS_Stack.Count != 0)
            {
                //remove
                CurrentNode = DFS_Stack.Pop();
                
                //check if the state is the  goal state
                if ( isComplete(CurrentNode.State))
                {
                    //show the solution
                    showState(CurrentNode.State);
                    // show solution path
                    while (CurrentNode != null)
                    {
                        solutionPath.Insert(0, CurrentNode.State);
                        CurrentNode = CurrentNode.Parent;
                    }
                    
                    return true;
                }
                //add childrens
                if (CurrentNode.Depth == 100)
                {
                    continue;
                }
                foreach (var child in CurrentNode.AddChildren())
                {
                    DFS_Stack.Push(child);
                }

            }

            return false;
        }


        void showState(int[,] state)
        {
            for (byte row = 0; row < 9; row++)
            {
                for (byte col = 0; col < 9; col++)
                {
                    textBoxes[8 - row, 8 - col].Text = state[row, col].ToString();
                }
            } 
        }
        Boolean isComplete(int[,] state)
        {
            for (byte row = 0; row < 9; row++)
            {
                for (byte col = 0; col < 9; col++)
                {
                    if (state[row, col] == 0)
                        return false;
                }
            }
            // if it is complete
            return true;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
