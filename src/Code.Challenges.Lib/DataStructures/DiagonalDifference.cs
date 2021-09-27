using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Challenges.Lib
{
  public class DiagonalDifference
  {
    public static void Run()
    {
      //var arr = new int[6][]
      //{
      //  new[] {11, 2, 4, 4, 5, 4},
      //  new[] {4, 5, 6, 4, 5, 6},
      //  new[] {10, 8, -12, 4, 5, 6},
      //  new[] {1, 2, 0, 0, 5, 6},
      //  new[] {1, 0, 3, 4, 0, 6},
      //  new[] {0, 2, 3, 4, 5, 0},
      //};
      var arr = new int[3][]
      {
        new[] {11, 2, 4},
        new[] {4, 5, 6},
        new[] {10, 8, -12},
      };

      int sum = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        sum += arr[i][i];
      }
      for (int i = 0; i < arr.Length; i++)
      {
        Console.WriteLine(arr[i][arr.Length - 1 - i]);
        sum -= arr[i][arr.Length - 1 - i];
      }

      Console.WriteLine(sum);
    }
  }
}
