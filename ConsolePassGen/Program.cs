using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePassGen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Password length selection
            Console.Write("Enter length: ");
            int length = Convert.ToInt32(Console.ReadLine());

            // Choosing to include letters
            Console.Write("Include letters(Y/n): ");
            bool includeLetters = false;
            if (Console.ReadLine() == "Y")
            {
                includeLetters = true;
            }

            // Choosing to include special characters 
            Console.Write("Include special chars(Y/n): ");
            bool includeSpecialChars = false;
            if (Console.ReadLine() == "Y")
            {
                includeSpecialChars = true;
            }

            // Password generation function call
            string password = GeneratePass(length, includeLetters, includeSpecialChars);
            // Output of the result
            Console.WriteLine(password);
        }

        static string GeneratePass(int length, bool includeLetters, bool includeSpecialChars)
        {
            // Define character sets
            const string digits = "0123456789";
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            // Initialize String Builder
            StringBuilder result = new StringBuilder();
            // Initialize Random
            Random rand = new Random();

            // Generate each character of the password
            for (int i = 0; i < length; i++)
            {
                // When both letters and special characters are enabled
                if (includeLetters && includeSpecialChars)
                {
                    // Randomly select character type (0=digit, 1=special, 2=letter)
                    byte choice = Convert.ToByte(rand.Next(0, 3));

                    // Add random digit
                    if (choice == 0)
                    {
                        result.Append(digits[rand.Next(0, digits.Length)]);
                    }

                    // Add random special character
                    else if (choice == 1)
                    {
                        result.Append(specialChars[rand.Next(0, specialChars.Length)]);
                    }

                    // Add random letter
                    else
                    {
                        result.Append(letters[rand.Next(0, letters.Length)]);
                    }
                }

                // When letters are enabled
                else if (includeLetters)
                {
                    // 50/50 chance to add letter or digit
                    bool let = Convert.ToBoolean(rand.Next(0, 2));

                    // Add random letter
                    if (let)
                    {
                        result.Append(letters[rand.Next(0, letters.Length)]);
                    }

                    // Add random digit
                    else
                    {
                        result.Append(digits[rand.Next(0, digits.Length)]);
                    }
                }

                // When special characters enabled
                else if (includeSpecialChars)
                {
                    // 50/50 chance to add special character or digit
                    bool chars = Convert.ToBoolean(rand.Next(0, 2));

                    // Add random special character
                    if (chars)
                    {
                        result.Append(specialChars[rand.Next(0, specialChars.Length)]);
                    }

                    // Add random digit
                    else
                    {
                        result.Append(digits[rand.Next(0, digits.Length)]);
                    }
                }

                // Default (Only digits)
                else
                {
                    // Add random digit
                    result.Append(digits[rand.Next(0, digits.Length)]);
                }
            }

            // Return password
            return result.ToString();
        }
    }
}
