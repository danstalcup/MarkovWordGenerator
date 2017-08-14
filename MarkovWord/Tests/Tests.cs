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
    }
}
