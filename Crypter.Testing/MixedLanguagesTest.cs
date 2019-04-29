using System;
using Crypter.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    [TestClass]
    public class MixedLanguagesTest
    {
        private const string punctuation = ".,?!-#'\";:()";

        [TestMethod]
        public void TestRusDig()
        {
            CaesarCrypter crypter = new CaesarCrypter(new Alphabet(Languages.Russian), new Alphabet(Languages.Digits));
            string text = "бвг123abc" + punctuation;
            int step = 1;

            CommonTestMethods.TestShift(crypter.Encrypt, text, step, "вгд234abc" + punctuation);
            CommonTestMethods.TestShift(crypter.Decrypt, text, step, "абв012abc" + punctuation);
        }
    }
}
