using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Model
{
    interface IFileHandler
    {
        string Read(string filename);
        void Save(string filename, string text);
    }
}
