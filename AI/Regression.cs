using System;
using System.Diagnostics.Metrics;

class LinearRegressionProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Linear Regression Example");

        // Get the number of data points from the user
        Console.Write("Enter the number of data points: ");
        int numDataPoints = int.Parse(Console.ReadLine());

        // Initialize arrays to store the data points
        double[] xValues = new double[numDataPoints];
        double[] yValues = new double[numDataPoints];

        // Input data points from the user
        for (int i = 0; i < numDataPoints; i++)
        {
            Console.Write($"Enter x value for data point {i + 1}: ");
            xValues[i] = double.Parse(Console.ReadLine());

            Console.Write($"Enter y value for data point {i + 1}: ");
            yValues[i] = double.Parse(Console.ReadLine());
        }

        // Perform linear regression
        double slope, intercept;
        CalculateLinearRegression(xValues, yValues, out slope, out intercept);

        // Output the regression equation
        Console.WriteLine($"Regression Equation: y = {slope}x + {intercept}");

        // Predict y values based on the regression equation
        Console.WriteLine("Predicted y values:");
        for (int i = 0; i < numDataPoints; i++)
        {
            double predictedY = slope * xValues[i] + intercept;
            Console.WriteLine($"Predicted y for x={xValues[i]}: {predictedY}");
        }
    }

    static void CalculateLinearRegression(double[] xValues, double[] yValues, out double slope, out double intercept)
    {
        double sumX = 0, sumY = 0, sumXY = 0, sumXX = 0;
        int n = xValues.Length;

        for (int i = 0; i < n; i++)
        {
            sumX += xValues[i];
            sumY += yValues[i];
            sumXY += xValues[i] * yValues[i];
            sumXX += xValues[i] * xValues[i];
        }

        slope = (n * sumXY - sumX * sumY) / (n * sumXX - sumX * sumX);
        intercept = (sumY - slope * sumX) / n;
    }
}





//output format

//Linear Regression Example
//Enter the number of data points: 3
//Enter x value for data point 1: 1
//Enter y value for data point 1: 2
//Enter x value for data point 2: 2
//Enter y value for data point 2: 3
//Enter x value for data point 3: 3
//Enter y value for data point 3: 4
//Regression Equation: y = 1x + 1
//Predicted y values:
//Predicted y for x=1: 2
//Predicted y for x=2: 3
//Predicted y for x=3: 4
