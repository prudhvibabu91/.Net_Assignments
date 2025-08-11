using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assignment12;

namespace Assignment12.Tests
{
    public class StringFunctionsTests
    {
        private StringFunctions sf;

        [SetUp]
        public void Setup()
        {
            sf = new StringFunctions();
        }

        [Test]
        public void CharacterCount_HelloWorld_Returns11()
        {
            Assert.That(sf.CharacterCount("Hello World"), Is.EqualTo(11));
        }

        [Test]
        public void IsPalindrome_Madam_ReturnsTrue()
        {
            Assert.That(sf.IsPalindrome("Madam"), Is.True);
        }

        [Test]
        public void IsPalindrome_Manav_ReturnsFalse()
        {
            Assert.That(sf.IsPalindrome("manav"), Is.False);
        }

        [Test]
        public void ReverseSentence_ThisIsABook_ReturnskooBAsIsihT()
        {
            Assert.That(sf.ReverseSentence("this is a book"), Is.EqualTo("koob a si siht"));
        }

        [Test]
        public void AnalyzeString_MixedInput_ReturnsCorrectCounts()
        {
            var result = sf.AnalyzeString("Hello123@!");
            Assert.That(result.vowels, Is.EqualTo(2));
            Assert.That(result.consonants, Is.EqualTo(3));
            Assert.That(result.digits, Is.EqualTo(3));
            Assert.That(result.specialChars, Is.EqualTo(2));
        }

        [Test]
        public void ToUpperCase_Hello_ReturnsHELLO()
        {
            Assert.That(sf.ToUpperCase("hello"), Is.EqualTo("HELLO"));
        }

        [Test]
        public void ToProperCase_HelloWorld_ReturnsHelloWorld()
        {
            Assert.That(sf.ToProperCase("hello world"), Is.EqualTo("Hello World"));
        }

        [Test]
        public void CombineSentences_ReturnsCombined()
        {
            Assert.That(sf.CombineSentences("Hello", "World"), Is.EqualTo("Hello World"));
        }

        [Test]
        public void RemoveExtraSpaces_RemovesAllExtras()
        {
            Assert.That(sf.RemoveExtraSpaces("  Hello   World  "), Is.EqualTo("Hello World"));
        }

        [Test]
        public void WordCount_ValidSentence_Returns2()
        {
            Assert.That(sf.WordCount("Hello World"), Is.EqualTo(2));
        }

        [Test]
        public void ContainsSubstring_Found_ReturnsTrue()
        {
            Assert.That(sf.ContainsSubstring("This is a test", "test"), Is.True);
        }

        [Test]
        public void SubstringOccurrences_TwoTimes_Returns2()
        {
            Assert.That(sf.SubstringOccurrences("Hello Hello World", "Hello"), Is.EqualTo(2));
        }
    }
}