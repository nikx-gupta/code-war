using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Code.Challenges.Lib {
    public class MinimumSwaps {
        [Benchmark]
        public void Execute() {

            Run(new[] {
                // 15   13
                15, 14, 13, 4, 5, 6, 7, 8, 9, 10, 11, 3, 1, 2, 12
            });
                
            // Console.WriteLine(Run(new[] {
            //     // 15   13
            //     15, 14, 13, 4, 5, 6, 7, 8, 9, 10, 11, 3, 1, 2, 12
            // }));
            // Console.WriteLine(Run(new[] {
            //     4, 3, 1, 2
            // }));
        }

        public int Run(int[] arr) {
            int swapCounts = 0;
            Dictionary<int, int> swaps = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++) {
                var curValue = i + 1;
                if (arr[i] != curValue) {
                    var atSwapValue = arr[arr[i] - 1];
                    // Check if Value at currentIndex = value at swap index
                    if (atSwapValue == curValue) {
                        // Simple Swap, swap Immediately
                        swapCounts++;
                        arr[arr[i] - 1] = arr[i];
                        arr[i] = curValue;
                    }
                    else {
                        swaps.Add(curValue, arr[i]);
                        // swaps.Add(arr[i], atSwapValue);
                        // Complex Swap
                        swapCounts += DoSwap(ref arr, swaps, arr[i], i);

                    }
                }
            }

            return swapCounts;
        }

        public int DoSwap(ref int[] arr, Dictionary<int, int> swaps, int swapIndex, int curIndex) {
            // All are complex swaps
            int requiredValue = curIndex + 1;
            do {
                if (swaps.ContainsKey(swapIndex))
                    break;
                swaps.Add(swapIndex, arr[swapIndex - 1]);
                if (arr[swapIndex - 1] != requiredValue) {
                    swaps.Add(arr[swapIndex - 1], arr[arr[swapIndex - 1] - 1]);
                    swapIndex = arr[arr[swapIndex - 1] - 1];
                }
                else {
                    break;
                }

            } while (true);

            // For Complex swaps it will always be one less than the total swaps
            int swapCounts = swaps.Count() - 1;
            foreach (var swapItem in swaps) {
                arr[swapItem.Key - 1] = swapItem.Key;
            }
            
            swaps.Clear();
            return swapCounts;
        }
    }
}