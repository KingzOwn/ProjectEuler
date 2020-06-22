using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem024 {
    class Program {

        static void Main(string[] args) {
            int currentFactorial = 1;

            int[] factorials = new int[10];
            for (int i = 1; i <= 10; i++) {
                currentFactorial *= i;
                factorials[i - 1] = currentFactorial;
            }
            int current = 1000000 - 1;
            int[] permutations = new int[10];
            for (int i = 0; i < 10; i++) {
                permutations[i] = current / factorials[9 - i];
                current = current % factorials[9 - i];

                Console.WriteLine(i + ": " + permutations[i] + ": " + current);
            }

            List<int> nums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string str = "";
            for (int i = 1; i <= 9; i++) {
                str += nums[permutations[i]];
                nums.RemoveAt(permutations[i]);
            }
            while (nums.Count > 0) {
                str += nums[0];
                nums.RemoveAt(0);
            }


            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
