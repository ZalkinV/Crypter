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
    }
}
