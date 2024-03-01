using System;
using System.Collections.Generic;

class Graph
{
    private int V; // Number of vertices
    private List<int>[] adj; // Adjacency list

    // Constructor
    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    // Function to add an edge to the graph
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    // Breadth First Search traversal starting from given vertex
    public void BFS(int s)
    {
        // Mark all the vertices as not visited(By default set as false)
        bool[] visited = new bool[V];

        // Create a queue for BFS
        Queue<int> queue = new Queue<int>();

        // Mark the current node as visited and enqueue it
        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            // Dequeue a vertex from queue and print it
            s = queue.Dequeue();
            Console.Write(s + " ");

            // Get all adjacent vertices of the dequeued vertex s. If an adjacent
            // has not been visited, then mark it visited and enqueue it
            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }

    // Main method to test the BFS traversal
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of vertices in the graph:");
        int numVertices = int.Parse(Console.ReadLine());

        Graph g = new Graph(numVertices);

        Console.WriteLine("Enter the number of edges:");
        int numEdges = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the edges (format: source destination):");
        for (int i = 0; i < numEdges; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int source = int.Parse(edge[0]);
            int destination = int.Parse(edge[1]);
            g.AddEdge(source, destination);
        }

        Console.WriteLine("Enter the starting vertex for BFS traversal:");
        int startVertex = int.Parse(Console.ReadLine());

        Console.WriteLine("Breadth First Traversal starting from vertex " + startVertex + ":");
        g.BFS(startVertex);
    }
}
