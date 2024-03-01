using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Simulator
{
    internal class DFS
    {
        public static int NodeVisited;
        public static int[][][] SolvePuzzle(int[][] initialState, int[][] goalState)
        {
            NodeVisited = 0;
            Stack<int[][]> stack = new Stack<int[][]>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, string> parentMap = new Dictionary<string, string>();
            //Creates a visited set and a directory to map a states parent

            stack.Push(initialState);
            visited.Add(Program.StateToString(initialState));
            //Add the inital state to the stack and add the inital state to visited set
            parentMap[Program.StateToString(initialState)] = null;
            //map the initalstates parent to null

            while (stack.Count > 0)
            {
                int[][] currentState = stack.Pop();
                NodeVisited++;
                //Set current from the top of the stack 

                if (Program.StateToString(currentState) == Program.StateToString(goalState))
                {
                    List<int[][]> path = new List<int[][]>();
                    string state = Program.StateToString(currentState);
                    while (state != null)
                    {
                        path.Add(Program.StringToState(state));
                        state = parentMap[state];
                    }
                    //Reconstuct the path form the goal state to the intial state to a 3d int array
                    path.Reverse();
                    return path.ToArray();
                    //Reverses the array to be the path to the inital state to the goal state then returns it
                }

                int[][][] nextStates = Program.GenerateNextStates(currentState);
                //Generate all possible next states

                foreach (var nextState in nextStates)
                {
                    if (nextState != null)
                    {
                        string nextStateString = Program.StateToString(nextState);
                        if (!visited.Contains(Program.StateToString(nextState)))
                        {
                            stack.Push(nextState);
                            //Add all the possible next states to the stack if not already visited
                            visited.Add(nextStateString);
                            parentMap[nextStateString] = Program.StateToString(currentState);
                            //Add next state to the vistited state and map its parent to the current state
                        }
                    }
                }
            }
            return null;
            //Return null if no solutions are found
        }
    }
}
