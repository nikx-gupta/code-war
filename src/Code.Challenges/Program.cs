using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using BenchmarkDotNet.Running;
using Code.Challenges.Lib;
using Code.Challenges.Lib.Graphs;
using Code.Challenges.Lib.Statistics;

namespace Code.Challenges {
    class Program {
        static void Main(string[] args) {
            ExecuteCode();

            Console.WriteLine(Environment.NewLine + "Success");
            Console.Read();
        }

        static void ExecuteCode() {

            //AddBinary();
            //MakeComplement("");
            // PrintNumberOnNewLine();
            //SockChallenge.TestRun();
            // CountingValleys.Run();
            //JumpingOnTheClouds.Run();
            //RepeatedString.Run();
            //Array2D.Run();
            //NewYearChaos.Run();
            //DiagonalDifference.Run();
            //PluMinusDifference.Run();
            //StairCase.Run();
            //MinMaxSum.Run();

            //MeanMedianMode.Run();
            // new Anagrams().Run();
            // new IntegerToBinary().Run();
            // NewYearChaos.Run();
            // new SherlockString().Run();
            // new HighValuePalindrome().Run();
            // new AbraKaDabraSeries().Run();
            // new PersonalInfo().Run();
            // new ScatterredPalindromes().Execute();
            // new RoadsAndLibraries().Execute();

            // BenchmarkRunner.Run<MinimumSwaps>();
            // new MinimumSwaps().Execute();
            // new ArrayManipulation().Execute();
            new SubArrays().Execute();
        }


        public static string AddBinary() {
            int a = 0, b = 0;
            //Implement a function that adds two numbers
            //together and returns their sum in binary. The conversion can be done before, or after the addition.
            return Convert.ToString((a + b), 2);
        }

        public static string MakeComplement(string dna) {
            //Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for
            //    the development and functioning of living organisms.
            // In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". You have
            // function with one side of the DNA (string, except for Haskell); you need to get the other complementary side.
            // DNA strand is never empty or there is no DNA at all (again, except for Haskell).
            //Your code
            string.Join("",
                dna.ToLower().Select(x => x == 'a' ? 't' : (x == 't' ? 'a' : (x == 'c' ? 'g' : (x == 'g' ? 'c' : ' '))))
                    .ToArray());
            return "";
        }

        public static void PrintNumberOnNewLine() {
            //Write a short program that prints each number from 1 to 100 on a new line. 
            // 
            // For each multiple of 3, print "Fizz" instead of the number. 
            // 
            // For each multiple of 5, print "Buzz" instead of the number. 
            // 
            // For numbers which are multiples of both 3 and 5, print "FizzBuzz" instead of the number.

            for (int i = 1; i <= 100; i++) {
                Console.WriteLine((i % 3 == 0 && i % 5 == 0) ? "FizzBuzz" : i % 5 == 0 ? "Buzz" : i % 3 == 0 ? "Fizz" : i.ToString());
            }
        }

        public static void PrintLeibinz() {
            //In Calculus, the Leibniz formula for π is given by:
            // 
            // Leibniz
            // 
            // or:
            // 
            // Summation
            // 
            // You will be given an integer n. Your task is to print the summation of the Leibniz formula up to
            // the nth term of the series correct to 15 decimal places.
            // 
            // Input Format
            // 
            // The first line contains the number of test cases (T) which is less than 100.
            // Each additional line is a test case for a positive integer value (p) less than 10^7.


        }
    }
}