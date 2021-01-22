using System;
using System.Linq;
using System.Timers;

namespace Capstone___Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grand Circus -- Lab 2 -- Ramon Guarnes's Pig Latin: ");

            char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
            char[] constant = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            char checkFlag = 'y';

            while (checkFlag == 'y')
            {
                Console.WriteLine("\nEnter word to be translated: ");
                string word = Console.ReadLine();
                string[] origin = ValidWord(word).Split(' ');
                string translate = "";

                foreach (string s in origin)
                {
                    if (s.Any(char.IsDigit))
                    {
                        translate += s;
                        continue;
                    }
                    if (vowel.Contains(char.ToLower(s[0])))
                    {
                        translate = FirstVowel(translate, s);
                    }
                    if (constant.Contains(char.ToLower(s[0])))
                    {
                        translate = FirstConstant(vowel, translate, s);
                    }
                }

                Console.WriteLine("TRANSLATED: " + translate);
                Console.WriteLine("\nWould you like to try again? (y/n)");
                checkFlag = char.ToLower(Console.ReadLine()[0]);
            }
            Console.WriteLine("\nProgram quitting...");
        }

        private static string ValidWord(string word)
        {
            while (word == null || word == "")
            {
                Console.WriteLine("Invalid input. Try again.\n");
                Console.WriteLine("Enter word to be translated: ");
                word = Console.ReadLine();
            }
            return word;
        }

        private static string FirstVowel(string translate, string s)
        {
            translate += (s + "way ");
            return translate;
        }

        private static string FirstConstant(char[] vowel, string translate, string s)
        {
            int temp = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (vowel.Contains(s[i]))
                {
                    temp = i;
                    continue;
                }
            }
            if (temp != -1)
            {
                string another = s.Substring(temp) + s.Substring(0, temp);
                translate += (another + "ay ");
            }
            else
            {
                translate += (s + "ay ");
            }

            return translate;
        }

        
    }
}
