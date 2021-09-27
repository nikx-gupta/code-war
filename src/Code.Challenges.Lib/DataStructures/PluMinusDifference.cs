using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Challenges.Lib
{
  public class PluMinusDifference
  {
    /*
     *Given an array of integers, calculate the fractions of its elements that are positive, negative,
     * and are zeros. Print the decimal value of each fraction on a new line.
       
       Note: This challenge introduces precision problems. The test cases are scaled to six 
       decimal places, though answers with absolute error of up to  are acceptable.
       
       For example, given the array  there are  elements, two positive, two negative and one zero. 
       Their ratios would be ,  and . It should be printed as
     */
    public static void Run()
    {
      var arr = Util.GetArray("-4 3 -9 0 4 1        ");

      double pSum = 0.0;
      double nSum = 0;
      double zSum = 0;
      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i] == 0)
          zSum++;
        else if (arr[i] > 0)
          pSum++;
        else
          nSum++;
      }

      var retValue = new double[] { Math.Round(pSum / arr.Length, 10), Math.Round(nSum / arr.Length, 10), Math.Round(zSum / arr.Length, 10) };
      Console.WriteLine(string.Join(",", retValue));
    }
  }
}
