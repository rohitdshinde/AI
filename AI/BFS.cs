using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of vertices:");
        int numVertices = int.Parse(Console.ReadLine());

        List<List<int>> adjacencyList = new List<List<int>>();

        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList.Add(new List<int>());
        }

        Console.WriteLine("Enter the number of edges:");
        int numEdges = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the edges (format: source destination):");
        for (int i = 0; i < numEdges; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int source = int.Parse(edge[0]);
            int destination = int.Parse(edge[1]);
            adjacencyList[source].Add(destination);
        }

        Console.WriteLine("Enter the starting vertex for BFS traversal:");
        int startVertex = int.Parse(Console.ReadLine());

        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        void BFS(int vertex)
        {
            visited.Add(vertex);
            queue.Enqueue(vertex);

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");

                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        Console.WriteLine("\nBreadth First Traversal starting from vertex " + startVertex + ":");
        BFS(startVertex);
    }
}
