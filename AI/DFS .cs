//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Enter the number of vertices:");
//        int numVertices = int.Parse(Console.ReadLine());

//        List<List<int>> adjacencyList = new List<List<int>>();

//        for (int i = 0; i < numVertices; i++)
//        {
//            adjacencyList.Add(new List<int>());
//        }

//        Console.WriteLine("Enter the number of edges:");
//        int numEdges = int.Parse(Console.ReadLine());

//        Console.WriteLine("Enter the edges (format: source destination):");
//        for (int i = 0; i < numEdges; i++)
//        {
//            string[] edge = Console.ReadLine().Split();
//            int source = int.Parse(edge[0]);
//            int destination = int.Parse(edge[1]);
//            adjacencyList[source].Add(destination);
//        }

//        Console.WriteLine("Enter the starting vertex for DFS traversal:");
//        int startVertex = int.Parse(Console.ReadLine());

//        HashSet<int> visited = new HashSet<int>();

//        void DFS(int vertex)
//        {
//            visited.Add(vertex);
//            Console.Write(vertex + " ");

//            foreach (int neighbor in adjacencyList[vertex])
//            {
//                if (!visited.Contains(neighbor))
//                    DFS(neighbor);
//            }
//        }

//        Console.WriteLine("\nDepth First Traversal starting from vertex " + startVertex + ":");
//        DFS(startVertex);
//    }
//}
