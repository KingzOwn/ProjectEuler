using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8 {
    class Program {

        //note this was done 2ce, one with a slightly quicker method (dividing the first number and multiplying the last) and 
        //once with a short method (just calculate the product for every 13 numbers

        const string numbers =
            "73167176531330624919225119674426574742355349194934" +
            "96983520312774506326239578318016984801869478851843" +
            "85861560789112949495459501737958331952853208805511" +
            "12540698747158523863050715693290963295227443043557" +
            "66896648950445244523161731856403098711121722383113" +
            "62229893423380308135336276614282806444486645238749" +
            "30358907296290491560440772390713810515859307960866" +
            "70172427121883998797908792274921901699720888093776" +
            "65727333001053367881220235421809751254540594752243" +
            "52584907711670556013604839586446706324415722155397" +
            "53697817977846174064955149290862569321978468622482" +
            "83972241375657056057490261407972968652414535100474" +
            "82166370484403199890008895243450658541227588666881" +
            "16427171479924442928230863465674813919123162824586" +
            "17866458359124566529476545682848912883142607690042" +
            "24219022671055626321111109370544217506941658960408" +
            "07198403850962455444362981230987879927244284909188" +
            "84580156166097919133875499200524063689912560717606" +
            "05886116467109405077541002256983155200055935729725" +
            "71636269561882670428252483600823257530420752963450";

        static Queue<int> currentNumbers;
        static Queue<int> largestConsecutiveNumbers;
        static UInt64 largestProduct;
        static UInt64 currentProduct;

        static int LoadList(int startingNumber) {
            currentNumbers = new Queue<int>(13);
            currentProduct = Convert.ToUInt64(char.GetNumericValue(numbers[0]));
            currentNumbers.Enqueue(Convert.ToInt32(char.GetNumericValue(numbers[0])));
            for (int i = startingNumber + 1; i < startingNumber + 13 && i+13 < numbers.Count(); i++) {
                if (numbers[i] == '0') {
                    while (numbers[i] == '0' || numbers[i + 1] == '0') {
                        if (i + 13 < numbers.Count()) {
                            return i + 13;
                        }
                        i++;
                    }
                    startingNumber = i;
                    currentNumbers = new Queue<int>(13);
                    currentProduct = Convert.ToUInt64(char.GetNumericValue(numbers[0]));
                    currentNumbers.Enqueue(Convert.ToInt32(char.GetNumericValue(numbers[0])));
                    i++;
                }
                currentNumbers.Enqueue(Convert.ToInt32(char.GetNumericValue(numbers[i])));
                currentProduct *= Convert.ToUInt64(char.GetNumericValue(numbers[i]));
            }
            return startingNumber + 13;

        }

        static void QuickerMethod() {
            int start = LoadList(0);
            largestConsecutiveNumbers = new Queue<int>(currentNumbers);
            largestProduct = currentProduct;
            for (int i = start; i < numbers.Count(); i++) {
                if (numbers[i] == '0') {
                    i = LoadList(i + 1);
                    if (i >= numbers.Count()) {
                        break;
                    }
                }
                currentProduct /= Convert.ToUInt64(currentNumbers.Dequeue());
                currentProduct *= Convert.ToUInt64(char.GetNumericValue(numbers[i]));
                currentNumbers.Enqueue(Convert.ToInt32(char.GetNumericValue(numbers[i])));
                if (currentProduct > largestProduct) {
                    largestProduct = currentProduct;
                    largestConsecutiveNumbers = currentNumbers;
                }
            }
        }

        static void ShortMethod() {
            largestProduct = 0;
            for (int i=0;i+13 < numbers.Count();i++) {
                if (numbers[i] == '0')
                    continue;
                currentProduct = Convert.ToUInt64(char.GetNumericValue(numbers[i]));
                for (int k=i+1;k<i+13;k++ ) {
                    currentProduct *= Convert.ToUInt64(char.GetNumericValue(numbers[k]));
                    if (numbers[k] == '0')
                        break; //done after so current product set to 0
                }
                if (currentProduct > largestProduct) {
                    largestProduct = currentProduct;
                }
            }
        }

        static void Main(string[] args) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ShortMethod();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch = Stopwatch.StartNew();
            QuickerMethod();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
