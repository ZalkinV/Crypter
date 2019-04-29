using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Testing
{
    class CommonTestMethods
    {
        internal delegate string CrypterOperation(string text, int step);

        internal static void TestShift(CrypterOperation operation, string input, int step, string result)
        {
            Assert.AreEqual(result, operation(input, step));
        }

        internal static void TestEncryptFullAlphabet(CrypterOperation operation, string alphabet)
        {
            for (int i = 0; i <= alphabet.Length; i++)
            {
                string expectedEncrypt = alphabet.Remove(0, i) + alphabet.Substring(0, i);

                TestShift(operation, alphabet, i, expectedEncrypt);
            }
        }

        internal static void TestDecryptFullAlphabet(CrypterOperation operation, string alphabet)
        {
            for (int i = 0; i <= alphabet.Length; i++)
            {
                string expectedDecrypt = alphabet.Substring(alphabet.Length - i, i) + alphabet.Remove(alphabet.Length - i, i);

                TestShift(operation, alphabet, i, expectedDecrypt);
            }
        }
    }
}
