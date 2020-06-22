using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Problem7
    {
        List<int> listOfPrimes;

        //assumed list of primes contains all previous primes
        bool isPrime(int number) {
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

        void Get10001Primes() {
            listOfPrimes = new List<int>(10002);
            int i = 2;
            while (listOfPrimes.Count < 10001) {
                if (isPrime(i)) {
                    listOfPrimes.Add(i);
                }
                i++;
            }
            Console.ReadKey();
        }
    }
}
