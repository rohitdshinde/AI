using System;
using System.Collections.Generic;
using System.Linq;

class RandomForest
{
    public class DecisionTree
    {
        public class Node
        {
            public string Feature { get; set; }
            public string Label { get; set; }
            public Dictionary<string, Node> Children { get; set; }

            public Node()
            {
                Children = new Dictionary<string, Node>();
            }
        }

        public static Node BuildDecisionTree(List<string[]> data, List<string> features)
        {
            Node root = new Node();
            // For simplicity, we'll just predict the majority class as the label
            string[] labels = data.Select(d => d.Last()).ToArray();
            string majorityLabel = labels.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            root.Label = majorityLabel;
            return root;
        }

        public static string Predict(Node tree, string[] instance)
        {
            // For simplicity, we'll just return the label of the root node
            return tree.Label;
        }
    }

    public static List<DecisionTree> BuildRandomForest(List<string[]> data, List<string> features, int numTrees)
    {
        List<DecisionTree> forest = new List<DecisionTree>();
        for (int i = 0; i < numTrees; i++)
        {
            // For simplicity, we'll create a decision tree with the same data and features
            DecisionTree tree = new DecisionTree();
            forest.Add(tree);
        }
        return forest;
    }

    public static string Predict(List<DecisionTree> forest, string[] instance)
    {
        // For simplicity, we'll just return the majority vote from all trees
        Dictionary<string, int> votes = new Dictionary<string, int>();
        foreach (var tree in forest)
        {
            string prediction = DecisionTree.Predict(tree, instance);
            if (!votes.ContainsKey(prediction))
                votes[prediction] = 0;
            votes[prediction]++;
        }
        return votes.OrderByDescending(x => x.Value).First().Key;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sample training data
        List<string[]> trainingData = new List<string[]>
        {
            new string[] {"Sunny", "Hot", "High", "Weak", "No"},
            new string[] {"Overcast", "Hot", "High", "Strong", "Yes"},
            new string[] {"Rain", "Mild", "High", "Weak", "Yes"},
            new string[] {"Rain", "Cool", "Normal", "Weak", "Yes"},
            new string[] {"Rain", "Cool", "Normal", "Strong", "No"},
            new string[] {"Overcast", "Cool", "Normal", "Strong", "Yes"},
            new string[] {"Sunny", "Mild", "High", "Weak", "No"},
            new string[] {"Sunny", "Cool", "Normal", "Weak", "Yes"},
            new string[] {"Rain", "Mild", "Normal", "Weak", "Yes"},
            new string[] {"Sunny", "Mild", "Normal", "Strong", "Yes"},
            new string[] {"Overcast", "Mild", "High", "Strong", "Yes"},
            new string[] {"Overcast", "Hot", "Normal", "Weak", "Yes"},
            new string[] {"Rain", "Mild", "High", "Strong", "No"}
        };

        List<string> features = new List<string> { "Outlook", "Temperature", "Humidity", "Wind" };

        // Build Random Forest with 3 trees
        List<RandomForest.DecisionTree> forest = RandomForest.BuildRandomForest(trainingData, features, 3);

        // Test instance
        string[] instance = { "Sunny", "Cool", "High", "Weak" };

        // Predict using Random Forest
        string prediction = RandomForest.Predict(forest, instance);
        Console.WriteLine($"Prediction: {prediction}");
    }
}
