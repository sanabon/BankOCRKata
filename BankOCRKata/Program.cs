using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOCR;

namespace BankOCRKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingeniousMachine = new IngeniousMachine();

            Console.WriteLine("Enter file name:");
            var fileName = Console.ReadLine();

            try
            {
                var results = ingeniousMachine.Translate(fileName);

                foreach (var r in results)
                {
                    Console.WriteLine(string.Format("{0} {1}", r.Item2, r.Item3));
                }
            }
            catch (System.IO.IOException) 
            {
                Console.WriteLine("Cannot open file {0}", fileName);
            }

            Console.ReadLine();
        }
    }
}
