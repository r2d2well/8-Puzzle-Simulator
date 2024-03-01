using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _8_Puzzle_Simulator
{
    public partial class OutputForm : Form
    {
        int[][][] array;
        Label[,] labelArray = new Label[3, 3];
        int current;
        public OutputForm(int searchType, int[][] currentState, int[][] goalState)
        {
            current = 0;
            Stopwatch stopwatch = new Stopwatch();
            InitializeComponent();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Label label = new Label();
                    label.BackColor = Color.White;
                    label.Font = new Font("Segoe UI", 18);
                    label.Text = " ";
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Size = new Size(36, 43);
                    label.Location = new Point(350 + (36 * x), 100 + (43 * y));
                    labelArray[y, x] = label;
                    Controls.Add(label);
                    //Creates the 9 labels with apporiate properties
                }
            }
            switch (searchType)
            {
                case 1:
                    SearchLabel.Text = "Depth-First Search (DFS)";
                    stopwatch.Start();
                    array = DFS.SolvePuzzle(currentState, goalState);
                    stopwatch.Stop();
                    //Calls the DFS to solve the puzzle and take the elapsed time the algorithm took
                    VisitedLabel.Text = "Nodes Visited: " + DFS.NodeVisited;
                    //Displays the nodes vistited in the algorithm
                    break;

                case 2:
                    SearchLabel.Text = "Uniform-Cost Search (UCS)";
                    stopwatch.Start();
                    array = UCS.SolvePuzzle(currentState, goalState);
                    stopwatch.Stop();
                    //Calls the UCS to solve the puzzle and take the elapsed time the algorithm took
                    VisitedLabel.Text = "Nodes Visited: " + UCS.NodeVisited;
                    //Displays the nodes vistited in the algorithm
                    break;

                case 3:
                    SearchLabel.Text = "Best-First Search (BCS)";
                    stopwatch.Start();
                    array = BFS.SolvePuzzle(currentState, goalState);
                    stopwatch.Stop();
                    //Calls the BFS to solve the puzzle and take the elapsed time the algorithm took
                    VisitedLabel.Text = "Nodes Visited: " + BFS.NodeVisited;
                    //Displays the nodes vistited in the algorithm
                    break;

                case 4:
                    SearchLabel.Text = "A* Algorithm";
                    stopwatch.Start();
                    array = AStar.SolvePuzzle(currentState, goalState);
                    stopwatch.Stop();
                    //Calls the A* to solve the puzzle and take the elapsed time the algorithm took
                    VisitedLabel.Text = "Nodes Visited: " + AStar.NodeVisited;
                    //Displays the nodes vistited in the algorithm
                    break;
            }
            SearchLabel.Left = (this.Width - SearchLabel.Width) / 2;
            TimeSpan ts = stopwatch.Elapsed;
            TimeLabel.Text = "Time to Complete: " + String.Format("{0:N4}", ts.TotalSeconds);
            //Prints out the time took to complete the algorithm
            setLabels(array[current]);
            //Sets the label with the starting position
            LengthLabel.Text = "Path Length: " + array.Length;
            NodeLabel.Text = "Node Number: 1";
        }

        private void setLabels(int[][] array)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (array[y][x] == 0)
                    {
                        labelArray[y, x].Text = " ";
                    }
                    else
                    {
                        labelArray[y, x].Text = array[y][x].ToString();
                    }
                }
            }
        }
        //Sets the 9 labels text to equal the numbers in the given 2d int array
        private void nextButton_Click(object sender, EventArgs e)
        {
            current++;
            setLabels(array[current]);
            NodeLabel.Text = "Node Number: " + (current + 1);
            if (current == array.Length - 1)
            {
                nextButton.Visible = false;
            }
            //Updates the labels to displayed the next node along the path
        }
    }
}
