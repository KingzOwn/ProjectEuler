using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10 {
	class Program {
		static void Main(string[] args) {
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			List<int> listOfPrimes;
			listOfPrimes = new List<int>() { 2 };
			UInt64 sum = 2;
			for(int i = 3; i < 2000000; i+=2) { 
				if(Problem7.Problem7.isPrime(i, listOfPrimes)) {
					listOfPrimes.Add(i);
					sum += Convert.ToUInt64(i);
				}
			}
			stopwatch.Stop();
			Console.WriteLine(sum);
			Console.WriteLine(stopwatch.ElapsedMilliseconds);
			Console.ReadKey();
		}
	}
}
