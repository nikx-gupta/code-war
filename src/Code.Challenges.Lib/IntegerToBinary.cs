using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Code.Challenges.Lib {
    public class IntegerToBinary {
        public void Run() {
            // Write a function that takes an integer as input, and returns the number of bits that are equal to one in the binary representation of that number.
            // You can guarantee that input is non-negative.
            Console.WriteLine("Count of 1 for Input:{0}, is {1}", 0, Execute(0));
            Console.WriteLine("Count of 1 for Input:{0}, is {1}", 4, Execute(4));
            Console.WriteLine("Count of 1 for Input:{0}, is {1}", 7, Execute(7));
            Console.WriteLine("Count of 1 for Input:{0}, is {1}", 9, Execute(9));
            Console.WriteLine("Count of 1 for Input:{0}, is {1}", 10, Execute(10));
        }

        public int Execute(int n) {
            // Convert to Binary Representation
            var bytes = Convert.ToString(n, 2);
            return bytes.Where(x => x == '1').Count();
        }
    }
}