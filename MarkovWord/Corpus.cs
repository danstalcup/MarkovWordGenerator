using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovWord
{
    public class Corpus
    {
        public List<Letter> Letters { get; set; }
        public string[] RawData { get; set; }
        public double FirstLetterTotalWeight => GetLetter(" ").TotalWeight;

        public Corpus()
        {
            Letters = new List<Letter>();
        }

        public Corpus(string filepath)
        {
            RawData = System.IO.File.ReadAllLines(filepath);
            ProcessLinesToLetters();
        }

        public void ProcessLinesToLetters()
        {
            Letters = RawData.Skip(1).Select(line => new Letter(line)).ToList();
        }

        public Corpus(string[] lines)
        {
            RawData = lines;
            ProcessLinesToLetters();
        }

        public StringBuilder StartWord(double weight)
        {
            return new StringBuilder(GetFirstLetter(weight).Letter);
        }

        public NextLetter GetFirstLetter(double weight)
        {
            return GetLetter(" ").NextLetter(weight);
        }

        public Letter GetLetter(string letter)
        {
            return Letters.SingleOrDefault(l => l.CoreLetter == letter);
        }
    }
}