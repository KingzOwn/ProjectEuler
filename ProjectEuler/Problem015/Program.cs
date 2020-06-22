using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem015 {
    class Program {
        static BigInteger[] pathsTotal;

        static void Main(string[] args) {
            int size = 20;
            pathsTotal = new BigInteger[size];

            pathsTotal[size - 1] = CalculateGridSmart(20);

            Console.WriteLine(pathsTotal[size - 1]);
            Console.ReadKey();
        }

        static BigInteger CalculateGridBrute(int size) {
            
            for (int i = 1; i <= size; i++) {
                pathsTotal[i - 1] = CalculateGridBruteCalculate(i);
                Console.WriteLine(pathsTotal[i - 1]);
            }
            return pathsTotal[size - 1];
        }

        static BigInteger CalculateGridBruteCalculate(int size) {
            int[] grid = new int[size];
            BigInteger paths = 0;

            int i = size;
            while (grid[0] <= size) {
                i--;
                while (grid[i] < size) {
                    grid[i]++;
                    paths++;
                    if (grid[i] == i) {
                        paths += pathsTotal[i - (size - 1)] - 1;
                        for (int j = i; j < size; j++) {
                            grid[j] = size;
                        }
                        i = size - 1;
                    }
                }
                while (grid[i] == size && i != 0) {
                    i--;
                }
                grid[i]++;
                i++;
                paths++;
                for (; i < size; i++) {
                    grid[i] = grid[i - 1];
                }
            }

            return paths;
        }

        static BigInteger CalculateGridSmart(int size) {
            BigInteger[,] gridPaths = new BigInteger[size + 1, size + 1];

            for (int i = 0; i <= size; i++) {
                gridPaths[i, 0] = 1;
                gridPaths[0, i] = 1;
            }

            for (int i=1;i<=size;i++) {
                for (int j=1;j<=size;j++) {
                    gridPaths[i, j] = gridPaths[i - 1, j] + gridPaths[i,j - 1];
                }
            }

            return gridPaths[size, size];
        }

        static BigInteger CalculateGridBinomial(int size) {
            BigInteger paths = 1;

            for (int i = 1; i <= size; i++) {
                paths = paths * (size + i) / i;
            }
            return paths;
        }
    }
}
