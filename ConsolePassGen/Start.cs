using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePassGen
{
    class Start
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Generate Password");
                Console.WriteLine("2. Save Password in file");
                Console.WriteLine("3. Exit");

                byte choice = Convert.ToByte(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        GeneratePassword.PasswordSettings();
                        break;

                    case 2:
                        SavePassword.Save();
                        break;

                    case 3:
                        return;
                }
            }
        }
    }
}
