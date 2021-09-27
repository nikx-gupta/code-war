using System;
using System.Linq;

namespace Code.Challenges.Lib {
    public class ScatterredPalindromes {
        public void Execute() {
            // Console.WriteLine(Run("bbrrg"));
            Console.WriteLine(Run("bbrrgasdasfjlaklfjklajfkjakljflkajksdjkajkldjajdljalkjdlkajkld"));
        }

        public int Run(string s) {
            int count = 0;
            for (int i = 0; i < s.Length; i++) {
                for (int j = 1; j <= s.Length - i; j++) {
                    var isP = IsPalindrome(s.Substring(i, j));
                    Console.WriteLine($"{i} {j} {s.Substring(i, j)} {isP}");
                    if (isP)
                        count++;
                }
            }

            return count;
        }

        private bool IsPalindrome(string s) {
            var grp = s.GroupBy(x => x).ToList();
            var uniqueCount = 0;
            foreach (var item in grp) {
                if (item.Count() % 2 != 0) {
                    if (uniqueCount == 1) {
                        return false;
                    }

                    uniqueCount++;
                }
            }

            return true;
        }
    }
}