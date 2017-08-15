using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "letterprobabilities.csv";
            int seed = WordGenerator.NoSeed;
            int numWords = 10;

            if (args.Length >= 1)
            {
                numWords = int.Parse(args[0]);
            }
            if (args.Length >= 2)
            {
                seed = int.Parse(args[1]);
            }
            if (args.Length >= 3)
            {
                filename = args[2];
            }

            var engine = new WordGenerator(filename);
            engine.Initialize(seed);

            Console.WriteLine(engine.GetWords(numWords));

        }
    }
}
