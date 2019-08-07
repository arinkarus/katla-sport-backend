namespace KatlaSport.Services.ImageManagement
{
    public static class ConvertExtensions
    {
        public static string Repad(this string s)
        {
            s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}
