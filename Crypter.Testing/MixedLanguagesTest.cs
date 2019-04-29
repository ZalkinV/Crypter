using System;
using Crypter.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    [TestClass]
    public class MixedLanguagesTest
    {
        const string punctuation = ".,?!-#'\";:()";
        const string mixedText = "бвг123bcd" + punctuation;
        const int step = 1;

        [TestMethod]
        public void TestRusDig()
        {
            CaesarCrypter crypter = new CaesarCrypter(new Alphabet(Languages.Russian), new Alphabet(Languages.Digits));
            string expectedEncrypt = "вгд234bcd" + punctuation;
            string expectedDecrypt = "абв012bcd" + punctuation;

            CommonTestMethods.TestShift(crypter.Encrypt, mixedText, step, expectedEncrypt);
            CommonTestMethods.TestShift(crypter.Decrypt, mixedText, step, expectedDecrypt);
        }

        [TestMethod]
        public void TestRusEng()
        {
            CaesarCrypter crypter = new CaesarCrypter(new Alphabet(Languages.Russian), new Alphabet(Languages.English));
            string expectedEncrypt = "вгд123cde" + punctuation;
            string expectedDecrypt = "абв123abc" + punctuation;

            CommonTestMethods.TestShift(crypter.Encrypt, mixedText, step, expectedEncrypt);
            CommonTestMethods.TestShift(crypter.Decrypt, mixedText, step, expectedDecrypt);
        }

        [TestMethod]
        public void TestEngDig()
        {
            CaesarCrypter crypter = new CaesarCrypter(new Alphabet(Languages.English), new Alphabet(Languages.Digits));
            string expectedEncrypt = "бвг234cde" + punctuation;
            string expectedDecrypt = "бвг012abc" + punctuation;

            CommonTestMethods.TestShift(crypter.Encrypt, mixedText, step, expectedEncrypt);
            CommonTestMethods.TestShift(crypter.Decrypt, mixedText, step, expectedDecrypt);
        }

        [TestMethod]
        public void TestRusEngDig()
        {
            CaesarCrypter crypter = new CaesarCrypter(new Alphabet(Languages.Russian), new Alphabet(Languages.English), new Alphabet(Languages.Digits));
            string expectedEncrypt = "вгд234cde" + punctuation;
            string expectedDecrypt = "абв012abc" + punctuation;

            CommonTestMethods.TestShift(crypter.Encrypt, mixedText, step, expectedEncrypt);
            CommonTestMethods.TestShift(crypter.Decrypt, mixedText, step, expectedDecrypt);
        }
    }
}
