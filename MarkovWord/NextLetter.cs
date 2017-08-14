using System;


namespace MarkovWord
{
    public class NextLetter
    {
        public const int WeightStartIndex = 3;
        public NextLetter()
        {
        }

        public NextLetter(string chunk, double previousCumulative)
        {
            var letter = chunk[0];
            var weight = double.Parse(chunk.Substring(WeightStartIndex, chunk.IndexOf("%", StringComparison.Ordinal)-WeightStartIndex));
            Initialize(letter.ToString(), weight, previousCumulative);
        }

        public void Initialize(string letter, double weight, double previousCumulative)
        {
            Letter = letter;
            Weight = weight;
            CumulativeWeight = previousCumulative + weight;
        }

        public string Letter { get; set; }

        public double Weight { get; set; }

        public double CumulativeWeight { get; set; }
    }
}
