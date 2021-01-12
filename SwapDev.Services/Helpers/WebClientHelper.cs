using Newtonsoft.Json.Linq;
using System.Net;

namespace SwapDev.Services.Helpers
{
    public class WebClientHelper
    {
        public static dynamic GetJson(string url, string neededValue = null)
        {
            using var wc = new WebClient();
            var source = wc.DownloadString(url); 
            dynamic data = JObject.Parse(source);

            if (neededValue != null)
            {
                return data[neededValue].ToString();
            }

            return data;

        }
    }
}
