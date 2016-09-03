using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace PairingTest.Web.Providers
{
    public class DataProvider : IDataProvider
    {
        private Uri _uri = new Uri(ConfigurationManager.AppSettings["QuestionnaireServiceUri"]);

        public async Task<string> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_uri);

                string content = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();

                return content;
            }
        }

        public async Task<int> MarkAnswers(IEnumerable<string> answers)
        {
            string json = JsonConvert.SerializeObject(answers);
            HttpContent content = new StringContent(json, Encoding.UTF8, "text/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(_uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    return Convert.ToInt32(result);
                }

                return 0;
            }            
        }
    }
}
