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

            CommonTestMethods.TestShift(crypterRus.Encrypt, text, step, "вёжя");
            CommonTestMethods.TestShift(crypterRus.Decrypt, text, step, "адеэ");
        }

        [TestMethod]
        public void TestDifferentShift()
        {
            CommonTestMethods.TestDifferentShift(crypterRus.Encrypt, crypterRus.Decrypt, "абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
        }

        [TestMethod]
        public void TestFullAlphabet()
        {
            CommonTestMethods.TestFullAlphabet(crypterRus.Encrypt, crypterRus.Decrypt, "абвгдеёжзийклмнопрстуфхцчшщъыьэюя");
        }
    }
}
