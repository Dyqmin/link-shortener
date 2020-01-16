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
            string baseUrl = "https://rel.ink/api/links/";

            var inputObject = new Dictionary<string, string>
            {
                { "url",  link}
            };
            var inputBody = JsonConvert.SerializeObject(inputObject);

            StringContent queryString = new StringContent(inputBody, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await Api.ApiClient.PostAsync(baseUrl, queryString))
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
