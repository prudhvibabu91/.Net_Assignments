using NUnit.Framework;
using Assignment11;

namespace Assignment11.Tests
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
        public void CharacterCountTest()
        {
            Assert.That(sf.CharacterCount("Hello World"), Is.EqualTo(11));
        }

        [Test]
        public void IsPalindromeTest()
        {
            Assert.That(sf.IsPalindrome("Madam"), Is.True);
            Assert.That(sf.IsPalindrome("World"), Is.False);
        }

        [Test]
        public void ReverseSentenceTest()
        {
            Assert.That(sf.ReverseSentence("Hello World"), Is.EqualTo("dlroW olleH"));
        }

        [Test]
        public void AnalyzeStringTest()
        {
            var result = sf.AnalyzeString("Hello123!@#");
            Assert.That(result.vowels, Is.EqualTo(2));
            Assert.That(result.consonants, Is.EqualTo(3));
            Assert.That(result.digits, Is.EqualTo(3));
            Assert.That(result.specialChars, Is.EqualTo(3));
        }

        [Test]
        public void ToUpperCaseTest()
        {
            Assert.That(sf.ToUpperCase("hello"), Is.EqualTo("HELLO"));
        }

        [Test]
        public void ToProperCaseTest()
        {
            Assert.That(sf.ToProperCase("hello world"), Is.EqualTo("Hello World"));
        }

        [Test]
        public void CombineSentencesTest()
        {
            Assert.That(sf.CombineSentences("Hello", "World"), Is.EqualTo("Hello World"));
        }

        [Test]
        public void RemoveExtraSpacesTest()
        {
            Assert.That(sf.RemoveExtraSpaces("  Hello   World  "), Is.EqualTo("Hello World"));
        }

        [Test]
        public void WordCountTest()
        {
            Assert.That(sf.WordCount("Hello World"), Is.EqualTo(2));
        }

        [Test]
        public void ContainsSubstringTest()
        {
            Assert.That(sf.ContainsSubstring("Hello World", "World"), Is.True);
        }

        [Test]
        public void SubstringOccurrencesTest()
        {
            Assert.That(sf.SubstringOccurrences("Hello World, Hello Again", "Hello"), Is.EqualTo(2));
        }
    }
}
