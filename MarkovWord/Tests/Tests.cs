using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace MarkovWord.Tests
{
    [TestFixture]
    class Tests
    {
        [TestCase(" ")]
        [TestCase("c")]
        [TestCase("v")]
        [TestCase("r")]
        [TestCase("e")]
        public void Letter_Constructor_CorrectCoreLetter(string firstLetter)
        {
            // Act
            var letter = new Letter(firstLetter);

            //Assert
            Assert.That(letter.CoreLetter, Is.EqualTo(firstLetter));
        }

        [Test]
        public void Corpus_GetLetter_NullIfNoLetter()
        {
            // Act
            var letter = new Corpus().GetLetter("a");

            // Assert
            Assert.That(letter, Is.Null);
        }

        [Test]
        public void Corpus_GetLetter_ExistsAndMathcingCoreLetter()
        {
            // Arrange
            var corpus = new Corpus();
            corpus.Letters = new List<Letter>() {new Letter("a")};

            // Act
            var letter = corpus.GetLetter("a");

            // Assert
            Assert.That(letter, Is.Not.Null);
            Assert.That(letter.CoreLetter, Is.EqualTo("a"));
        }

        [Test]
        public void NextLetter_Initialize_CorrectLetterWeightCumulative()
        {
            // Arrange
            var nextLetter = new NextLetter();

            // Act
            nextLetter.Initialize("a",.4,.5);

            // Assert
            Assert.That(nextLetter.Letter,Is.EqualTo("a"));
            Assert.That(nextLetter.Weight, Is.EqualTo(.4));
            Assert.That(nextLetter.CumulativeWeight, Is.EqualTo(.9));
        }

        [Test]
        public void NextLetter_Constructor_CorrectLetterWeightCumulative()
        {
            // Act
            var nextLetter = new NextLetter("a [0.4%]",0.5);

            // Assert
            Assert.That(nextLetter.Letter, Is.EqualTo("a"));
            Assert.That(nextLetter.Weight, Is.EqualTo(.4));
            Assert.That(nextLetter.CumulativeWeight, Is.EqualTo(.9));
        }

        [Test]
        public void Letter_Constructor_CorrectNextLetters()
        {
            // Act
            var letter = new Letter("e,x [0.5%],a [0.4%]");
            var nextLetterX = letter.NextLetters[0];
            var nextLetterA = letter.NextLetters[1];            

            // Assert
            Assert.That(letter.NextLetters.Count == 2);

            Assert.That(nextLetterX.Letter, Is.EqualTo("x"));
            Assert.That(nextLetterX.Weight, Is.EqualTo(.5));
            Assert.That(nextLetterX.CumulativeWeight, Is.EqualTo(.5));

            Assert.That(nextLetterA.Letter, Is.EqualTo("a"));
            Assert.That(nextLetterA.Weight, Is.EqualTo(.4));
            Assert.That(nextLetterA.CumulativeWeight, Is.EqualTo(.9));
        }

        [Test]
        public void Corpus_ProcessLinesToLetters_ProcessesInCorrectOrder()
        {
            // Arrange
            var rawData = new string[]
            {
                "dummy",
                "e,x [0.5%],a [0.4%]",
                "s,p [0.3%],a [0.2%],j [5.1%]"
            };
            var corpus = new Corpus {RawData = rawData};

            // Act
            corpus.ProcessLinesToLetters();

            // Assert
            Assert.That(corpus.Letters.Count, Is.EqualTo(2));
            Assert.That(corpus.Letters[0].CoreLetter, Is.EqualTo("e"));
            Assert.That(corpus.Letters[1].CoreLetter, Is.EqualTo("s"));
        }

        [TestCase(0, "p")]
        [TestCase(4.9, "p")]
        [TestCase(5, "a")]
        [TestCase(12.4, "a")]
        [TestCase(12.5, "j")]
        [TestCase(21.4, "j")]        
        public void Letter_NextLetter_CorrectLetterGivenWeight(double weight, string expected)
        {
            // Act
            var nextLetter = new Letter("s,p [5.0%],a [7.5%],j [9.0%]").NextLetter(weight);

            // Assert
            Assert.That(nextLetter.Letter, Is.EqualTo(expected));
        }

        [Test]
        public void Letter_NextLetter_NoLetterGivenTooLargeWeight()
        {
            // Act
            var nextLetter = new Letter("s,p [5.0%],a [7.5%],j [9.0%]").NextLetter(21.5);

            // Assert
            Assert.That(nextLetter, Is.Null);
        }

        [TestCase(0, "p")]
        [TestCase(4.9, "p")]
        [TestCase(5, "a")]
        [TestCase(12.4, "a")]
        [TestCase(12.5, "j")]
        [TestCase(21.4, "j")]
        public void Corpus_FirstLetter_CorrectLetterGivenWeight(double weight, string expected)
        {
            // Arrange
            var rawData = new string[]
            {
                "dummy",
                "e,x [0.5%],a [0.4%]",
                " ,p [5.0%],a [7.5%],j [9.0%]"
            };
            var corpus = new Corpus { RawData = rawData };
            corpus.ProcessLinesToLetters();

            // Act
            var result = corpus.GetFirstLetter(weight);

            // Assert
            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
