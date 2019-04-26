using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Control
{
    enum Languages
    {
        Russian, English, Digits,
    }

    class Alphabet
    {
        HashSet<char> letters;
        char[] alphabet;
        public char this[int index]
        {
            get { return alphabet[index]; }
        }

        public Alphabet(string alphabet)
        {
            InitializeAlphabet(alphabet);
        }

        private void InitializeAlphabet(string alphabet)
        {
            letters = alphabet.ToHashSet();
            this.alphabet = alphabet.ToCharArray();
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
            return letters.Contains(letter);
        }
    }
}
