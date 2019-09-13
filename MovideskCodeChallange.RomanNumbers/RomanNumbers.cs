using System;
using System.Collections.Generic;
using System.Text;

namespace MovideskCodeChallenge.RomanNumbers
{
    public class RomanNumbers
    {
        public static Dictionary<int, string> Units { get; set; }
        public static Dictionary<int, string> Dozens { get; set; }
        public static Dictionary<int, string> Hundreds { get; set; }
        public static Dictionary<int, string> Thousands { get; set; }

        static RomanNumbers()
        {
            Units = new Dictionary<int, string>
            {
                {0, ""},
                {1, "I"},
                {2, "II"},
                {3, "III"},
                {4, "IV"},
                {5, "V"},
                {6, "VI"},
                {7, "VII"},
                {8, "VIII"},
                {9, "IX"}
            };

            Dozens = new Dictionary<int, string>
            {
                {0, ""},
                {10, "X"},
                {20, "XX"},
                {30, "XXX"},
                {40, "XL"},
                {50, "L"},
                {60, "LX"},
                {70, "LXX"},
                {80, "LXXX"},
                {90, "XC"}
            };

            Hundreds = new Dictionary<int, string>
            {
                {0, ""},
                {100, "C"},
                {200, "CC"},
                {300, "CCC"},
                {400, "CD"},
                {500, "D"},
                {600, "DC"},
                {700, "DCC"},
                {800, "DCCC"},
                {900, "CM"}
            };

            Thousands = new Dictionary<int, string> {{1000, "M"}};
        }

        public static string ToRomanNumbers(int number)
        {
            var romanNumber = "";

            if (number < 1 || number > 1000)
                throw new ArgumentException($"O número informado ({number}) está fora dos limites.");

            if (number == 1000)
            {
                romanNumber = Thousands[1000];
            }
            else
            {
                var hundred = Convert.ToInt32(Math.Floor(number / 100m));
                number -= hundred * 100;

                var dozens = Convert.ToInt32(Math.Floor(number / 10m));
                number -= dozens * 10;

                var unit = number;

                var stringBuilder = new StringBuilder(romanNumber);
                stringBuilder.Append(Hundreds[hundred*100]);
                stringBuilder.Append(Dozens[dozens*10]);
                stringBuilder.Append(Units[unit]);

                romanNumber = stringBuilder.ToString();
            }
            
            return romanNumber;
        }
    }
}