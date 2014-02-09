using BusinessLogic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FootballResultsGenerator
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Generation started");

            var football = Generator.Generate();

            using (Stream stream = File.Open(@"C:\Users\Soft\Desktop\football.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, football);
            }

            Console.WriteLine("Generation completed");
            Console.WriteLine("Enter to leave.");
            Console.Read();
        }
    }
}