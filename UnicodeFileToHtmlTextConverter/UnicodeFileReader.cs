using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMircoExcercise.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileReader : IFileReader
    {
        private readonly string _fullFilenameWithPath;
        public UnicodeFileReader(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }

        public TextReader OpenText()
        {
            return File.OpenText(_fullFilenameWithPath);
        }
    }
}
