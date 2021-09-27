using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Code.Challenges.Lib.Statistics
{
  public class WeightedMean
  {
    /*
     Mean: 
      In the previous challenge, we calculated a mean. In this challenge, we practice calculating a weighted mean. Check out the Tutorial tab for learning materials and an instructional video!
       
       Task 
       Given an array, , of  integers and an array, , representing the respective weights of 's elements, calculate and print the 
       weighted mean of 's elements. Your answer should be rounded to a scale of  decimal place (i.e.,  format).
       
       Input Format
       
       The first line contains an integer, , denoting the number of elements in arrays  and . 
       The second line contains  space-separated integers describing the respective elements of array . 
       The third line contains  space-separated integers describing the respective elements of array .
     */
    public static void Run()
    {
      var arr1 = Util.GetArray("10 40 30 50 20");
      var arr2 = Util.GetArray("1 2 3 4 5");
      //var arr1 = Util.ReadArrayFromFile("MeanMode.txt").First();
      //var arr2 = Util.ReadArrayFromFile("MeanMode.txt").Skip(1).First();

      //Weighted Mean
      double sum = 0;
      for (int i = 0; i < arr1.Length; i++)
      {
        sum += (arr1[i] * arr2[i]);
      }

      Console.WriteLine(Math.Round(sum / arr2.Sum(), 1));
    }
  }
}
