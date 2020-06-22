using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem014 {
	class Program {
		static void Main(string[] args) {
			int longestChainNumber = 0, longestChainNumberOfTerms = 0;
			for (int i=1;i<1000000;i++) {
				int currentSteps = CollatzProblem((UInt64)i);
				if (currentSteps > longestChainNumberOfTerms) {
					longestChainNumber = i;
					longestChainNumberOfTerms = currentSteps;
				}
			}
			Console.WriteLine($"{longestChainNumberOfTerms} : {longestChainNumber}");
			Console.ReadKey();
		}

		public static int CollatzProblem(UInt64 startingNum) {
			UInt64 currentNum = startingNum;
			int currentSteps = 1;
			while (currentNum != 1) {
				currentNum = CollatzProblemStep(currentNum);
				currentSteps++;
			}
			return currentSteps;
		}

		public static UInt64 CollatzProblemStep(UInt64 num) {
			if(num % 2 == 0)
				return num / 2;
			else
				return 3 * num + 1;
		}
	}
}
