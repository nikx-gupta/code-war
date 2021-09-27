using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Code.Challenges.Lib {
    public static class DictionarySubset {
        public static void Run() {
            string[] magazine = new[] {
                "test1", "test2"
            };

            HashSet<string> mags = magazine.ToHashSet();
            
            var grpMags = magazine.GroupBy(x => x).ToList();
            
        }

        public static void Execute(int[] q) {
            //2, 1, 5, 3, 4
            // 1, 2, 5, 3, 7, 8, 6, 4
            // 1, 2, 3, 4, 5, 6, 7, 8
            int ans = 0;
            for (int i = q.Length - 1; i >= 0; i--) {
                if (q[i] - (i + 1) > 2) {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                var curValue = q[i];
                for (int j = Math.Max(0, curValue - 2); j < i; j++)
                    if (q[j] > q[i]) ans++;
            }
            
            Console.WriteLine(ans);
        }
    }
}