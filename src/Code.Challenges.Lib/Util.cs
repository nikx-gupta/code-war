using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Code.Challenges.Lib
{
  public static class Util
  {
    public static int[] GetArray(string line)
    {
      return line.Trim().Split(' ').Select(x => Convert.ToInt32(x.Trim())).ToArray();
    }
    public static long[] GetLongArray(string line)
    {
      return line.Trim().Split(' ').Select(x => Convert.ToInt64(x.Trim())).ToArray();
    }

    public static List<int[]> ReadArrayFromFile(string fileName)
    {
      var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Res", "MeanMode.txt");
      var arrayLists = new List<int[]>();
      if (File.Exists(file))
      {
        var lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
          arrayLists.Add(
            line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray());
        }
      }

      return arrayLists;
    }
  }
}
