using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Code.Challenges.Lib
{
  public static class Array2D
  {
    /*
      1 1 1 0 0 0
       0 1 0 0 0 0
       1 1 1 0 0 0
       0 0 0 0 0 0
       0 0 0 0 0 0
       0 0 0 0 0 0
      
      We define an hourglass in  to be a subset of values with indices falling in this pattern in 's graphical representation:
       
       a b c
       d
       e f g
       There are  16 hourglasses in , and an hourglass sum is the sum of an hourglass' values. Calculate the hourglass sum for every hourglass in , then print the maximum hourglass sum.
       
       For example, given the 2D array:
       
       -9 -9 -9  1 1 1 
       0 -9  0  4 3 2
       -9 -9 -9  1 2 3
       0  0  8  6 6 0
       0  0  0 -2 0 0
       0  0  1  2 4 0
     */
    public static void Run()
    {
      int[][] arr = GetArr();

      var rows = arr.GetLength(0);
      var columns = arr[0].Length;

      List<int> allSums = new List<int>();
      for (int rp = 0; rp <= rows - 3; rp++)
      {
        List<int> sums = new List<int>();
        for (int cp = 0; cp <= columns - 3; cp++)
        {
          sums.Add(PrintHourGlass(rp, cp, arr));
        }

        allSums.AddRange(sums);
        //Console.WriteLine(string.Join(",", sums));
      }

      Console.WriteLine($"Highest : {allSums.Max()}");
    }

    private static int PrintHourGlass(int ri, int ci, int[][] arr)
    {
      //Console.WriteLine($"Row Partition: {ri}, Column Partition: {ci + 1}");

      int sum = 0;
      for (int i = ri; i < ri + 3; i++)
      {
        string row = "";
        for (int j = ci; j < ci + 3; j++)
        {
          if (i == ri + 1 && (j == ci || j == ci + 2))
            row = row + " 0";
          else
          {
            sum += arr[i][j];
            row = row + " " + arr[i][j];
          }
        }

        //Console.WriteLine(row);
      }

      //Console.WriteLine($"\t Sum : {sum}");
      return sum;
    }

    private static int[][] GetArr()
    {
      //int[,] arr = new int[6, 6]
      //{
      //  {1 ,1 ,1, 0, 0, 0 },
      //  {0 ,1, 0, 0, 0, 0 },
      //  {1 ,1, 1, 0, 0, 0 },
      //  {0 ,0, 2, 4, 4, 0 },
      //  {0 ,0, 0, 2, 0, 0},
      //  {0 ,0, 1, 2, 4, 0 },
      //};
      //int[,] arr = new int[6, 6]
      //{
      //  {1 ,1 ,1, 0, 0, 0 },
      //  {0 ,1, 0, 0, 0, 0 },
      //  {1 ,1, 1, 0, 0, 0 },
      //  {0 ,0, 0,0, 0, 0 },
      //  {0 ,0, 0, 0, 0, 0},
      //  {0 ,0, 0, 0, 0, 0 },
      //};

      int[][] arr = new int[6][]
      {
        new int[] {-9, -9, -9, 1, 1, 1},
        new int[] {0, -9, 0, 4, 3, 2},
        new int[] {-9, -9, -9, 1, 2, 3},
        new int[] {0, 0, 8, 6, 6, 0},
        new int[] {0, 0, 0, -2, 0, 0},
        new int[] {0, 0, 1, 2, 4, 0},
      };

      return arr;
    }

    private static int[,] CreateEmptyGlass()
    {
      return new int[3, 3]
      {
        {0 ,0 ,0},
        {0 ,0, 0},
        {0 ,0, 0},
      };
    }
  }
}
