﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle_Simulator
{
    internal class AStar
    {
        public static int NodeVisited;
        public static int[][][] SolvePuzzle(int[][] initialState, int[][] goalState)
        {
            NodeVisited = 0;
            PriorityQueue<int[][], int> queue = new PriorityQueue<int[][], int>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, string> parentMap = new Dictionary<string, string>();
            //Creates a visited set and a directory to map a states parent
            Dictionary<int[][], int> costs = new Dictionary<int[][], int>();
            //Creates a directory to map a states cost

            queue.Enqueue(initialState, Heuristic(initialState, goalState));
            visited.Add(Program.StateToString(initialState));
            //Add the inital state to the queue and add the inital state to visited set
            parentMap[Program.StateToString(initialState)] = null;
            costs[initialState] = 0;
            //map the initalstates parent to null, and its cost to 0

            while (queue.Count > 0)
            {
                int[][] currentState = queue.Dequeue();
                NodeVisited++;
                //Set current from the front of the piorityqueue 

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
                        int newCost = costs[currentState] + 1;
                        //Sets the new cost varable to be 1 more then the cost of the current state
                        string nextStateString = Program.StateToString(nextState);
                        if (!visited.Contains(nextStateString))
                        {
                            int value = (Heuristic(nextState, goalState) + newCost);
                            //Calculate the value as the result of the heuristic function plus the newcost
                            queue.Enqueue(nextState, value);
                            //Add all the possible next states to the queue if not already visited with the calculated value
                            visited.Add(nextStateString);
                            parentMap[nextStateString] = Program.StateToString(currentState);
                            costs[nextState] = newCost;
                            //Add next state to the vistited state and map its parent to the current state and sets its cost
                        }
                    }
                }
            }
            return null;
            //Return null if no solutions are found
        }

        public static int Heuristic(int[][] puzzle, int[][] goalState)
        {
            int heuristicValue = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int value = puzzle[i][j];
                    if (value != 0)
                    {
                        //For each space except the blank space
                        int[] goalPosition = FindValuePosition(goalState, value);
                        heuristicValue += Math.Abs(goalPosition[0] - i) + Math.Abs(goalPosition[1] - j);
                        //Returns the absolute value of how far tile is form where it should be
                    }
                }
            }
            return heuristicValue;
            //Returns the total value
        }
        public static int[] FindValuePosition(int[][] state, int value)
        {
            int size = state.GetLength(0);
            int[] position = new int[2];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (state[i][j] == value)
                    {
                        position[0] = i;
                        position[1] = j;
                        return position;
                    }
                }
            }
            return null;
        }
        //Returns the x and y positon of a tile
    }
}