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

            Console.Write("Include letters(Y/n): ");
            bool includeLetters = false;
            if (Console.ReadLine() == "Y")
            {
                includeLetters = true;
            }

            //Console.Write("Include special chars(Y/n): ");
            bool includeSpecialChars = false;
            //if (Console.ReadLine() == "Y")
            //{
            //    includeSpecialChars = true;
            //}

            string password = GeneratePass(length, includeLetters, includeSpecialChars);
            Console.WriteLine(password);
        }

        static string GeneratePass(int length, bool includeLetters, bool includeSpecialChars)
        {
            const string digits = "0123456789";
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            StringBuilder result = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < length; i++)
            {
                if (includeLetters)
                {
                    bool let = Convert.ToBoolean(rand.Next(0, 2));
                    if (let)
                    {
                        result.Append(letters[rand.Next(0, 52)]);
                    }
                    else
                    {
                        result.Append(digits[rand.Next(0, 10)]);
                    }
                }
                //else if (includeSpecialChars)
                //{

                //}
                //else if (includeLetters && includeSpecialChars)
                //{

                //}
                else
                {
                    result.Append(digits[rand.Next(0, 9)]);
                }
            }

            // Return password
            return result.ToString();
        }
    }
}
