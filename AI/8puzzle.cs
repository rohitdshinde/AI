//using System;
//using System.Collections.Generic;

//class EightPuzzleSolver
//{
//    private readonly int[,] goalState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };

//    public void Solve(int[,] initialState)
//    {
//        PriorityQueue<Node> openList = new PriorityQueue<Node>();
//        HashSet<string> closedList = new HashSet<string>();

//        Node initialNode = new Node(initialState, 0, null);
//        openList.Enqueue(initialNode, initialNode.Cost);

//        while (openList.Count > 0)
//        {
//            Node currentNode = openList.Dequeue();

//            if (IsGoalState(currentNode.State))
//            {
//                PrintSolution(currentNode);
//                return;
//            }

//            closedList.Add(GetStateString(currentNode.State));

//            List<Node> nextNodes = GetNextNodes(currentNode);
//            foreach (Node nextNode in nextNodes)
//            {
//                string nextStateString = GetStateString(nextNode.State);
//                if (!closedList.Contains(nextStateString))
//                {
//                    openList.Enqueue(nextNode, nextNode.Cost);
//                }
//            }
//        }

//        Console.WriteLine("No solution found.");
//    }

//    private bool IsGoalState(int[,] state)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                if (state[i, j] != goalState[i, j])
//                {
//                    return false;
//                }
//            }
//        }
//        return true;
//    }

//    private string GetStateString(int[,] state)
//    {
//        string stateString = "";
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                stateString += state[i, j];
//            }
//        }
//        return stateString;
//    }

//    private List<Node> GetNextNodes(Node node)
//    {
//        List<Node> nextNodes = new List<Node>();

//        int[] dx = { 0, 0, 1, -1 };
//        int[] dy = { 1, -1, 0, 0 };

//        for (int i = 0; i < 4; i++)
//        {
//            int newX = node.ZeroX + dx[i];
//            int newY = node.ZeroY + dy[i];

//            if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
//            {
//                int[,] newState = (int[,])node.State.Clone();
//                newState[node.ZeroX, node.ZeroY] = newState[newX, newY];
//                newState[newX, newY] = 0;
//                nextNodes.Add(new Node(newState, node.Cost + 1, node));
//            }
//        }

//        return nextNodes;
//    }

//    private void PrintSolution(Node node)
//    {
//        List<Node> solutionPath = new List<Node>();

//        while (node != null)
//        {
//            solutionPath.Add(node);
//            node = node.Parent;
//        }

//        int step = 0;
//        for (int i = solutionPath.Count - 1; i >= 0; i--)
//        {
//            Console.WriteLine($"Step {step++}:");
//            PrintState(solutionPath[i].State);
//        }
//    }

//    private void PrintState(int[,] state)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                Console.Write(state[i, j] + " ");
//            }
//            Console.WriteLine();
//        }
//        Console.WriteLine();
//    }

//    class Node
//    {
//        public int[,] State { get; }
//        public int Cost { get; }
//        public int ZeroX { get; }
//        public int ZeroY { get; }
//        public Node Parent { get; }

//        public Node(int[,] state, int cost, Node parent)
//        {
//            State = state;
//            Cost = cost;
//            Parent = parent;

//            // Find the position of the empty tile (0)
//            for (int i = 0; i < 3; i++)
//            {
//                for (int j = 0; j < 3; j++)
//                {
//                    if (state[i, j] == 0)
//                    {
//                        ZeroX = i;
//                        ZeroY = j;
//                        return;
//                    }
//                }
//            }
//        }
//    }

//    class PriorityQueue<T>
//    {
//        private SortedDictionary<int, Queue<T>> dict = new SortedDictionary<int, Queue<T>>();

//        public int Count { get; private set; } = 0;

//        public void Enqueue(T item, int priority)
//        {
//            if (!dict.ContainsKey(priority))
//            {
//                dict[priority] = new Queue<T>();
//            }
//            dict[priority].Enqueue(item);
//            Count++;
//        }

//        public T Dequeue()
//        {
//            if (Count == 0)
//            {
//                throw new InvalidOperationException("Queue is empty.");
//            }

//            foreach (var kvp in dict)
//            {
//                if (kvp.Value.Count > 0)
//                {
//                    Count--;
//                    return kvp.Value.Dequeue();
//                }
//            }

//            throw new InvalidOperationException("Queue is empty.");
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        EightPuzzleSolver solver = new EightPuzzleSolver();

//        int[,] initialState = GetInputState("Enter the initial state of the puzzle:");
//        int[,] finalState = GetInputState("Enter the final state of the puzzle:");

//        Console.WriteLine("Initial State:");
//        PrintState(initialState);

//        Console.WriteLine("Final State:");
//        PrintState(finalState);

//        solver.Solve(initialState);
//    }

//    static int[,] GetInputState(string prompt)
//    {
//        Console.WriteLine(prompt);
//        int[,] state = new int[3, 3];
//        for (int i = 0; i < 3; i++)
//        {
//            string[] input = Console.ReadLine().Split(' ');
//            for (int j = 0; j < 3; j++)
//            {
//                state[i, j] = int.Parse(input[j]);
//            }
//        }
//        return state;
//    }

//    static void PrintState(int[,] state)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                Console.Write(state[i, j] + " ");
//            }
//            Console.WriteLine();
//        }
//        Console.WriteLine();
//    }
//}
