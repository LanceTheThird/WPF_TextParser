using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextParser.Services
{
    class TextParserService
    {
        public string Parse(string text)
        {
            string result = String.Empty;
            string delimiter = String.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                if ((!Regex.IsMatch(text[i].ToString(), "^\\d{1}$")) &&
                        (!Regex.IsMatch(text[i].ToString(), @"[а-я]$")) &&
                        (!Regex.IsMatch(text[i].ToString(), @"[a-z]$")))
                {
                    // Если это не цифра и не буква латинского алфавита или кириллицы, то это будет наш разделитель
                    delimiter = text[i].ToString();
                    //Предположим, что в задании подразумевается, что символ-разделитель всего один и выйдем из цикла
                    break;
                }
            }
            string[] words;
            //Выделим перенос строки как разделитель тоже
            if (delimiter != String.Empty)
            {
                char[] delimiters = new char[] { delimiter.ToCharArray()[0], '\r', '\n' };
                words = text.Split(delimiters);
            }
            else
            {
                words = new string[1] {text};
            }
            string[] buffer = new string[words.Length];

            for (int j = 0; j < words.Length; j++)
            {
                if (!buffer.Contains(words[j]) && (words[j] != String.Empty))
                {
                    result += words[j] + " occures " + Regex.Matches(text, words[j]).Count + " times \r\n";
                    buffer[j] = words[j];
                }
            }
            return (result != String.Empty) ? result : "Emptiness and Darkness...";
        }
    }
}
