using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovWord
{
    public class Corpus
    {
        public List<Letter> Letters { get; set; }
        public string[] RawData { get; set; }

        public Corpus()
        {
            Letters = new List<Letter>();
        }

        public Corpus(string filepath)
        {
            RawData = System.IO.File.ReadAllLines(filepath);
            ProcessLinesToLetters();
        }

        private void ProcessLinesToLetters()
        {
            Letters = RawData.Skip(1).Select(line => new Letter(line)).ToList();
        }

        public Corpus(string[] lines)
        {
            RawData = lines;
            ProcessLinesToLetters();
        }

        public StringBuilder StartWord()
        {
            return new StringBuilder(GetFirstLetter());
        }

        public string GetFirstLetter()
        {
            return string.Empty;
        }

        public Letter GetLetter(string letter)
        {
            return Letters.SingleOrDefault(l => l.CoreLetter == letter);
        }
    }
}