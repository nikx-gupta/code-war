using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Code.Challenges.Lib.Statistics
{
  public class MeanMedianMode
  {
    /*
     Mean: 
       We sum all  elements in the array, divide the sum by , and print our result on a new line.
       
       Median: 
       To calculate the median, we need the elements of the array to be sorted in either non-increasing or non-decreasing order.
       The sorted array . We then average the two middle elements:
       
       and print our result on a new line.
       Mode: 
       We can find the number of occurrences of all the elements in the array:Every number occurs once, making  the maximum number 
       of occurrences for any number in . 
       Because we have multiple values to choose from, we want to select the smallest one, , and print it on a new line.
     */
    public static void Run()
    {
      //var arr = Util.GetArray("64630 11735 14216 99233 14470 4978 73429 38120 51135 67060");
      var arr = Util.ReadArrayFromFile("MeanMode.txt").First();

      //Mean
      var mean = Math.Round((double)arr.Sum() / arr.Length, 1);

      Array.Sort(arr);
      var median = arr.Length % 2 == 0
        ? Math.Round((double)(arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2, 1)
        : Math.Round((double)(arr[arr.Length / 2] + arr[arr.Length / 2 + 2]) / 2, 1);

      var mode = from digit in arr
                 group digit by digit
        into grp
                 select new { grp.Key, count = grp.Count() };

      Console.WriteLine(mean);
      Console.WriteLine(median);
      Console.WriteLine(Math.Round((double)mode.OrderByDescending(x => x.count).ThenBy(x => x.Key).First().Key, 1));

    }
  }
}
