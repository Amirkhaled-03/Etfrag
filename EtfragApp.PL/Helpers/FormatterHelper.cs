using System.Drawing.Printing;

namespace EtfragApp.PL.Helpers
{
    public class FormatterHelper
    {
        public static string CapitalizeFirstLetter(string str)
            => char.ToUpper(str[0]) + str.Substring(1);

        public static string GetFormatedDate(DateTime date)
        //  => date.Day + "-" + date.Month + "-" + date.Year;
        => date.ToString().Substring(0,10);

        public static string GetImageUrl(string? imagePath)
        {
            return string.IsNullOrEmpty(imagePath) ? "~/Images/emptyImage.jpeg" : $"~/Files/Actors/{imagePath}";
        }

    }
}
