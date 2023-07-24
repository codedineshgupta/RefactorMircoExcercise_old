using System.IO;
using System.Web;

namespace RefactorMircoExcercise.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {       
        private readonly IFileReader _reader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath) :this(new UnicodeFileReader(fullFilenameWithPath))
        {
           
        }
        public UnicodeFileToHtmlTextConverter(IFileReader reader)
        {
            _reader = reader;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _reader.OpenText())
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
}
