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

    // Depth First Search traversal starting from given vertex
    public void DFSUtil(int v, bool[] visited)
    {
        // Mark the current node as visited and print it
        visited[v] = true;
        Console.Write(v + " ");

        // Recur for all the vertices adjacent to this vertex
        foreach (int i in adj[v])
        {
            if (!visited[i])
                DFSUtil(i, visited);
        }
    }

    // Depth First Search traversal
    public void DFS(int v)
    {
        // Mark all the vertices as not visited(By default set as false)
        bool[] visited = new bool[V];

        // Call the recursive helper function to print DFS traversal
        DFSUtil(v, visited);
    }

    // Main method to test the DFS traversal
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

        Console.WriteLine("Enter the starting vertex for DFS traversal:");
        int startVertex = int.Parse(Console.ReadLine());

        Console.WriteLine("Depth First Traversal starting from vertex " + startVertex + ":");
        g.DFS(startVertex);
    }
}
