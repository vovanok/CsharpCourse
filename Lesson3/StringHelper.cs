using System.Collections.Generic;
using System.Text;

namespace Lesson3
{
    class StringHelper
    {
        private string inputString;

        public StringHelper(string inputString)
        {
            this.inputString = inputString;
        }

        public bool IsChangeling()
        {
            if (inputString == null)
                return false;

            return inputString == GetInverseString();
        }

        public uint GetCountWords()
        {
            if (inputString == null)
                return 0;

            List<char> separators = new List<char>();
            foreach (char ch in inputString)
            {
                if (!char.IsLetterOrDigit(ch) && !separators.Contains(ch))
                    separators.Add(ch);
            }

            string[] words = inputString.Split(separators.ToArray());

            uint countWords = 0;
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    countWords++;
                }
            }

            return countWords;
        }

        public string GetInverseString()
        {
            if (inputString == null)
                return string.Empty;

            StringBuilder result = new StringBuilder();

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                result.Append(inputString[i]);
            }

            return result.ToString();
        }
    }
}
