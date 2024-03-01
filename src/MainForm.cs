namespace _8_Puzzle_Simulator
{
    public partial class MainForm : Form
    {
        int x, y;
        Label[,] labelArray;
        int[][] data;
        int[][] goal;
        public MainForm(int[][] goal)
        {
            x = -1;
            y = -1;
            this.goal = goal;
            data = shuffleNumbers(goal);
            InitializeComponent();
            labelArray = new Label[3, 3];
            createLabel();
            createGoalLabel();
            //Sets varables to default value and given goal
        }

        private void createLabel()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Label label = new Label();
                    label.BackColor = Color.White;
                    label.Font = new Font("Segoe UI", 18);
                    if (data[y][x] == 0)
                    {
                        label.Text = " ";
                    }
                    else
                    {
                        label.Text = data[y][x].ToString();
                    }
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Size = new Size(36, 43);
                    label.Location = new Point(350 + (36 * x), 50 + (43 * y));
                    label.Click += label_Click;
                    labelArray[y, x] = label;
                    Controls.Add(label);
                    //Creates the 9 labels with appropriate varables and text
                }
            }
        }

        private void createGoalLabel()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Label label = new Label();
                    label.BackColor = Color.White;
                    label.Font = new Font("Segoe UI", 18);
                    if (goal[y][x] == 0)
                    {
                        label.Text = " ";
                    }
                    else
                    {
                        label.Text = goal[y][x].ToString();
                    }
                    label.BorderStyle = BorderStyle.FixedSingle;
                    label.Size = new Size(36, 43);
                    label.Location = new Point(50 + (36 * x), 50 + (43 * y));
                    Controls.Add(label);
                    //Creates the 9 goal labels with appropriate varables and text
                }
            }
        }

        private int[][] shuffleNumbers(int[][] inputArray)
        {
            int[][] array = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                array[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    array[i][j] = inputArray[i][j];
                }
            }
            int blankX = 0;
            int blankY = 0;
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i][j] == 0)
                    {
                        blankY = i;
                        blankX = j;
                        //Finds the x and y of the blank space
                    }
                }
            }
            for (int temp = 0; temp < 1000; temp++)
            {
                //Repeates 1000 times to ensure the array is properly shuffled
                bool[] moves = new bool[4];
                if (blankY != 0) { moves[0] = true; }
                if (blankY != 2) { moves[1] = true; }
                if (blankX != 0) { moves[2] = true; }
                if (blankX != 2) { moves[3] = true; }
                int index = random.Next(4);
                while (moves[index] == false)
                {
                    if (index == 3)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                //Find all possible moves for the blank and randomly chooses one
                switch (index)
                {
                    case 0:
                        array[blankY][blankX] = array[blankY - 1][blankX];
                        array[blankY - 1][blankX] = 0;
                        blankY--;
                        //Moves the blank space up
                        break;

                    case 1:
                        array[blankY][blankX] = array[blankY + 1][blankX];
                        array[blankY + 1][blankX] = 0;
                        blankY++;
                        //Moves the blank space down
                        break;

                    case 2:
                        array[blankY][blankX] = array[blankY][blankX - 1];
                        array[blankY][blankX - 1] = 0;
                        blankX--;
                        //Moves the blank space left
                        break;

                    case 3:
                        array[blankY][blankX] = array[blankY][blankX + 1];
                        array[blankY][blankX + 1] = 0;
                        blankX++;
                        //Moves the blank space right
                        break;
                }
            }
            return array;
            //returns the newly shuffle array
        }

        private void setTexts()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (data[i][j] != 0)
                    {
                        labelArray[i, j].Text = data[i][j].ToString();
                    }
                    else
                    {
                        labelArray[i, j].Text = " ";
                    }
                }
            }
        }
        //Sets the text in the 9 main labels

        private void label_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = Color.Black;
            label.ForeColor = Color.White;
            //Sets the labels backcolor to black and text color to white to indicate it is selected
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (labelArray[i, j] == label)
                    {
                        this.x = j;
                        this.y = i;
                        //Sets x and y to the current labels position
                    }
                    else
                    {
                        labelArray[i, j].BackColor = Color.White;
                        labelArray[i, j].ForeColor = Color.Black;
                        //Sets all other labels to have black backcolor and white text color
                    }
                }
            }
            if (hasMove())
            {
                MoveButton.Visible = true;
                //If the selected label has a move make the movebutton visable
            }
            else
            {
                MoveButton.Visible = false;
                //Else make it non visable
            }
        }

        private void form_Click(object sender, EventArgs e)
        {
            x = -1;
            y = -1;
            MoveButton.Visible = false;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    labelArray[y, x].BackColor = Color.White;
                    labelArray[y, x].ForeColor = Color.Black;
                }
            }
        }
        //Deselects all the text if any are selected

        private bool hasMoveUp()
        {
            if (y == 0)
            {
                return false;
            }
            else
            {
                return (data[y - 1][x] == 0);
            }
        }
        //Return true if current selected label has a move up

        private bool hasMoveDown()
        {
            if (y == 2)
            {
                return false;
            }
            else
            {
                return (data[y + 1][x] == 0);
            }
        }
        //Return true if current selected label has a move down

        private bool hasMoveLeft()
        {
            if (x == 0)
            {
                return false;
            }
            else
            {
                return (data[y][x - 1] == 0);
            }
        }
        //Return true if current selected label has a move left

        private bool hasMoveRight()
        {
            if (x == 2)
            {
                return false;
            }
            else
            {
                return (data[y][x + 1] == 0);
            }
        }
        //Return true if current selected label has a move right

        private bool hasMove()
        {
            return (hasMoveLeft() || hasMoveRight() || hasMoveUp() || hasMoveDown());
        }
        //Returns true if current selected label has any moves avaliable

        private void moveUp()
        {
            data[y - 1][x] = data[y][x];
            data[y][x] = 0;
        }
        //Moves selected label up

        private void moveDown()
        {
            data[y + 1][x] = data[y][x];
            data[y][x] = 0;
        }
        //Moves selected label up

        private void moveLeft()
        {
            data[y][x - 1] = data[y][x];
            data[y][x] = 0;
        }
        //Moves selected label up

        private void moveRight()
        {
            data[y][x + 1] = data[y][x];
            data[y][x] = 0;
        }
        //Moves selected label up

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if (hasMoveUp())
            {
                moveUp();
            }
            if (hasMoveDown())
            {
                moveDown();
            }
            if (hasMoveLeft())
            {
                moveLeft();
            }
            if (hasMoveRight())
            {
                moveRight();
            }
            setTexts();
            MoveButton.Visible = false;
            if (GameOver())
            {
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.ShowDialog();
                this.Close();
                //If the player reaches the goal state then the game ends
            }
        }
        //Moves current selected label

        private bool GameOver()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (data[i][j] != goal[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //returns true if the current state equals the goal state

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((x == -1) || (y == -1))
            {
                return;
                //If no selected then return
            }
            switch (e.KeyChar)
            {
                case 'w':
                    labelArray[y, x].ForeColor = Color.Black;
                    labelArray[y, x].BackColor = Color.White;
                    if (y == 0)
                    {
                        y = 2;
                    }
                    else
                    {
                        y--;
                    }
                    labelArray[y, x].ForeColor = Color.White;
                    labelArray[y, x].BackColor = Color.Black;
                    if (hasMove())
                    {
                        MoveButton.Visible = true;
                    }
                    else
                    {
                        MoveButton.Visible = false;
                    }
                    break;
                    //If w is while a label is selected then move selected up if possible

                case 's':
                    labelArray[y, x].ForeColor = Color.Black;
                    labelArray[y, x].BackColor = Color.White;
                    if (y == 2)
                    {
                        y = 0;
                    }
                    else
                    {
                        y++;
                    }
                    labelArray[y, x].ForeColor = Color.White;
                    labelArray[y, x].BackColor = Color.Black;
                    if (hasMove())
                    {
                        MoveButton.Visible = true;
                    }
                    else
                    {
                        MoveButton.Visible = false;
                    }
                    break;
                    //If s is while a label is selected then move selected down if possible

                case 'a':
                    labelArray[y, x].ForeColor = Color.Black;
                    labelArray[y, x].BackColor = Color.White;
                    if (x == 0)
                    {
                        x = 2;
                    }
                    else
                    {
                        x--;
                    }
                    labelArray[y, x].ForeColor = Color.White;
                    labelArray[y, x].BackColor = Color.Black;
                    if (hasMove())
                    {
                        MoveButton.Visible = true;
                    }
                    else
                    {
                        MoveButton.Visible = false;
                    }
                    break;
                    //If a is while a label is selected then move selected left if possible

                case 'd':
                    labelArray[y, x].ForeColor = Color.Black;
                    labelArray[y, x].BackColor = Color.White;
                    if (x == 2)
                    {
                        x = 0;
                    }
                    else
                    {
                        x++;
                    }
                    labelArray[y, x].ForeColor = Color.White;
                    labelArray[y, x].BackColor = Color.Black;
                    if (hasMove())
                    {
                        MoveButton.Visible = true;
                    }
                    else
                    {
                        MoveButton.Visible = false;
                    }
                    break;
                    //If d is while a label is selected then move selected right if possible
            }
        }
        //Event occurs whenever a key is pressed

        private void SolveButton_Click(object sender, EventArgs e)
        {
            OutputForm outputForm = new OutputForm(comboBox.SelectedIndex, data, goal);
            outputForm.ShowDialog();
            //Open a new OutputForm with the selected index, current state, and goal state
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                SolveButton.Visible = false;
                //If solveButton selected index is 0 then make the solve button visable
            }
            else
            {
                SolveButton.Visible = true;
                //else make it invisible
            }
        }
    }
}