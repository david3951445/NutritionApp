namespace NutritionApp.Services;

public class Utils
{
    /// <summary>
    /// Generates uniformly distributed points in [0,1]^d with a minimum distance tolerance.
    /// </summary>
    /// <param name="pointCount">Number of points to generate.</param>
    /// <param name="dimension">Dimension of the hypercube (d).</param>
    /// <param name="minDistance">Optional: Minimum allowed distance between points (default is 0.0, meaning no restriction).</param>
    /// <param name="maxRetries">Optional: Maximum retries to find a valid point (default is 10).</param>
    /// <returns>A list of points, where each point is an array of doubles with length = dimension.</returns>
    public static List<double[]> GenerateRandomPointsWithTolerance(
        int pointCount,
        int dimension,
        double minDistance = 0.0,
        int maxRetries = 3)
    {
        var random = new Random();
        var data = new List<double[]>();

        while (data.Count < pointCount)
        {
            double[] lastCandidatePoint = null;

            for (int retry = 0; retry < maxRetries; retry++)
            {
                // Generate a random point in [0,1]^d
                var candidatePoint = new double[dimension];
                for (int d = 0; d < dimension; d++)
                {
                    candidatePoint[d] = random.NextDouble();
                }

                lastCandidatePoint = candidatePoint;

                // Check if this point satisfies the minimum distance condition
                if (minDistance == 0.0 ||
                    data.All(existingPoint => CalculateDistance(existingPoint, candidatePoint) >= minDistance))
                {
                    data.Add(candidatePoint);
                    break;
                }

                // If this is the last retry, accept the last candidate point
                if (retry == maxRetries - 1)
                {
                    Console.WriteLine("Retry limit reached. Adding the last candidate point.");
                    data.Add(lastCandidatePoint);
                }
            }
        }

        return data;
    }

    /// <summary>
    /// Calculates the Euclidean distance between two points in d-dimensional space.
    /// </summary>
    private static double CalculateDistance(double[] point1, double[] point2)
    {
        double sum = 0;
        for (int i = 0; i < point1.Length; i++)
        {
            sum += Math.Pow(point1[i] - point2[i], 2);
        }
        return Math.Sqrt(sum);
    }
}
