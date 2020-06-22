using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem018 {

    public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y) {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return 0-result;
        }

        #endregion
    }
    public class Program {

        static void Main(string[] args) {
            List<List<Tuple<int, int, LinkedList<int>>>> pyramid; //pyramid value, best solution, indexes of best solution
            pyramid = readTriangle();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            
            KeyValuePair<int, LinkedList<int>> result = PerformAStar(pyramid);
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

        public static KeyValuePair<int, LinkedList<int>> PerformAStar(List<List<Tuple<int, int, LinkedList<int>>>> pyramid) {
            //Key: Solution+indexCurrentValue
            //row, column, indexes of columns for parent rows for solutin
            SortedList<int, Tuple<int, int, LinkedList<int>>> toProcess = new SortedList<int, Tuple<int, int, LinkedList<int>>>(new DuplicateKeyComparer<int>());
            toProcess.Add(pyramid[0][0].Item1, new Tuple<int, int, LinkedList<int>>(0, 0, new LinkedList<int>()));
            toProcess.First().Value.Item3.AddLast(0);

            KeyValuePair<int, Tuple<int, int, LinkedList<int>>> currentSolution;
            int currentCount;
            Tuple<int, int, LinkedList<int>> currentItem;

            while (toProcess.Count > 0) {
                currentSolution = toProcess.ElementAt(0);
                toProcess.RemoveAt(0);

                if (currentSolution.Value.Item1 < pyramid.Count - 1) {
                    //left
                    currentItem = pyramid[currentSolution.Value.Item1 + 1][currentSolution.Value.Item2];
                    currentCount = currentSolution.Key + currentItem.Item1;
                    if (currentCount > currentItem.Item2) {
                        LinkedList<int> newSolution = new LinkedList<int>(currentSolution.Value.Item3);
                        newSolution.AddLast(currentSolution.Value.Item2);
                        toProcess.Add(currentCount, new Tuple<int, int, LinkedList<int>>(currentSolution.Value.Item1 + 1, currentSolution.Value.Item2, newSolution));
                        pyramid[currentSolution.Value.Item1 + 1][currentSolution.Value.Item2] = new Tuple<int, int, LinkedList<int>>(currentItem.Item1, currentCount, newSolution);
                    }

                    //right
                    currentItem = pyramid[currentSolution.Value.Item1 + 1][currentSolution.Value.Item2 + 1];
                    currentCount = currentSolution.Key + currentItem.Item1;
                    if (currentCount > currentItem.Item2) {
                        LinkedList<int> newSolution = new LinkedList<int>(currentSolution.Value.Item3);
                        newSolution.AddLast(currentSolution.Value.Item2 + 1);
                        toProcess.Add(currentCount, new Tuple<int, int, LinkedList<int>>(currentSolution.Value.Item1 + 1, currentSolution.Value.Item2 + 1, newSolution));
                        pyramid[currentSolution.Value.Item1 + 1][currentSolution.Value.Item2 + 1] = new Tuple<int, int, LinkedList<int>>(currentItem.Item1, currentCount, newSolution);
                    }
                }
            }

            int highest = -1;
            LinkedList<int> highestPath = new LinkedList<int>();
            foreach (Tuple<int, int, LinkedList<int>> i in pyramid[pyramid.Count - 1]) {
                if (i.Item2 > highest) {
                    highest = i.Item2;
                    highestPath = i.Item3;
                }
            }

            return new KeyValuePair<int, LinkedList<int>>(highest, highestPath);
        }
    }
}
