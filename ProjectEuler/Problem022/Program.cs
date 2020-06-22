using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem022 {
    class Program {
        static void Main(string[] args) {
            string text = File.ReadAllText("names.txt").Replace("\"","");
            List<string> delimited = text.Split(',').ToList();
            delimited.Sort();

            int totalSum = 0;
            for (int i = 0; i < delimited.Count; i++) {
                int wordsum = 0;
                foreach (char k in delimited[i]) {
                    wordsum += (int)k - 64;
                }
                totalSum += wordsum * (i + 1);
            }
            Console.WriteLine(totalSum);
            Console.ReadKey();
        }
    }
}
