using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Control
{
    public enum Languages
    {
        Russian, English, Digits,
    }

    public class Alphabet
    {
        Dictionary<char, int> letters;
        char[] alphabet;
        
        public int Length { get; private set; }
        public char this[int index]
        {
            get { return alphabet[index]; }
        }
        public int this[char letter]
        {
            get { return letters[letter]; }
        }

        public Alphabet(string alphabet)
        {
            InitializeAlphabet(alphabet);
        }

        private void InitializeAlphabet(string alphabet)
        {
            letters = new Dictionary<char, int>();
            for (int i = 0; i < alphabet.Length; i++)
                letters.Add(alphabet[i], i);

            this.alphabet = alphabet.ToCharArray();
            Length = this.alphabet.Length;
        }

        public Alphabet(Languages language)
        {
            switch (language)
            {
                case Languages.Russian:
                    InitializeAlphabet("абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
                    break;
                case Languages.English:
                    InitializeAlphabet("abcdefghijklmnopqrstuvwxyz");
                    break;
                case Languages.Digits:
                    InitializeAlphabet("0123456789");
                    break;
            }
        }

        public bool Contains(char letter)
        {
            return letters.ContainsKey(letter);
        }
    }
}
