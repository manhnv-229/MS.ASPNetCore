using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MS.DemoAppDesktop
{
    public class MSHttpClient
    {
        // In the class
        public HttpClient HttpClient = new HttpClient();
        public MSHttpClient()
        {
            // Put the following code where you want to initialize the class
            // It can be the static constructor or a one-time initializer
            HttpClient.BaseAddress = new Uri("https://localhost:6066/api/v1/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
    }
}
