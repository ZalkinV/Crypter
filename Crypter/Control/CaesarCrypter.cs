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
    }
}
