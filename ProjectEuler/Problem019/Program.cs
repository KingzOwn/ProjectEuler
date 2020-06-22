using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem019 {
    class Program {
        static void Main(string[] args) {
            int sundays = 0;
            for (int i = 1901; i <= 2000; i++) {
                for (int j = 1; j < 13; j++) {
                    if (DateTime.Parse("1/" + j.ToString() + "/" + i.ToString()).DayOfWeek == DayOfWeek.Sunday) {
                        sundays++;
                    }
                }
            }
            Console.WriteLine(sundays);
            Console.ReadKey();
        }
    }
}
