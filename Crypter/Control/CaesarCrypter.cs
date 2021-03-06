﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Control
{
    public class CaesarCrypter
    {
        Alphabet[] alphabets;

        public CaesarCrypter(params Alphabet[] alphabets)
        {
            this.alphabets = new Alphabet[alphabets.Length];
            for (int i = 0; i < alphabets.Length; i++)
            {
                this.alphabets[i] = alphabets[i];
            }
        }
        public string Encrypt(string text, int step)
        {
            char[] symbols = text.ToCharArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                bool isUpper = false;
                if (char.IsUpper(symbols[i]))
                {
                    isUpper = true;
                    symbols[i] = char.ToLower(symbols[i]);
                }

                foreach (Alphabet alphabet in this.alphabets)
                {
                    if (alphabet.Contains(symbols[i]))
                        symbols[i] = DoShift(alphabet, alphabet[symbols[i]], step);
                }

                if (isUpper)
                    symbols[i] = char.ToUpper(symbols[i]);
            }

            return new string(symbols);
        }

        public string Decrypt(string text, int step)
        {
            return Encrypt(text, -step);
        }

        private char DoShift(Alphabet alphabet, int currentIndex, int step)
        {
            step %= alphabet.Length;

            if (step < 0)
            {
                step += alphabet.Length;
            }

            int shift = (currentIndex + step) % alphabet.Length;
            return alphabet[shift];
        }
    }
}
