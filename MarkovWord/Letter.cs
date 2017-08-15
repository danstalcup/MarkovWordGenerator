using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MarkovWord
{
    public class Letter
    {
        public string CoreLetter { get; set; }
        public List<NextLetter> NextLetters { get; set; }

        public double TotalWeight => NextLetters.Count > 0 ? NextLetters.Sum(nl => nl.Weight) : 0;

        public string[] Chunks { get; set; }

        public Letter(string line)
        {
            Chunks = line.Split(',');
            CoreLetter = Chunks[0][0].ToString();
            ProcessNextLetters();
        }

        private void ProcessNextLetters()
        {            
            foreach (var chunk in Chunks.Skip(1))
            {
                ProcessNextLetterChunk(chunk);
            }
        }

        private void ProcessNextLetterChunk(string chunk)
        {
            if (NextLetters == null)
            {
                NextLetters = new List<NextLetter>();
                NextLetters.Add(new NextLetter(chunk, 0));
            }
            else
            {
                NextLetters.Add(new NextLetter(chunk, NextLetters.Last().CumulativeWeight));
            }
        }

        public NextLetter NextLetter(double weight)
        {
            return NextLetters.FirstOrDefault(nl => nl.CumulativeWeight > weight);
        }        
    }
}
