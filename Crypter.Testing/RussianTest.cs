using System;
using Crypter.Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crypter.Testing
{
    [TestClass]
    public class RussianTest
    {
        CaesarCrypter crypterRus = new CaesarCrypter(new Alphabet(Languages.Russian));

        [TestMethod]
        public void TestSimpleShift()
        {
            string text = "беёю";
            int step = 1;
            string expectedEncrypt = "вёжя";
            string expectedDecrypt = "адеэ";

            string actualEncrypt = crypterRus.Encrypt(text, step);
            string actualDecrypt = crypterRus.Decrypt(text, step);

            Assert.AreEqual(expectedEncrypt, actualEncrypt);
            Assert.AreEqual(expectedDecrypt, actualDecrypt);
        }
    }
}
