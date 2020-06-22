using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem021 {
    class Program {
        static void Main(string[] args) {
            int maxNum = 10000;

            SortedDictionary<int, int> divisors = new SortedDictionary<int, int>();
            for (int i=1;i<maxNum;i++) {
                divisors.Add(i, GetDivisorsSum(i));
            }

            int amicableNumbersAddition = 0;
            foreach (int i in divisors.Keys) {
                int current;
                if (divisors[i] != i) {
                    if (divisors[i] < maxNum) {
                        current = divisors[divisors[i]];
                    }
                    else {
                        current = GetDivisorsSum(divisors[i]);
                    }
                    if (current == i) {
                        amicableNumbersAddition += i;
                        Console.WriteLine(i + ": " + divisors[i]);
                    }
                }
            }
            
            Console.WriteLine(amicableNumbersAddition);
            Console.ReadKey();
        }

        public static int GetDivisorsSum(int number){
            double max = Math.Sqrt(number);
            int sum = 0;
            for (int i=1;i<=max;i++) {
                if (number % i == 0) {
                    sum += i;
                    int opp = number / i;
                    if (opp != i && opp != number) {
                        sum += opp;
                    }
                }
            }
            return sum;
        }
    }
}
