using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7 {
    public class Problem7 {
        

        //assumed list of primes contains all previous primes
        public static bool isPrime(int number, List<int> listOfPrimes) {
            double sqrt = Math.Sqrt(number);
            foreach (int i in listOfPrimes) {
                if (i > sqrt) {
                    return true;
                }
                if (number % i == 0) {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args) {
            List<int> listOfPrimes;
            listOfPrimes = new List<int>(10002);
            int i = 2;
            while (listOfPrimes.Count < 10001) {
                if (isPrime(i, listOfPrimes)) {
                    listOfPrimes.Add(i);
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
