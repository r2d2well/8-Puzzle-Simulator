using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Puzzle_Simulator
{
    public partial class InputForm : Form
    {
        TextBox[,] textBoxes = new TextBox[3, 3];
        public InputForm()
        {
            InitializeComponent();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    TextBox textBox = new TextBox();
                    textBox.MaxLength = 1;
                    textBox.Font = new Font("Segoe UI", 18);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.ForeColor = Color.Black;
                    textBox.Size = new Size(36, 43);
                    textBox.Location = new Point(350 + (36 * x), 100 + (43 * y));
                    textBox.TextChanged += onTextChange;
                    textBoxes[y, x] = textBox;
                    Controls.Add(textBox);
                    //Creates the 9 textboxs for the input with appopriate proporties
                }
            }
        }
        private bool checkRepeates(string text)
        {
            int counter = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (textBoxes[y, x].Text == text)
                    {
                        counter++;
                    }
                    if (counter > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Method that returns true if there are already a instance of the number in another textbox

        private void onTextChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                byte temp;
                if ((textBox.Text != "") && (textBox.Text != " "))
                {
                    temp = Byte.Parse(textBox.Text);
                }
                else
                {
                    temp = 0;
                }
                if (temp > 8)
                {
                    throw new FormatException();
                }
                if (checkRepeates(textBox.Text))
                {
                    throw new FormatException();
                    //If user enters an invalid or repeated input throw an error
                }
                textBox.ForeColor = Color.Black;
                //Change text color to black if not already
                if (checkAcceptace())
                {
                    AcceptButton.Visible = true;
                    //If checkAcceptance is true then make accept button visable
                }
                else
                {
                    AcceptButton.Visible = false;
                    //else make it invisible
                }
            }
            catch (FormatException)
            {
                textBox.ForeColor = Color.Red;
                AcceptButton.Visible = false;
                //On error change the text color to red
            }
        }

        private bool checkAcceptace()
        {
            bool[] boolArray = new bool[9];
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (textBoxes[y, x].ForeColor == Color.Black)
                    {
                        byte index = 0;
                        if ((textBoxes[y, x].Text != "") && (textBoxes[y, x].Text != " "))
                        {
                            index = Byte.Parse(textBoxes[y, x].Text);
                        }
                        boolArray[index] = true;
                    }
                }
            }
            for (int x = 0; x < 9; x++)
            {
                if (boolArray[x] == false)
                {
                    return false;
                }
            }
            return true;
        }
        //If all the apporprate inputs are valid return true else return false

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int[][] goal = new int[3][];
            for (int y = 0; y < 3; y++)
            {
                goal[y] = new int[3];
                for (int x = 0; x < 3; x++)
                {
                    if ((textBoxes[y, x].Text != "") && (textBoxes[y, x].Text != " "))
                    {
                        goal[y][x] = int.Parse(textBoxes[y, x].Text);
                    }
                }
            }
            MainForm mainForm = new MainForm(goal);
            mainForm.ShowDialog();
            //Create a new MainForm with the input goal state and show it
        }

        public static int[][] setRandomGoal()
        {
            int[][] result = new int[3][];
            for (int temp = 0; temp < 3; temp++)
            {
                result[temp] = new int[3];
            }
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                int index = random.Next(9);
                while (result[(index / 3)][(index % 3)] != 0)
                {
                    if (index == 8)
                    {
                        index = 0;
                    }
                    else
                    {
                        index++;
                    }
                }
                result[(index / 3)][(index % 3)] = i + 1;
            }
            return result;
        }
        //Creates a return a random goal state

        private void RandomButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(setRandomGoal());
            mainForm.ShowDialog();
            //Creates a new MainForm with random goal state
        }
    }
}