using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Challenges.Lib
{
  public class MinMaxSum
  {
    /*
     Given five positive integers, find the minimum and maximum values that can be calculated by summing exactly four of the five integers. Then print the respective minimum and maximum values as a single line of two space-separated long integers.
       
       For example, . Our minimum sum is  and our maximum sum is . We would print
       
       16 24
       Function Description
       
       Complete the miniMaxSum function in the editor below. It should print two space-separated integers on one line: the minimum sum and the maximum sum of  of  elements.
       
       miniMaxSum has the following parameter(s):
       
       arr: an array of  integers
     */
    public static void Run()
    {
      //var arr = Util.GetLongArray("-1 2 3 4 5");
      var arr = Util.GetLongArray("256741038 623958417 467905213 714532089 938071625");
      Array.Sort(arr);
      Console.WriteLine(arr.Take(4).Sum().ToString() + " " + arr.Skip(arr.Length - 4).Take(4).Sum().ToString());
    }
  }
}
