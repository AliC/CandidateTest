using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.Providers
{
    public class DataProvider : IDataProvider
    {
        public async Task<string> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri(ConfigurationManager.AppSettings["QuestionnaireServiceUri"]);

                HttpResponseMessage response = await client.GetAsync(uri);

                string content = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                return content;
            }
        }
    }
}