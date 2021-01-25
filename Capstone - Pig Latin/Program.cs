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

            //ARRAYS TO HOLD VOWELS AND CONSTANTS
            char[] vowel = { 'a', 'e', 'i', 'o', 'u' };
            char[] constant = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            //WHILE LOOP CHECKER
            char checkFlag = 'y';

            while (checkFlag == 'y')
            {
                //ASK FOR USER INPUT
                Console.WriteLine("\nEnter word to be translated: ");
                string word = Console.ReadLine();
                //VALIDATE THAT IT IS NOT NULL
                string[] origin = ValidWord(word).Split(' ');   //SPLIT SENTENCE BY SPACE
                string translate = "";                          //STORE RESULT IN THIS STRING VARIABLE

                foreach (string s in origin)
                {
                    //IF DIGIT, SKIP
                    if (s.Any(char.IsDigit))
                    {
                        translate += s;
                        continue;
                    }
                    //DETECT VOWEL FIRST INDEX
                    if (vowel.Contains(char.ToLower(s[0])))
                    {
                        translate = FirstVowel(translate, s);
                    }
                    //DETECT CONSTANT FIRST INDEX
                    if (constant.Contains(char.ToLower(s[0])))
                    {
                        translate = FirstConstant(vowel, translate, s);
                    }
                }
                //PRINT PIG LATIN TRANSLATION
                Console.WriteLine("TRANSLATED: " + translate);
                //ASK USER TO TRY AGAIN
                Console.WriteLine("\nWould you like to try again? (y/n)");
                checkFlag = char.ToLower(Console.ReadLine()[0]);
            }
            //QUITTING
            Console.WriteLine("\nProgram quitting...");
        }

        //IF WORD IS NULL OR EMPTY, PROMPT USER TO INPUT AGAIN
        //RETURN WORD ONCE VALID INPUT
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

        //RETURN PASSED STRING + 'WAY'
        private static string FirstVowel(string translate, string s)
        {
            translate += (s + "way ");
            return translate;
        }

        //PUT ALL CHARACTERS BEFORE FIRST OCCURED VOWEL AT END OF WORD, THEN + 'AY'
        //RETURN STRING
        private static string FirstConstant(char[] vowel, string translate, string s)
        {
            int temp = s.IndexOfAny(vowel);
            /*for (int i = 0; i < s.Length; i++)
            {
                if (vowel.Contains(s[i]))
                {
                    temp = i;
                    continue;
                }
            }*/

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
