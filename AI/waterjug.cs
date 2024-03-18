using System;

class WaterJugProblem
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the capacity of jug 1:");
        int jug1Capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the capacity of jug 2:");
        int jug2Capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the target amount:");
        int targetAmount = int.Parse(Console.ReadLine());

        Console.WriteLine("\nSteps to measure out the target amount:");

        if (WaterJugSolver(jug1Capacity, jug2Capacity, targetAmount))
            Console.WriteLine("Target amount can be achieved!");
        else
            Console.WriteLine("Target amount cannot be achieved with the given jug capacities.");
    }

    static bool WaterJugSolver(int jug1Capacity, int jug2Capacity, int targetAmount)
    {
        if (targetAmount > Math.Max(jug1Capacity, jug2Capacity))
            return false;

        int jug1 = 0, jug2 = 0;

        while (true)
        {
            Console.WriteLine($"({jug1}, {jug2})");

            if (jug1 == targetAmount || jug2 == targetAmount)
                return true;

            if (jug1 == 0)
                jug1 = jug1Capacity;
            else if (jug2 == jug2Capacity)
                jug2 = 0;
            else
            {
                int amountToPour = Math.Min(jug1, jug2Capacity - jug2);
                jug1 -= amountToPour;
                jug2 += amountToPour;
            }
        }
    }
}
