using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment11
{
    public class StringFunctions
    {
        public int CharacterCount(string sentence) => sentence.Length;

        public bool IsPalindrome(string sentence)
        {
            var cleaned = new string(sentence.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleaned == new string(cleaned.Reverse().ToArray());
        }

        public string ReverseSentence(string sentence) =>
            new string(sentence.Reverse().ToArray());

        public (int vowels, int consonants, int digits, int specialChars) AnalyzeString(string sentence)
        {
            int vowels = 0, consonants = 0, digits = 0, special = 0;
            foreach (char c in sentence.ToLower())
            {
                if ("aeiou".Contains(c)) vowels++;
                else if (char.IsLetter(c)) consonants++;
                else if (char.IsDigit(c)) digits++;
                else if (!char.IsWhiteSpace(c)) special++;
            }
            return (vowels, consonants, digits, special);
        }

        public string ToUpperCase(string sentence) => sentence.ToUpper();

        public string ToProperCase(string sentence) =>
            string.Join(" ", sentence.Split(' ').Where(s => s != "")
                .Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));

        public string CombineSentences(string s1, string s2) => s1 + " " + s2;

        public string RemoveExtraSpaces(string sentence) =>
            Regex.Replace(sentence.Trim(), @"\s+", " ");

        public int WordCount(string sentence) =>
            sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

        public bool ContainsSubstring(string sentence, string substring) =>
            sentence.Contains(substring);

        public int SubstringOccurrences(string sentence, string substring) =>
            Regex.Matches(sentence, Regex.Escape(substring), RegexOptions.IgnoreCase).Count;
    }
}
