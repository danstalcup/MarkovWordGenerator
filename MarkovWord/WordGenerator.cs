using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovWord
{
    public class WordGenerator
    {
        public string DataFilepath { get; set; }

        public Corpus Corpus { get; set; }        

        public Random Random { get; set; }

        public const int NoSeed = -1;        

        public WordGenerator()
        { }

        public WordGenerator(string dataFilepath)
        {
            DataFilepath = dataFilepath;
            Initialize();
        }

        public void Initialize(int seed = NoSeed)
        {
            Corpus = new Corpus(DataFilepath);
            Random = seed == NoSeed ? new Random() : new Random(seed);            
        }

        public string GetWords(int count=1)
        {
            var words = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                words.Append(GetWord() + "\n");
            }
            return words.ToString();
        }

        public string GetWord()
        {
            var word = new StringBuilder();
            var nextLetter = Corpus.GetFirstLetter(Random.NextDouble() * Corpus.FirstLetterTotalWeight);
            while (nextLetter.Letter != " ")
            {
                word.Append(nextLetter.Letter);
                var currentLetter = Corpus.GetLetter(nextLetter.Letter);
                nextLetter = NextLetterInWord(currentLetter);
            }

            return word.ToString();
        }

        private NextLetter NextLetterInWord(Letter currentLetter)
        {
            return currentLetter.NextLetter(Random.NextDouble() * currentLetter.TotalWeight);
        }
    }
}
