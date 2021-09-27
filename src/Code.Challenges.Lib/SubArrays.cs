using System;
using System.Collections.Generic;

namespace Code.Challenges.Lib {
    public class SubArrays {
        public void Execute() {
            Run(new[] {
                1, 2, 3, 4, 5
            });
        }

        public void Run(int[] parentArray) {
            for (int i = 0; i < parentArray.Length; i++) {
                var subArr = new List<List<int>>();
                subArr.Add(new List<int>() {
                    parentArray[i]
                });
                if (i == parentArray.Length - 1) {
                    break;
                }

                for (int j = i + 1; j < parentArray.Length; j++) {
                    var newEdition = new List<int>();
                    newEdition.AddRange(subArr[subArr.Count - 1]);
                    newEdition.Add(parentArray[j]);
                    subArr.Add(newEdition);
                }

                foreach (var arr in subArr) {
                    PrintArray(arr);
                }
            }
        }

        private void PrintArray(List<int> arr) {
            for (int i = 0; i < arr.Count; i++) {
                Console.Write(arr[i]);
            }

            Console.WriteLine();
        }
    }
}