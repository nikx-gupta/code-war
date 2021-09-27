using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Code.Challenges.Lib {
    public class HighValuePalindrome {
        public void Run() {
            // Console.WriteLine(Palindrome("923329", 6, 2));
            // Console.WriteLine(Palindrome("923320", 6, 3));
            // Console.WriteLine(Palindrome("9236320", 7, 3));
            Console.WriteLine(Palindrome("01233210", 8, 2));
            Console.WriteLine(Palindrome("00222290", 8, 4));
        }

        public string Palindrome(string s, int n, int k) {
             int count = 0;

            string[] completeString = new string[s.Length];
            for (int i = 0, j = s.Length - 1; i < s.Length; i++, j--) {
                if (i > j)
                    break;
                if(i==j && count < k){
                    completeString[i]= "9";
                    count++;
                    break;
                }
                if (s[i] != s[j]) {
                    if (count > k)
                        break;

                    count++;
                    int ln = Convert.ToInt32(s[i].ToString());
                    int rn = Convert.ToInt32(s[j].ToString());
                    if (ln == 0) {
                        completeString[i] = "9";
                        if (rn != 9) {
                            completeString[j] = "9";
                            // One Extra count for 9 at second location
                            count++;
                        }
                    }
                    else {
                        if (ln < rn) {
                            completeString[i] = completeString[j] = rn.ToString();
                        }
                        else {
                            completeString[i] = completeString[j] = ln.ToString();
                        }
                    }
                }
                else {
                    // copy same string
                    completeString[i] = completeString[j] = s[i].ToString();
                }
            }

            if (count < k) {
                // One More Iteration to replace with 9
                for (int i = 0, j = s.Length - 1; i < s.Length; i++, j--) {
                    if (i >= j || count >= k)
                        break;
                    if (count + 1 <= k && (completeString[i] != s[i].ToString() || completeString[j] != s[j].ToString())) {
                        count++;
                        completeString[i] = completeString[j] = "9";
                        continue;
                    }

                    if (count + 2 > k)
                        break;
                    int ln = Convert.ToInt32(s[i].ToString());
                    int rn = Convert.ToInt32(s[j].ToString());
                    if (ln != 9) {

                        completeString[i] = completeString[j] = "9";
                        count += 2;
                        ;
                    }
                }
            }

            if (count > k)
                return "-1";

            return string.Join("", completeString);
        }
    }
}