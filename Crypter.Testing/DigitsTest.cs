using System;
using Crypter.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    [TestClass]
    public class DigitsTest
    {
        CaesarCrypter crypterDig = new CaesarCrypter(new Alphabet(Languages.Digits));

        [TestMethod]
        public void TestSimpleShift()
        {
            string text = "123";
            int step = 1;

            CommonTestMethods.TestShift(crypterDig.Encrypt, text, step, "234");
            CommonTestMethods.TestShift(crypterDig.Decrypt, text, step, "012");
        }

        [TestMethod]
        public void TestDifferentShift()
        {
            string text = "09";
            int[] steps = new int[] { 0, 1, 9, 10, 11, 20, 21 };
            string[] expectedEncrypts = new string[] { "09", "10", "98", "09", "10", "09", "10" };
            string[] expectedDecrypts = new string[] { "09", "98", "10", "09", "98", "09", "98" };

            for (int i = 0; i < steps.Length; i++)
            {
                CommonTestMethods.TestShift(crypterDig.Encrypt, text, steps[i], expectedEncrypts[i]);
                CommonTestMethods.TestShift(crypterDig.Decrypt, text, steps[i], expectedDecrypts[i]);
            }
        }

        [TestMethod]
        public void TestFullAlphabet()
        {
            string alphabet = "0123456789";
            CommonTestMethods.TestEncryptFullAlphabet(crypterDig.Encrypt, alphabet);
            CommonTestMethods.TestDecryptFullAlphabet(crypterDig.Decrypt, alphabet);
        }
    }
}
