using System;
using System.Collections.Generic;
using System.Text;

namespace Code.Challenges.Lib
{
  public static class CountingValleys
  {
    /*
     Gary is an avid hiker. He tracks his hikes meticulously, paying close attention to small details like topography. During his last hike he took exactly  steps. For every step he took, he noted if it was an uphill, , or a downhill,  step. Gary's hikes start and end at sea level and each step up or down represents a  unit change in altitude. We define the following terms:
       
       A mountain is a sequence of consecutive steps above sea level, starting with a step up from sea level and ending with a step down to sea level.
       A valley is a sequence of consecutive steps below sea level, starting with a step down from sea level and ending with a step up to sea level.
       Given Gary's sequence of up and down steps during his last hike, find and print the number of valleys he walked through.
       
       For example, if Gary's path is , he first enters a valley  units deep. Then he climbs out an up onto a mountain  units high. Finally, he returns to sea level and ends his hike.
       
       Function Description
       
       Complete the countingValleys function in the editor below. It must return an integer that denotes the number of valleys Gary traversed.
       
       countingValleys has the following parameter(s):
       
       n: the number of steps Gary takes
       s: a string describing his path
     */
    public static void Run()
    {
      //int n = 8; string s = "UDDDUDUU";
      //int n = 8; string s = "UDUUUDUDDD";
      int n = 8; string s = "DDDDUUDDUUUU";
      //int n = 8; string s = "UDDDUUDUUDDDDUUDDUDDDUUDDDUUDDUUDUDUDDDDUUDDDDDDUUUDUDUDUUDUUUUUUUUUUUDUUUUUDUDUDUDDDDUUDUUUDDDDDUUDUUDUUUUUUDDDDDUUDUUDDDUDUUUUUUUDUUUUDDUDDDDDUUUDDUUUUUUUDDDDUUUDUUUDUUUUUUUDDUUUDDDDUUDUDDDUDDDDUUDDDDDUUDUDDUDUUUDDUDUDDDUUDDUDUUUUUDDUUUDUUUUUUDDUDUUDDUUDDDUDUDDDDUDUDDUUUDDDUDDUDDUUUUDDDUDUDDDUUUUUDUUUDDUDUUDUUUDDUDUUUDUDUDUUUUDDUDDDUUUDDDUDUDDDDDDDUUUUDDUUDUUUDUDUDUDDUUUDDUDUDDUDDUDDDUDUDUDDUUDDDUUDUUDUDDDDDDDDUUDDUUDDUUUUUUDUUUDDUUDUDDUUDDDUDDUUUUUDUDUDDDUUUDDUUDDDUDUUDUUDDDUDDUUDUUUDDUUUUDUUUDDDDUDUUUDDUDDDDDDDUDDDUUDUDDUDUDUUDUDDUUDUUDUUDUUDUDDDUUDDUUUUDUUDUUDUUUUDUUUDDUUUDDUDUDDUDUDUUUDUDDDUUUUDUUDUUUDDUUDUDUDDDDUDUDDDDDUUUDUUUDUDDUUUDUUUUDDUUUDDDUDUDUUDUUUUUDUUDDDUUDDUDDDDUUUDUUUUUDDUUUUUDDUUDUDDUDUDUUUUDUUDUUUDUUDDDUUUUDDDUDUDUUDUDUUDDDUDDUUDDUDUDUUDUDUDDDUDDDUDDDDUDUUUUUDUDUDUUDUUDUDDUDUUDDUUDUDUDDDDUDDUDDUDDUUUUDUDDUUUUDUUDUDDUDDDUDUUUDUDUDUDDDUDDUUUUDDUDUDUDDUDDDUDDDUUUDUDUDUUDUUUUUDUDDDDUUDDDDUDUDDUDDDDUUUDUDUUDUDUUUDDUDUDDDDDUUDUDUUDDDDUUDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD";

      int baseLevel = 0;
      int valleyCount = 0;
      int curType = 0;
      for (int i = 0; i < s.Length;)
      {

       // Console.WriteLine($"{(baseLevel == 0 && s[i] == 'U' ? "Mountain" : "Valley")} Started");
        curType = (baseLevel == 0 && s[i] == 'U' ? 1 : 2);
        do
        {
          //Console.WriteLine(s[i]);
          baseLevel = s[i] == 'U' ? baseLevel + 1 : baseLevel - 1;
          i++;
        } while (baseLevel != 0 && i != s.Length);

        valleyCount = curType == 2 ? valleyCount + 1 : valleyCount;
        // mountained ended
        //Console.WriteLine("Mountain Ended");
      }

      Console.WriteLine($"Valley Count :{valleyCount}");
    }
  }
}
