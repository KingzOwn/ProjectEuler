using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem020 {
    class Program {
        static void Main(string[] args) {
            int factorial = 100;
            BigInteger solution = 1;
            for (int i=1;i<= factorial; i++) {
                solution *= i;
            }
            Console.WriteLine(solution);
            Console.WriteLine();

            string stringsolution = solution.ToString();
            int addition = 0;
            foreach (char i in stringsolution) {
                addition += (int)Char.GetNumericValue(i);
            }
            Console.WriteLine(addition);

            Console.ReadKey();
        }
    }
}
