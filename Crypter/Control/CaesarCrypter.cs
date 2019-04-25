using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Control
{
    static class CaesarCrypter
    {
        public static string Encrypt(string text, int step)
        {
            char[] symbols = text.ToCharArray();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (char.IsDigit(symbols[i]))
                {
                    symbols[i] = DoShift(symbols[i], step, '0', '9');
                }
                if ('а' <= symbols[i] && symbols[i] <= 'я')
                {
                    symbols[i] = DoShift(symbols[i], step, 'а', 'я');
                }
                if ('А' <= symbols[i] && symbols[i] <= 'Я')
                {
                    symbols[i] = DoShift(symbols[i], step, 'А', 'Я');
                }
            }

            return new string(symbols);
        }

        public static string Decrypt(string text, int step)
        {
            return Encrypt(text, -step);
        }

        private static char DoShift(char current, int step, char first, char last)
        {
            int alphabetSize = last - first + 1;
            step %= alphabetSize;

            if (step < 0)
            {
                step += alphabetSize;
            }

            int shift = (current - first + step) % alphabetSize;
            return (char)(first + shift);
        }
    }
}
