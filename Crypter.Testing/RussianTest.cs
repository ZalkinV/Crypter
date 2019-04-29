﻿using System;
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
            string text = "ая";
            int[] steps = new int[] { 0, 1, 32, 33, 34, 66, 67 };
            string[] expectedEncrypts = new string[] { "ая", "ба", "яю", "ая", "ба", "ая", "ба" };
            string[] expectedDecrypts = new string[] { "ая", "яю", "ба", "ая", "яю", "ая", "яю" };

            for (int i = 0; i < steps.Length; i++)
            {
                CommonTestMethods.TestShift(crypterRus.Encrypt, text, steps[i], expectedEncrypts[i]);
                CommonTestMethods.TestShift(crypterRus.Decrypt, text, steps[i], expectedDecrypts[i]);
            }
        }

        [TestMethod]
        public void TestFullAlphabet()
        {
            string text = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            
            for (int i = 0; i <= text.Length; i++)
            {
                string expectedEncrypt = text.Remove(0, i) + text.Substring(0, i);
                string expectedDecrypt = text.Substring(text.Length - i, i) + text.Remove(text.Length - i, i);

                CommonTestMethods.TestShift(crypterRus.Encrypt, text, i, expectedEncrypt);
                CommonTestMethods.TestShift(crypterRus.Decrypt, text, i, expectedDecrypt);
            }
        }
    }
}
