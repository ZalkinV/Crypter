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
            return text;
        }

        public static string Decrypt(string text, int step)
        {
            return Encrypt(text, -step);
        }

        private static char DoShift(char current, int step, char first, char last)
        {
            int alphabetSize = last - first + 1;
            step %= alphabetSize;
            int shift = (current - first + step) % alphabetSize;
            return (char)(first + shift);
        }
    }
}
