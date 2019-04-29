using System;
using Crypter.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    [TestClass]
    public class EnglishTest
    {
        CaesarCrypter crypterEng = new CaesarCrypter(new Alphabet(Languages.English));

        [TestMethod]
        public void TestSimpleShift()
        {
            string text = "bcde";
            int step = 1;

            CommonTestMethods.TestShift(crypterEng.Encrypt, text, step, "cdef");
            CommonTestMethods.TestShift(crypterEng.Decrypt, text, step, "abcd");
        }

        [TestMethod]
        public void TestDifferentShift()
        {
            CommonTestMethods.TestDifferentShift(crypterEng.Encrypt, crypterEng.Decrypt, "abcdefghijklmnopqrstuvwxyz");
        }
    }
}
