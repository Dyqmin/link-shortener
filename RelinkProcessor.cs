using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WitProjekt
{
    class RelinkProcessor

    {
        public static async Task<RelinkModel> PostLink(string link = "")
        {
            string url = "https://rel.ink/api/links/";

            string jsonParams = @"{
                'url': '" + link + "'}";

            var values = new Dictionary<string, string>
            {
                { "url",  link}
            };
            var content = JsonConvert.SerializeObject(values);

            StringContent queryString = new StringContent(content, Encoding.UTF8, "application/json");


            using (HttpResponseMessage response = await Api.ApiClient.PostAsync(url, queryString))
            {
                if (response.IsSuccessStatusCode)
                {
                    RelinkModel relink = await response.Content.ReadAsAsync<RelinkModel>();

                    return relink;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            
        }

    }
}
