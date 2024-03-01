using System.Text;

namespace _8_Puzzle_Simulator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new InputForm());
        }

        public static string StateToString(int[][] state)
        {
            string str = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    str += state[i][j].ToString();
                }
            }
            return str;
        }
        //Converts a 2d int array to a string

        public static int[][] StringToState(string str)
        {
            int[][] state = new int[3][];
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                state[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    state[i][j] = int.Parse(str[k].ToString());
                    k++;
                }
            }
            return state;
        }
        //Converts a string to a 2darray

        public static int[][] CopyState(int[][] state)
        {
            int[][] newState = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                newState[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    newState[i][j] = state[i][j];
                }
            }
            return newState;
        }
        //Copies a 2d array

        public static int[][][] GenerateNextStates(int[][] currentState)
        {
            // Find position of empty cell
            int zeroRow = -1;
            int zeroCol = -1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentState[i][j] == 0)
                    {
                        zeroRow = i;
                        zeroCol = j;
                        break;
                    }
                }
                if (zeroRow != -1)
                    break;
            }

            int[][][] nextStates = new int[4][][];

            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            for (int i = 0; i < 4; i++)
            {
                int nextRow = zeroRow + directions[i][0];
                int nextCol = zeroCol + directions[i][1];

                if (nextRow >= 0 && nextRow < 3 && nextCol >= 0 && nextCol < 3)
                {
                    int[][] nextState = CopyState(currentState);
                    // Swap zero with the adjacent cell
                    nextState[zeroRow][zeroCol] = currentState[nextRow][nextCol];
                    nextState[nextRow][nextCol] = 0;
                    nextStates[i] = nextState;
                }
            }
            return nextStates;
        }
        //Generates a array of 2d int arrays of all the possible next states
    }
}