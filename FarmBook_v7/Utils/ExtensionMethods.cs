namespace FarmBook_v7.Utils
{
    public static class ExtensionMethods
    {
        public static string Sanitize(this string raw)
        {
            string rslt = raw.Replace("&", "&amp;"); 
            rslt = rslt.Replace("<", "&lt;");
            rslt = rslt.Replace(">", "&gt;");
            rslt = rslt.Replace("\"", "&quot;");
            rslt = rslt.Replace(System.Environment.NewLine, "<br>");
            return rslt;
        }
    }
}