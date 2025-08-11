using System;
using System.Globalization;
using System.Linq;
namespace Assignment10_Q2
{
    public static class StringExtensions
    {
        public static void CharacterCount(this string str)
        {
            Console.WriteLine("Character Count: " + str.Length);
        }

        public static void IsPalindrome(this string str)
        {
            string clean = str.Replace(" ", "").ToLower();
            string reversed = new string(clean.Reverse().ToArray());
            Console.WriteLine(clean == reversed ? "Palindrome" : "Not Palindrome");
        }

        public static void ReverseSentence(this string str)
        {
            string reversed = new string(str.Reverse().ToArray());
            Console.WriteLine("Reversed: " + reversed);
        }

        public static void CountTypes(this string str)
        {
            int vowels = 0, consonants = 0, digits = 0, special = 0;
            foreach (char c in str.ToLower())
            {
                if ("aeiou".Contains(c)) vowels++;
                else if (char.IsLetter(c)) consonants++;
                else if (char.IsDigit(c)) digits++;
                else if (!char.IsWhiteSpace(c)) special++;
            }
            Console.WriteLine("Vowels: " + vowels);
            Console.WriteLine("Consonants: " + consonants);
            Console.WriteLine("Digits: " + digits);
            Console.WriteLine("Special Characters: " + special);
        }

        public static void ToUpperCase(this string str)
        {
            Console.WriteLine("Uppercase: " + str.ToUpper());
        }

        public static void ToProperCase(this string str)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            Console.WriteLine("Proper Case: " + ti.ToTitleCase(str.ToLower()));
        }

        public static void CombineWith(this string str1, string str2)
        {
            Console.WriteLine("Combined: " + (str1 + " " + str2));
        }

        public static void RemoveExtraSpaces(this string str)
        {
            string cleaned = string.Join(" ", str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine("Cleaned: " + cleaned);
        }

        public static void WordCount(this string str)
        {
            int count = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine("Word Count: " + count);
        }

        public static void ContainsSubstring(this string str, string sub)
        {
            Console.WriteLine(str.Contains(sub) ? "Substring found" : "Substring not found");
        }

        public static void CountOccurrences(this string str, string sub)
        {
            int count = 0, index = 0;
            while ((index = str.IndexOf(sub, index)) != -1)
            {
                count++;
                index += sub.Length;
            }
            Console.WriteLine("Occurrences: " + count);
        }
    }

    public class Program
    {
        public static void Main()
        {
            string sentence1 = "This is a test sentence.";
            string sentence2 = "   Another   sentence with  extra spaces!  ";

            sentence1.CharacterCount();
            sentence1.IsPalindrome();
            sentence1.ReverseSentence();
            sentence1.CountTypes();
            sentence1.ToUpperCase();
            sentence1.ToProperCase();
            sentence1.CombineWith("Appended here.");
            sentence2.RemoveExtraSpaces();
            sentence1.WordCount();
            sentence1.ContainsSubstring("test");
            sentence1.CountOccurrences("e");
        }
    }
}
