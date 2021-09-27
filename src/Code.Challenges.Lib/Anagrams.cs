using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Code.Challenges.Lib {
    public class Anagrams {
        public void Run() {
            FilterAnagrams(new List<string>(){ "code", "doce", "oced", "anagrams", "anagrasm" });
        }

        public void FilterAnagrams(List<string> inVars) {
            int invarCount = inVars.Count;
            for (int i = 0; i < invarCount - 1; i++) {
                var grpChars = inVars[i].GroupBy(x => x).ToList();
                for (int j = 1; j < invarCount; j++) {
                    var nextChars = inVars[j].GroupBy(x => x).ToList();
                    var jn = (from curChar in grpChars
                        join nextChar in nextChars on curChar.Key equals nextChar.Key
                        where nextChar.Count() != curChar.Count()
                        select curChar).ToList();
                    if (jn.Count == 0) {
                        inVars.RemoveAt(j);
                        //invarCount = inVars.Count();
                    }
                }
            }

            foreach (var inVar in inVars) {
                Console.WriteLine(inVar);
            }
        }
    }
}