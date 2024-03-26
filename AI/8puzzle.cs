//using System;
//using System.Collections.Generic;

//namespace EightPuzzleSolver
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Enter the initial state (3x3 matrix, use 0 to represent the blank space):");
//            int[,] initial = GetStateFromUser();

//            Console.WriteLine("Enter the goal state (3x3 matrix, use 0 to represent the blank space):");
//            int[,] goal = GetStateFromUser();

//            EightPuzzleSolver solver = new EightPuzzleSolver(initial, goal);
//            List<int[,]> solution = solver.Solve();

//            if (solution != null)
//            {
//                Console.WriteLine("Solution found:");
//                foreach (var state in solution)
//                {
//                    PrintState(state);
//                    Console.WriteLine();
//                }
//            }
//            else
//            {
//                Console.WriteLine("No solution found!");
//            }
//        }

//        static int[,] GetStateFromUser()
//        {
//            int[,] state = new int[3, 3];

//            for (int i = 0; i < 3; i++)
//            {
//                string[] values = Console.ReadLine().Split(' ');
//                for (int j = 0; j < 3; j++)
//                {
//                    state[i, j] = int.Parse(values[j]);
//                }
//            }

//            return state;
//        }

//        static void PrintState(int[,] state)
//        {
//            for (int i = 0; i < 3; i++)
//            {
//                for (int j = 0; j < 3; j++)
//                {
//                    Console.Write(state[i, j] + " ");
//                }
//                Console.WriteLine();
//            }
//        }
//    }

//    class EightPuzzleSolver
//    {
//        private int[,] initial;
//        private int[,] goal;

//        public EightPuzzleSolver(int[,] initial, int[,] goal)
//        {
//            this.initial = initial;
//            this.goal = goal;
//        }

//        public List<int[,]> Solve()
//        {
//            // Implement A* algorithm here
//            throw new NotImplementedException();
//        }
//    }
//}
