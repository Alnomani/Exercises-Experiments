internal class Program
{
    private static void Main(string[] args)
    {
        int[,] field =
        {
            { 0, 0, 0, 0 },
            { 0, 0, 1, 0 },
            { 1, 0, 0, 1 }
        };
        int k = 2;
        CandidateLocationsFinder game = new CandidateLocationsFinder(k, field);
        int[,] field2 =
        {
            { 0, 0, 0, 1 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 1, 0, 0, 0 },
            { 0, 0, 0, 0 }
        };
        k = 4;
        CandidateLocationsFinder game2 = new CandidateLocationsFinder(k, field2);
        int[,] field3 =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        k = 3;
        CandidateLocationsFinder game3 = new CandidateLocationsFinder(k, field3);
    }
}

public class CandidateLocationsFinder
{
    private int[,] field;
    private int[,] processed;
    private int k;
    private List<int[]> houseLocations = [];

    public CandidateLocationsFinder(int k, int[,] field)
    {
        this.field = field;
        this.k = k;
        processed = new int[field.GetLength(0), field.GetLength(1)];
        GetHouseLocations();
        Queue<int[]> candidates = [];
        List<int[]> processedCandidates = [];
        candidates.Enqueue([houseLocations[0][0], houseLocations[0][1], 0]);
        processed[houseLocations[0][0], houseLocations[0][1]] = 1;
        while (!(candidates.Count == 0))
        {
            int[] currentLoc = candidates.Dequeue();
            if (
                distance(currentLoc, houseLocations[1]) <= k
                && !(this.field[currentLoc[0], currentLoc[1]] == 1)
            )
            {
                processedCandidates.Add(currentLoc);
            }
            if (currentLoc[2] < k)
            {
                AddNeighbors(currentLoc[0], currentLoc[1], currentLoc[2], candidates);
            }
        }

        Print2DArray(processed);
        IEnumerable<int[]> filteredResultsTwo = processedCandidates;
        for (int i = 2; i < houseLocations.Count; i++)
        {
            filteredResultsTwo = filteredResultsTwo
                .Where(candidate => distance(candidate, houseLocations[i]) <= k)
                .ToList();
            //Print(filteredResultsTwo);
        }
        Console.WriteLine(filteredResultsTwo.ToList().Count);
    }

    public void Print(IEnumerable<int[]> list)
    {
        foreach (var item in list)
        {
            Console.Write($"({item[0] + 1}, {item[1] + 1}), ");
        }
        Console.WriteLine();
    }

    public void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    private void AddNeighbors(int row, int col, int d, Queue<int[]> candidates)
    {
        int[][] neighbors =
        [
            [row - 1, col],
            [row + 1, col],
            [row, col - 1],
            [row, col + 1]
        ];
        for (int i = 0; i < neighbors.Length; i++)
        {
            if (
                InBounds(neighbors[i][0], neighbors[i][1])
                && !(processed[neighbors[i][0], neighbors[i][1]] > 0)
            )
            {
                candidates.Enqueue([neighbors[i][0], neighbors[i][1], d + 1]);
                processed[neighbors[i][0], neighbors[i][1]] = d + 1;
            }
        }
    }

    private int distance(int[] pointA, int[] pointB)
    {
        return Math.Abs(pointA[0] - pointB[0]) + Math.Abs(pointA[1] - pointB[1]);
    }

    public void GetHouseLocations()
    {
        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] == 1)
                {
                    houseLocations.Add([row, col]);
                }
            }
        }
    }

    private bool InBounds(int row, int col)
    {
        return row >= 0 && col >= 0 && col < field.GetLength(1) && row < field.GetLength(0);
    }
}
