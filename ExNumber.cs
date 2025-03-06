using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C_EX
{
    class ExNumber
    {
        public string ToRomain(int num)
        {
            if (num <= 0)
            {
                return string.Empty;
            }

            if (num < 1 || num > 99999)
            {
                throw new ArgumentOutOfRangeException("number", "the number must be between 1 and 3999.");
            }
            string[] simboli = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] valori = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            StringBuilder romano = new StringBuilder();

            for (int i = 0; i < simboli.Length; i++)
            {
                while (num >= valori[i])
                {
                    num -= valori[i];
                    romano.Append(simboli[i]); 
                }
            }

            return romano.ToString();
        }

        public bool IsPrime(int num)
        {
            if (num <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++) 
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
        public bool IsEven(int num)
        {
            try
            {
                bool v = (num % 2 == 0);
                return v;
            }
            catch
            {
                Console.WriteLine("Error");
                throw;
            }
        }
    }
}
