using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePassGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            string password = GeneratePass(length);
            Console.WriteLine(password);
        }

        static string GeneratePass(int length)
        {
            StringBuilder result = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(Convert.ToString(rand.Next(0, 9)));
            }

            return result.ToString();
        }
    }
}
