using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Aula_2019_12_14.Services
{
    public class HttpClientService : HttpClient
    {
        public HttpClientService()
        {
            var authData = string.Format("{0}:{1}", "lanceloti", "21f7ed4ecc94ab6658d02fb24f8a8c584a13d767");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }
    }
}
