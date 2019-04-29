using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Testing
{
    class CommonTestMethods
    {
        internal delegate string CrypterOperation(string text, int step);

        internal static void TestShift(CrypterOperation operation, string input, int step, string result)
        {
            Assert.AreEqual(result, operation(input, step));
        }
    }
}
