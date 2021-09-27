using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Code.Challenges.Lib {
    public class AbraKaDabraSeries {
        public void Run() {
            Print(Execute(new[] {
                1, 2, 3, 4
            }));
            Print(Execute(new[] {
                1, 2, 3, 4, 5, 6
            }));
        }

        public void Print(List<int> series) {
            for (int i = 0; i < series.Count; i++) {
                Console.WriteLine(series[i]);
            }
        }

        public List<int> Execute(int[] n) {
            var length = n.Length;

            if (length < 3) {
                throw new Exception("Length Should be Equal to or greater than 3");
            }

            List<int> sums = new List<int>();
            for (int i = 0, j = 1; i < length; i++, j += 3) {
                sums.Add((sums.Any() ? sums[i - 1] : 1) * Enumerable.Range(i + 1, 3).Sum());
            }

            return sums;
        }
    }

    public class PersonalInfo {
        public void Run() {
            RemovePersonalInfo("a@gmail.com s@yahoo.com c@something.com");
        }

        public string RemovePersonalInfo(string input) {
            Regex reg = new Regex("([a-zA-Z0-9]+(@gmail.com|@yahoo.com))");
            string[] tokens = input.Split(new char[] {
                ' ', '\t', '\r', '\n'
            });

            StringBuilder sb = new StringBuilder();
            foreach (var token in tokens) {
                if (reg.IsMatch(token)) {
                    sb.Append(" <<some email>>");
                }
                else {
                    sb.Append(" ");
                    sb.Append(token);
                }
            }

            return sb.ToString();
        }
    }

    public class TravelDirection {
        public void Run() {
            int x = 0, y = 0, z = 0;
            int dist1 = z - y;
            int dist2 = 2 * (y - x);
        }
    }
}