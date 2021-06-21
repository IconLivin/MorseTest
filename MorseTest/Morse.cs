using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseTest
{
    class Morse
    {
        public static IDictionary<string, string> MorseCodeDictionary =
            new Dictionary<string, string>() {
                { ".-", "A"},
                { "-...", "B"},
                { "-.-.", "C"},
                { "-..", "D"},
                { ".", "E"},
                { "..-.", "F"},
                { "--.", "G"},
                { "....", "H"},
                { "..", "I"},
                { ".---", "J"},
                { "-.-", "K"},
                { ".-..", "L"},
                { "--", "M"},
                { "-.", "N"},
                { "---", "O"},
                { ".--.", "P"},
                { "--.-", "Q"},
                { ".-.", "R"},
                { "...", "S"},
                { "-", "T"},
                { "..-", "U"},
                { "...-", "V"},
                { ".--", "W"},
                { "-..-", "X"},
                { "-.--", "Y"},
                { "--..", "Z"},
            };
        public static IDictionary<string, string> LetterToMorseCodeDictionary =
            new Dictionary<string, string>() {
                { "A", ".-" },
                { "B", "-..."},
                { "C", "-.-."},
                { "D", "-.."},
                { "E", "."},
                { "F", "..-."},
                { "G", "--."},
                { "H", "...."},
                { "I", ".."},
                { "J", ".---"},
                { "K", "-.-"},
                { "L", ".-.."},
                { "M", "--"},
                { "N", "-."},
                { "O", "---"},
                { "P", ".--."},
                { "Q", "--.-"},
                { "R", ".-."},
                { "S", "..."},
                { "T", "-"},
                { "U", "..-"},
                { "V", "...-" },
                { "W", ".--"},
                { "X", "-..-"},
                { "Y", "-.--"},
                { "Z", "--.."}
            };

        public static string MorseDecoder(string encoded_message)
        {
            if (encoded_message.Length == 0)
            {
                throw new ArgumentException("Empty message is passed");
            }

            string result = "";

            foreach (string word in encoded_message.Split(new string[] { "   " }, StringSplitOptions.None)){
                foreach(string letter in word.Split(' '))
                {
                    if (letter.Length == 0)
                    {
                        throw new ArgumentException("Empty letter is found");
                    }

                    result = MorseCodeDictionary.ContainsKey(letter) ? result + MorseCodeDictionary[letter] : result + "*";
                }
                result += " ";
            }

            return result.Substring(0, result.Length - 1);
        }

        public static string MorseEncoder(string to_encode_mesage)
        {
            string result = "";
            foreach (string word in to_encode_mesage.ToUpper().Split(' '))
            {
                foreach(char letter in word)
                {
                    result = LetterToMorseCodeDictionary.ContainsKey(letter.ToString()) ? result + LetterToMorseCodeDictionary[letter.ToString()] : result + "-----";
                    result += " ";
                }
                result += "  ";
            }
            return result.Substring(0,result.Length - 3);
        }
    }
}
