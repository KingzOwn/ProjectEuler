using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem017 {
    class Program {
        static void Main(string[] args) {
            int count = 0;
            for (int i=1;i<=1000;i++) {
                count += ConvertNumberToString(i).Length;
                Console.WriteLine(ConvertNumberToString(i));
            }
            Console.WriteLine(count);
            Console.ReadKey();

        }

        static string ConvertNumberToString(int number) {
            
            switch(number) {
                case 0:
                    return "";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                case 20:
                    return "twenty";
                case 30:
                    return "thirty";
                case 40:
                    return "forty";
                case 50:
                    return "fifty";
                case 60:
                    return "sixty";
                case 70:
                    return "seventy";
                case 80:
                    return "eighty";
                case 90:
                    return "ninety";
                case 100:
                    return "onehundred";
                case 1000:
                    return "onethousand";
            }
            string line = number.ToString();
            if (number > 100) {
                string current = ConvertNumberToString(int.Parse(line.Substring(0, 1))) + "hundred";
                string tens = ConvertNumberToString(int.Parse(line.Substring(1, 2)));
                if (tens != "") {
                    current += "and" + tens;
                }
                return current;
            }
            else {
                return ConvertNumberToString(int.Parse(line.Substring(0, 1)) * 10) + ConvertNumberToString(int.Parse(line.Substring(1, 1)));
            }
        }
    }
}
