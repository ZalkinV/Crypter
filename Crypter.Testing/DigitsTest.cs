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
            CommonTestMethods.TestDifferentShift(crypterDig.Encrypt, crypterDig.Decrypt, "0123456789");
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
