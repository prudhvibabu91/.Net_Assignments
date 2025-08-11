using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Assignment12
    {
        public class StringFunctions
        {
            public int CharacterCount(string input) => input.Length;

            public bool IsPalindrome(string input)
            {
                string cleaned = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();
                return cleaned == new string(cleaned.Reverse().ToArray());
            }

            public string ReverseSentence(string input) =>
                new string(input.Reverse().ToArray());

            public (int vowels, int consonants, int digits, int specialChars) AnalyzeString(string input)
            {
                int vowels = 0, consonants = 0, digits = 0, special = 0;
                string vowelSet = "aeiou";

                foreach (char c in input.ToLower())
                {
                    if (char.IsLetter(c))
                    {
                        if (vowelSet.Contains(c)) vowels++;
                        else consonants++;
                    }
                    else if (char.IsDigit(c)) digits++;
                    else if (!char.IsWhiteSpace(c)) special++;
                }
                return (vowels, consonants, digits, special);
            }

            public string ToUpperCase(string input) => input.ToUpper();

            public string ToProperCase(string input) =>
                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());

            public string CombineSentences(string s1, string s2) => $"{s1} {s2}".Trim();

            public string RemoveExtraSpaces(string input) =>
                string.Join(" ", input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        public int WordCount(string input) =>
            input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;

            public bool ContainsSubstring(string sentence, string word) =>
                sentence.Contains(word, StringComparison.OrdinalIgnoreCase);

            public int SubstringOccurrences(string sentence, string word)
            {
                int count = 0, index = 0;
                while ((index = sentence.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    count++;
                    index += word.Length;
                }
                return count;
            }
        }
    }
