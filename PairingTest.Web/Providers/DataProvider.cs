using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            int percentage = default(int);

            string json = JsonConvert.SerializeObject(answers);
            HttpContent content = new StringContent(json);

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.PostAsJsonAsync(_uri.ToString(), answers);

                string result = await response.Content.ReadAsStringAsync();
                percentage = Convert.ToInt32(result);
            }

            return percentage;
        }
    }
}