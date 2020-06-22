using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem012 {
	class Program {
		static void Main(string[] args) {
			int i = 7;
			UInt64 k = 28;
			while(true) {
				i++;
				k += (UInt64)i;
				if(Factor(k).Count > 500) {
					Console.WriteLine($"{i}: {k}");
					break;
				}
			}
			Console.ReadKey();
		}

		public static List<UInt64> Factor(UInt64 number) {
			List<UInt64> factors = new List<UInt64>();
			UInt64 max = (UInt64)Math.Sqrt(number);  //round down
			for(UInt64 factor = 1; factor <= max; ++factor) { //test from 1 to the square root, or the UInt64 below it, inclusive.
				if(number % factor == 0) {
					factors.Add(factor);
					if(factor != number / factor) { // Don't add the square root twice
						factors.Add(number / factor);
					}
				}
			}
			return factors;
		}
	}
}
