using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    class CommonTestMethods
    {
        internal delegate string CrypterOperation(string text, int step);

        internal static void TestShift(CrypterOperation operation, string input, int step, string result)
        {
            Assert.AreEqual(result, operation(input, step));
        }

        internal static void TestDifferentShift(CrypterOperation encrypt, CrypterOperation decrypt, string alphabet)
        {
            string firstLetter = alphabet[0].ToString();
            string secondLetter = alphabet[1].ToString();
            string penultLetter = alphabet[alphabet.Length - 2].ToString();
            string lastLetter = alphabet[alphabet.Length - 1].ToString();

            string text = firstLetter + lastLetter;
            int[] steps =
            {
                0,
                1,
                alphabet.Length - 1,
                alphabet.Length,
                alphabet.Length + 1,
                alphabet.Length * 2,
                alphabet.Length * 2 + 1
            };

            string[] expectedEncrypts =
            {
                text,
                secondLetter + firstLetter,
                lastLetter + penultLetter,
                text,
                secondLetter + firstLetter,
                text,
                secondLetter + firstLetter
            };

            string[] expectedDecrypts =
            {
                text,
                lastLetter + penultLetter,
                secondLetter + firstLetter,
                text,
                lastLetter + penultLetter,
                text,
                lastLetter + penultLetter
            };

            for (int i = 0; i < steps.Length; i++)
            {
                TestShift(encrypt, text, steps[i], expectedEncrypts[i]);
                TestShift(decrypt, text, steps[i], expectedDecrypts[i]);
            }

        }

        internal static void TestFullAlphabet(CrypterOperation encrypt, CrypterOperation decrypt, string alphabet)
        {
            for (int i = 0; i <= alphabet.Length; i++)
            {
                string expectedEncrypt = alphabet.Remove(0, i) + alphabet.Substring(0, i);
                string expectedDecrypt = alphabet.Substring(alphabet.Length - i, i) + alphabet.Remove(alphabet.Length - i, i);

                TestShift(encrypt, alphabet, i, expectedEncrypt);
                TestShift(decrypt, alphabet, i, expectedDecrypt);
            }
        }
    }
}
