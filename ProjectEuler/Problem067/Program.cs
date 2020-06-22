using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem067 {
    class Program {
        public static List<List<Tuple<int, int, LinkedList<int>>>> readTriangle() {
            List<List<Tuple<int, int, LinkedList<int>>>> triangle;
            triangle = new List<List<Tuple<int, int, LinkedList<int>>>>();
            foreach (string line in File.ReadLines("Triangle.txt")) {
                triangle.Add(new List<Tuple<int, int, LinkedList<int>>>());
                foreach (string number in line.Split(' ')) {
                    triangle.Last().Add(new Tuple<int, int, LinkedList<int>>(int.Parse(number), -1, new LinkedList<int>()));
                }
            }
            return triangle;
        }
        static void Main(string[] args) {
            List<List<Tuple<int, int, LinkedList<int>>>> pyramid; //pyramid value, best solution, indexes of best solution
            
            pyramid = readTriangle();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            KeyValuePair<int, LinkedList<int>> result = Problem018.Program.PerformAStar(pyramid);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            Console.WriteLine(result.Key);
            Console.Write("Indexes: ");
            foreach (int i in result.Value) {
                Console.Write(i.ToString() + ",");
            }
            Console.WriteLine();
            Console.Write("Addition: ");
            int j = 0;
            foreach (int i in result.Value) {
                Console.Write(pyramid[j][i].Item1.ToString() + "+");
                j++;
            }

            Console.ReadKey();
        }
    }
}
