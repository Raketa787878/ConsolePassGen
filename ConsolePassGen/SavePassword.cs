using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePassGen
{
    class SavePassword
    {
        public static void Save()
        {
            using(FileStream stream = new FileStream("Password.txt", FileMode.OpenOrCreate))
            {
                try
                {
                    byte[] buffer = Encoding.Default.GetBytes(GeneratePassword.LastPassword);
                    stream.Write(buffer, 0, buffer.Length);

                    Console.WriteLine("Password is saved to: " + stream.Name);
                }
                catch
                {
                    Console.WriteLine("Error password is not saved");
                }
            }
        }
    }
}
