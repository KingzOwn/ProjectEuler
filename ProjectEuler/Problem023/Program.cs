using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem023 {
    class Program {
        static void Main(string[] args) {
            int maxNumber = 28123 - 12;
            List<int> abundantNumbers = new List<int>();
            for (int i = 1; i < maxNumber; i++) {
                int divisorSum = GetDivisorsSum(i);
                if (divisorSum > i) {
                    abundantNumbers.Add(i);
                }
            }

            HashSet<int> sumOfAbundantNumbers = new HashSet<int>();
            for (int i = 0; i < abundantNumbers.Count; i++) {
                for (int j = i; j<abundantNumbers.Count; j++) {
                    int k = abundantNumbers[i] + abundantNumbers[j];
                    if (!sumOfAbundantNumbers.Contains(k)) {
                        sumOfAbundantNumbers.Add(k);
                    }
                }
            }

            int noAbundantNumberSum = 0;
            for (int i=1;i<maxNumber;i++) {
                if (!sumOfAbundantNumbers.Contains(i)) {
                    noAbundantNumberSum += i;
                }
            }

            Console.Write(noAbundantNumberSum);
            Console.ReadKey();
        }

        public static int GetDivisorsSum(int number) {
            double max = Math.Sqrt(number);
            int sum = 0;
            for (int i = 1; i <= max; i++) {
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
