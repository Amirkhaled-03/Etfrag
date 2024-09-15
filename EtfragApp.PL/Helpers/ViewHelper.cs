namespace EtfragApp.PL.Helpers
{
    public class ViewHelper
    {
        public static string GetControllerName(string typeName)
        => typeName == "Movie" ? "Movie" : "N/A";

        public static string IsPopular(bool isPopular)
           => isPopular ? "text-warning" : "text-light";

        public static string IsActive(int val1, int val2)
           => val1 == val2 ? "active" : "";
    }
}
