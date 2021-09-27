using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Challenges.Lib
{
  public class StairCase
  {
    /*
     Observe that its base and height are both equal to , and the image is drawn using # symbols and spaces. The last line is not preceded by any spaces.
       
       Write a program that prints a staircase of size .
       
       Function Description
       
       Complete the staircase function in the editor below. It should print a staircase as described above.
       
       staircase has the following parameter(s):
       
       n: an integer
       Input Format
       
       A single integer, , denoting the size of the staircase.
     */
    public static void Run()
    {
      var n = 10;

      for (int i = 1; i <= n; i++)
      {
        Console.WriteLine(string.Join("", Enumerable.Repeat("#", i)).ToString().PadLeft(n));
      }
    }
  }
}
