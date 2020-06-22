using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem025 {
    class Program {
        //http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html
        static void Main(string[] args) {
            int n = 1000;

            double sqrtFive = Math.Sqrt(5);

            double phi = ((1 + sqrtFive) / 2);

            double binetsFormula = 0;
            int i;
            for (i = 1; binetsFormula < n; i++) {
                binetsFormula = (i * Math.Log(phi, 10)) - (Math.Log(5, 10) / 2) + 1;
            }
            //double binetsFormula = (4782 * Math.Log(phi, 10)) - (Math.Log(5, 10) / 2) + 1;


            Console.WriteLine(binetsFormula);
            Console.WriteLine(i - 1);
            Console.ReadKey();
        }
    }
}
