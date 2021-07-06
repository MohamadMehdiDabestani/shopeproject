using System.Text.Encodings.Web;

namespace Core
{
    public static class Encoding
    {
        public static string HtmlEncoing(this string text)
        {
            return HtmlEncoder.Default.Encode(text);
        }
    }
}