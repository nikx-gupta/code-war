using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Code.Challenges.Lib {
    /// <summary>
    /// Sherlock considers a string to be valid if all characters of the string appear the same number of times.
    /// It is also valid if he can remove just  1 character at 1 index in the string, and the remaining characters will occur the same number of times.
    /// Given a string s, determine if it is valid. If so, return YES, otherwise return NO.
    /// </summary>
    public class SherlockString {
        public void Run() {
            // Console.WriteLine(FilterSherlockString("aabbccd"));
            // Console.WriteLine(FilterSherlockString("abcdefghhgfedecba"));
            // Console.WriteLine(FilterSherlockString("aaabcdef"));
            // Console.WriteLine(FilterSherlockString("aaabbcbddeeff"));
            //  Console.WriteLine(FilterSherlockString("aabbcd"));
            // Console.WriteLine(FilterSherlockString("aabbccddeefghi"));
            Console.WriteLine(FilterSherlockString("abcdefghhgfedecba"));
        }

        public string FilterSherlockString(string s) {
            var grpChars = s.GroupBy(x => x).OrderByDescending(x => x.Count()).ToList();
            var grpCharCount = grpChars.GroupBy(x => x.Count()).OrderByDescending(x => x.Count()).ToList();

            // All Chars Counts are not Equal
            if (grpChars.Any(x => x.Count() != grpChars[0].Count())) {

                if (grpCharCount.Count() > 2)
                    return "NO";

                if (grpCharCount.Count() == 2) {
                    // If majortity count is equal then it should not be greater than 2 as only 1 can be subtracted to make it equal
                    if (grpCharCount[0].Count() == grpCharCount[1].Count()) {
                        if (grpCharCount[0].Count() >= 2) {
                            return "NO";
                        }
                    }

                    // if second majority and frequency has only one count then minus 1 can bring all majority equal
                    if (grpCharCount[1].Key - grpCharCount[0].Key == 1 && grpCharCount[1].Count() == 1) {
                        return "YES";
                    }
                    
                    // If second majority frequency or character count greater than or equals to 2 then minus 1 cannot bring all chars to equal
                    if (grpCharCount[1].Count() >= 2 || grpCharCount[1].Key >= 2) {
                        return "NO";
                    }

                   

                    var majorityCharCount = grpCharCount[0];
                    if (majorityCharCount.Key - grpCharCount[1].Key == 1) {
                        return "YES";
                    }

                    return "YES";
                }

                return "NO";
            }

            return "YES";
        }
    }
}