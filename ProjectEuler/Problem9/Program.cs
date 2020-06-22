using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9 {
	class Program {
		static void Main(string[] args) {
			List<int> powers = new List<int>();

			//get powers
			for(int i = 0; i <= 1000; i++) {
				powers.Add((int)Math.Pow(i, 2)); //pow 2 are ints
			}

			for(int i = 0; i <= 1000; i++) {
				for(int j = i + 1; j <= 1000; j++) {
					int result = powers[i] + powers[j];
					for(int k = Math.Max(i, j) + 1; k < powers.Count; k++) {
						if(result == powers[k]) { //pythagorean triplet
							if(i + j + k == 1000) {
								Console.WriteLine($"{i} {j} {k} {i * j * k}");
								Console.ReadKey();
								return;
							}
						}
					}

				}
			}

			Console.WriteLine("Cannot find");
			Console.ReadKey();

		}
	}
}
