using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crypter.Model
{
    class TxtFileHandler : IFileHandler
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }

        public void Save(string filename, string text)
        {
            throw new NotImplementedException();
        }
    }
}
