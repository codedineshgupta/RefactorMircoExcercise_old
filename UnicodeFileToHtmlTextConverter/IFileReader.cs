using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMircoExcercise.UnicodeFileToHtmlTextConverter
{
    public interface IFileReader
    {
        TextReader OpenText();
    }
}
