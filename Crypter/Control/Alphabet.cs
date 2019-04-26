using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Control
{
    class Alphabet
    {
        HashSet<char> letters;
        char[] alphabet;
        public char this[int index]
        {
            get { return alphabet[index]; }
        }
    }
}
