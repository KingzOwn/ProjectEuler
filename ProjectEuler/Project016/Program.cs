using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Project016 {
    class Program {
        static void Main(string[] args) {
            BigInteger power;
            int value = 2;
            int exponent = 1000;
            power = BigInteger.Pow(value, exponent);

            int addition = 0;

            string line = power.ToString();
            for (int i=0;i<line.Length;i++) {
                //addition += (int)char.GetNumericValue(line[i]);
                addition += int.Parse(line.Substring(i, 1));
            }

            Console.WriteLine(addition);
            Console.ReadKey();
        }
    }
}
