namespace NutritionApp.Services;

public class Utils
{
    public static List<string> GenerateUniformColorsInRGB(int count)
    {
        // Define the six colors: Red, Yellow, Green, Cyan, Blue, Magenta
        int[][] colors = [
            [255, 0, 0], // Red
            [255, 255, 0], // Yellow
            [0, 255, 0], // Green
            [0, 255, 255], // Cyan
            [0, 0, 255], // Blue
            [255, 0, 255] // Magenta
        ];

        List<string> colorList = [];

        // Calculate the color transition based on the count
        for (int i = 0; i < count; i++)
        {
            double percentage = (double)i / count;

            // Determine the color segment and transition percentage
            int segmentIndex = (int)(percentage * colors.Length);
            segmentIndex = segmentIndex == colors.Length ? 0 : segmentIndex; // Ensure cyclic transition
            double segmentPercentage = (percentage * colors.Length) - segmentIndex;

            // Interpolate between the current and next color
            int[] startColor = colors[segmentIndex];
            int[] endColor = colors[(segmentIndex + 1) % colors.Length];

            // Calculate the interpolated color
            int[] interpolatedColor = new int[3];
            for (int j = 0; j < 3; j++)
            {
                interpolatedColor[j] = (int)(startColor[j] + (endColor[j] - startColor[j]) * segmentPercentage);
            }

            // Add the resulting color to the list
            colorList.Add($"rgba({interpolatedColor[0]},{interpolatedColor[1]},{interpolatedColor[2]}, 0.7)");
        }

        return colorList;
    }

    public static List<string> GenerateRandomColors(int count)
    {
        return GenerateRandomPointsWithTolerance(count, 3, 0.1)
        .Select(point => $"rgba({point[0] * 256},{point[1] * 256},{point[2] * 256}, 0.7)")
        .ToList();
    }

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
