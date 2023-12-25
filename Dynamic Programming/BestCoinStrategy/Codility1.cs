using System;
// you can also use other imports, for example:
using System.Collections.Generic;
using System.Linq;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] A)
    {
        // Implement your solution here
        // Console.WriteLine("[{0}]", string.Join(", ", A.Skip(1).ToArray()));
        Dictionary<int[], int> memo = new Dictionary<int[], int>();
        return GetMaxSum(A, ref memo);
        // return GetMaxSum1(A);
    }

    public int GetMaxSum3(int[] A)
    {
        int[] B = new int[A.Length];
        B[0] = A[0];
        B[1] = A[1] + A[0];
        for (int i = 2; i < A.Length; i++)
        {
            int maxWindow = Math.Min(6, i);
            int currentMax = B[i - 1];
            for (int j = 2; j <= maxWindow; j++)
            {
                currentMax = Math.Max(currentMax, B[i - j]);
            }
            B[i] = currentMax + A[i];
        }
        return B[B.Length - 1];
    }

    public int GetMaxSum1(int[] A)
    {
        int previousMax = A[0];
        for (int i = 1; i < A.Length - 1; i++)
        {
            previousMax = Math.Max(A[i] + previousMax, previousMax);
        }
        return previousMax + A[A.Length - 1];
    }

    public int GetMaxSum(int[] A, ref Dictionary<int[], int> memo)
    {
        if (A.Length == 2)
            return A[0] + A[1];
        int value;
        if (memo.TryGetValue(A, out value))
            return value;
        int maxSum = 0;
        int possibleDistance = Math.Min(A.Length - 1, 6);
        // Console.WriteLine($"{possibleDistance}");
        for (int jump = 1; jump <= possibleDistance; jump++)
        {
            int currentSum = GetMaxSum(A.Skip(jump).ToArray(), ref memo);
            // Console.WriteLine($"{currentSum} {jump}");
            if (jump == 1)
            {
                maxSum = currentSum;
                // Console.WriteLine(maxSum);
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
        // Console.WriteLine($"[{string.Join(", ", A)}] {maxSum + A[0]}" );
        memo.Add(A, maxSum + A[0]);
        return maxSum + A[0];
    }
    public int findMinValue(int[] A){
        int previousValue = 0;
        for (int i = 0; i < A.Length; i++)
        {
            previousValue = Math.Min(Math.Abs(previousValue - A[i]), Math.Abs(previousValue + A[i]));
        }
        return previousValue
    }

}




/*
[9,-1,-2]
[1,-2,0,9,-1,-2]
[-10000,5000, 1239, -5000, 4000, 2000]
[1,1,-3,1,1,0,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3]
*/
