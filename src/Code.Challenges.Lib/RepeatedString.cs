using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Challenges.Lib
{
  public static class RepeatedString
  {
    /*
    Lilah has a string, , of lowercase English letters that she repeated infinitely many times.
       
       Given an integer, , find and print the number of letter a's in the first  letters of Lilah's infinite string.
       
       For example, if the string  and , the substring we consider is , the first  characters of her infinite string. There are  occurrences of a in the substring.
       
       Function Description
       
       Complete the repeatedString function in the editor below. It should return an integer representing the number of occurrences of a in the prefix of length  in the infinitely repeating string.
       
       repeatedString has the following parameter(s):
       
       s: a string to repeat
       n: the number of characters to consider
     */
    public static void Run()
    {
      //long n = 10;
      //string s = "aba";
      //long n = 1000000000000;
      //string s = "a";
      //long n = 736778906400;
      //string s = "kmretasscityylpdhuwjirnqimlkcgxubxmsxpypgzxtenweirknjtasxtvxemtwxuarabssvqdnktqadhyktagjxoanknhgilnm";
      long n = 685118368975;
      string s = "ojowrdcpavatfacuunxycyrmpbkvaxyrsgquwehhurnicgicmrpmgegftjszgvsgqavcrvdtsxlkxjpqtlnkjuyraknwxmnthfpt";

      var countInS = s.Where(x => x == 'a').Count();
      var totalCount = n / s.Length * countInS;
      int rem = 0;
      if (n % s.Length > 0)
      {
        var substr = s.Substring(0, (int) (n % s.Length)).Where(x => x == 'a');
        if (substr.Any())
          rem = substr.Count();
      }

      Console.WriteLine(totalCount + rem);
    }
  }
}
