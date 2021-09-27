using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Challenges.Lib
{
  public class JumpingOnTheClouds
  {
    /*
     Emma is playing a new mobile game that starts with consecutively numbered clouds. Some of the clouds are
     thunderheads and others are cumulus. She can jump on any cumulus cloud having a number that is equal to 
     the number of the current cloud plus  or . She must avoid the thunderheads. Determine the minimum number of 
     jumps it will take Emma to jump from her starting postion to the last cloud. It is always possible to win the game.
       
       For each game, Emma will get an array of clouds numbered  if they are safe or  if they must be avoided. 
       For example,  indexed from . The number on each cloud is its index in the list so she must avoid the clouds at indexes  and 
       . She could follow the following two paths:  or . The first path takes jumps while the second takes .
     */
    public static void Run()
    {
      int[] c = new[] { 0, 1, 0, 0, 0, 1, 0 };
      //int[] c = new[] { 0, 0, 1, 0, 0, 1, 0 };
      //int[] c = new[] { 0, 0, 0, 0, 1, 0 };
      List<int> path = new List<int>();
      for (int i = 0; i < c.Length; i++)
      {
        if (c[i] == 0)
          path.Add(i);
      }

      for (int i = 1; i < path.Count; i++)
      {
        if (i != path.Count - 1)
        {
          if (path[i] - path[i - 1] == 1 && path[i + 1] - path[i] == 1)
          {
            path.RemoveAt(i);
            i--;
          }
        }
      }

      Console.WriteLine(string.Join(",", path.ToArray()));
    }

    public static void Optimized()
    {
      int[] c = new[] { 0, 1, 0, 0, 0, 1, 0 };
      //int[] c = new[] { 0, 0, 1, 0, 0, 1, 0 };
      //int[] c = new[] { 0, 0, 0, 0, 1, 0 };
      List<int> path = new List<int>();
      for (int i = 0; i < c.Length; i++)
      {
        if (i > 0 && i != c.Length - 1 && (c[i] == 0 && c[i - 1] == 0 && c[i + 1] == 0) && i - path.Last() == 1)
        {
        }
        else if (c[i] == 0)
          path.Add(i);
      }
    }
  }
}
