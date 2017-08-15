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

        public WordGenerator()
        { }

        public WordGenerator(string dataFilepath)
        {
            DataFilepath = dataFilepath;
            Initialize();
        }

        public void Initialize()
        {
            Corpus = new Corpus(DataFilepath);            
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
            throw new NotImplementedException();
        }
    }
}
