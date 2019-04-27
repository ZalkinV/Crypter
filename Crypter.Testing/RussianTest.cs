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

        [TestMethod]
        public void TestDifferentShift()
        {
            string text = "ая";
            int[] steps = new int[] { 0, 1, 32, 33, 34, 66, 67 };
            string[] expectedEncrypts = new string[] { "ая", "ба", "яю", "ая", "ба", "ая", "ба" };
            string[] expectedDecrypts = new string[] { "ая", "яю", "ба", "ая", "яю", "ая", "яю" };

            for (int i = 0; i < steps.Length; i++)
            {
                string actualEncrypt = crypterRus.Encrypt(text, steps[i]);
                string actualDecrypt = crypterRus.Decrypt(text, steps[i]);

                Assert.AreEqual(expectedEncrypts[i], actualEncrypt);
                Assert.AreEqual(expectedDecrypts[i], actualDecrypt);
            }
        }
    }
}
