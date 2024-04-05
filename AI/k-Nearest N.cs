//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Training data
//        var trainingData = new Dictionary<double[], string>
//        {
//            { new double[] { 1, 2 }, "A" },
//            { new double[] { 2, 3 }, "A" },
//            { new double[] { 3, 3 }, "A" },
//            { new double[] { 2, 1 }, "B" },
//            { new double[] { 3, 2 }, "B" },
//            { new double[] { 4, 2 }, "B" }
//        };

//        // Input for test point
//        Console.WriteLine("Enter the coordinates for the test point (separate x and y values by space):");
//        double[] testPoint = Console.ReadLine().Split().Select(double.Parse).ToArray();

//        // k value
//        int k = 3;

//        // Find k nearest neighbors
//        var nearestNeighbors = FindNearestNeighbors(trainingData, testPoint, k);

//        // Predict class based on majority vote
//        string predictedClass = PredictClass(nearestNeighbors);

//        // Output
//        Console.WriteLine($"Predicted class for test point: {predictedClass}");
//    }

//    static List<KeyValuePair<double[], string>> FindNearestNeighbors(Dictionary<double[], string> trainingData, double[] testPoint, int k)
//    {
//        var distances = new List<KeyValuePair<double, double[]>>();
//        foreach (var point in trainingData.Keys)
//        {
//            double distance = CalculateEuclideanDistance(point, testPoint);
//            distances.Add(new KeyValuePair<double, double[]>(distance, point));
//        }

//        distances.Sort((x, y) => x.Key.CompareTo(y.Key));

//        var nearestNeighbors = new List<KeyValuePair<double[], string>>();
//        for (int i = 0; i < k; i++)
//        {
//            nearestNeighbors.Add(new KeyValuePair<double[], string>(distances[i].Value, trainingData[distances[i].Value]));
//        }

//        return nearestNeighbors;
//    }

//    static double CalculateEuclideanDistance(double[] point1, double[] point2)
//    {
//        double sum = 0;
//        for (int i = 0; i < point1.Length; i++)
//        {
//            sum += Math.Pow(point1[i] - point2[i], 2);
//        }
//        return Math.Sqrt(sum);
//    }

//    static string PredictClass(List<KeyValuePair<double[], string>> nearestNeighbors)
//    {
//        var classCounts = new Dictionary<string, int>();
//        foreach (var neighbor in nearestNeighbors)
//        {
//            string className = neighbor.Value;
//            if (classCounts.ContainsKey(className))
//            {
//                classCounts[className]++;
//            }
//            else
//            {
//                classCounts[className] = 1;
//            }
//        }

//        return classCounts.OrderByDescending(x => x.Value).First().Key;
//    }
//}

//// output 2.5 2.5