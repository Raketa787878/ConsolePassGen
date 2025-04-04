﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePassGen
{
    class GeneratePassword
    {
        public static string LastPassword = null;

        public static void PasswordSettings()
        {
            // Password length selection
            Console.Write("Enter length: ");
            int length = Convert.ToInt32(Console.ReadLine());
            if (length < 1)
            {
                Console.WriteLine("Error, the length cannot be less than one!");
                return;
            }

            // Choosing to include letters
            Console.Write("Include letters(Y/n): ");
            bool includeLetters = false;
            if (Console.ReadLine().ToLower() == "y")
            {
                includeLetters = true;
            }

            // Choosing to include special characters 
            Console.Write("Include special chars(Y/n): ");
            bool includeSpecialChars = false;
            if (Console.ReadLine().ToLower() == "y")
            {
                includeSpecialChars = true;
            }

            // Password generation function call
            string password = GeneratePass(length, includeLetters, includeSpecialChars);
            LastPassword = password;
            // Output of the result
            Console.WriteLine("Generated password is: " + password);
        }

        public static string GeneratePass(int length, bool includeLetters, bool includeSpecialChars)
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

                    switch (choice)
                    {
                        // Add random digit
                        case 0:
                            result.Append(digits[rand.Next(0, digits.Length)]);
                            break;

                        // Add random special character
                        case 1:
                            result.Append(specialChars[rand.Next(0, specialChars.Length)]);
                            break;

                        // Add random letter
                        case 2:
                            result.Append(letters[rand.Next(0, letters.Length)]);
                            break;
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
