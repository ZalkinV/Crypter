using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace Crypter.Model
{
    class DocxFileHandler : IFileHandler
    {
        public string Read(string filename)
        {
            using (DocX document = DocX.Load(filename))
            {
                return document.Text;
            }
        }

        public void Save(string filename, string text)
        {
            throw new NotImplementedException();
        }
    }
}
