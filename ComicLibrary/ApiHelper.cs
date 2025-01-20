using System.Security.Cryptography.X509Certificates;

namespace ComicLibrary
{
    public class ApiHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeComicClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        
    }
}
