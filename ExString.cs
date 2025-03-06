using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace C_EX
{
    class ExString
    {
        public static  string ToSentenceCase(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            char[] limiters = { '.', '!', '?' };
            string[] sentences = value.Split(limiters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                string sentence = sentences[i].TrimStart();
                if (!string.IsNullOrEmpty(sentence))
                {
                    sentences[i] = char.ToUpper(sentence[0])+(sentence.Length > 1 ? sentence.Substring(1).ToLower() : string.Empty);
                }
            }
            StringBuilder result = new StringBuilder();
            int currentPos = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                result.Append(sentences[i]);
                currentPos += sentences[i].Length;
                if (currentPos < value.Length)
                {
                    int nextDelimiterPos = value.IndexOfAny(limiters, currentPos);
                    if (nextDelimiterPos >= 0 && nextDelimiterPos < value.Length)
                    {
                        result.Append(value[nextDelimiterPos]);
                        currentPos = nextDelimiterPos + 1;
                    }
                }
            }

            return result.ToString();
        }

        public string RemoveAccents(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            string normalized = value.Normalize(NormalizationForm.FormD);
            StringBuilder result = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public string GenPassword(int value)
        {
            if(value <= 0)
            {
                return string.Empty;
            }

            const string c = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            Random random = new Random();
            char[] password = new char[value];

            for (int i = 0; i < value; i++)
            {
                password[i] = c[random.Next(c.Length)];
            }

            return new string(password);
        }
        public string RemoveCharactersNonAlphanumeric(string input)
        {
            return new string(input.Where(c => char.IsLetterOrDigit(c)).ToArray());
        }

    }
}