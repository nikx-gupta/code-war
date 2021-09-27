using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Analysis.JIT;
using Perfolizer.Mathematics.QuantileEstimators;

namespace Code.Challenges.Lib {
    public class ArrayManipulation {
        [Benchmark]
        public void Execute() {
            Run(10, new int[][] {
                new[] {
                    2, 6, 8
                },
                new[] {
                    3, 5, 7
                },
                new[] {
                    1, 8, 1
                },
                new[] {
                    5, 9, 15
                }
            });
            // Run(10, new int[][] {
            //     new[] {
            //         1, 5, 3
            //     },
            //     new[] {
            //         4, 8, 7
            //     },
            //     new[] {
            //         6, 10, 1
            //     }
            // });

            // Console.WriteLine(Run(new[] {
            //     // 15   13
            //     15, 14, 13, 4, 5, 6, 7, 8, 9, 10, 11, 3, 1, 2, 12
            // }));
            // Console.WriteLine(Run(new[] {
            //     4, 3, 1, 2
            // }));
        }

        public long Run(int n, int[][] queries) {
            if (queries.Length > 1000) {
                var newList = queries.OrderBy(x => x[0]).ToList();
                // long maxSum = queries[0][2];
                List<long> sums = new List<long>();
                // List<int> skips = new List<int>();
                for (int i = 0; i < newList.Count - 1; i++) {
                    var subQ = newList.Skip(i + 1).Where(x => x[0] <= newList[i][1]);
                    if (subQ.Any())
                        sums.Add(subQ.Select(x => (long)x[2]).Sum());
                }

                return sums.Max();
            }
            else {
                var arr = new long[n];
                for (int i = 0; i < queries.Length; i++) {
                    for (int j = queries[i][0] - 1; j < queries[i][1]; j++) {
                        arr[j] = arr[j] + queries[i][2];
                    }
                }

                return arr.Max();
            }

            return 0;
        }

        public void AddSum(long[] arr, int[] entry) {
            for (int j = entry[0] - 1; j < entry[1]; j++) {
                arr[j] = arr[j] + entry[2];
            }
        }
    }
}