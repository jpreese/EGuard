using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EGuard.Data.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace EGuard.Data
{
    public class SiteInformationService
    {
        public async Task<SiteInformation> GetSiteInfoAsJson(string url)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "url", url }
                };

                var content = new FormUrlEncodedContent(values);
                var request = await client.PostAsync("http://sitereview.bluecoat.com/rest/categorization", content);
                var responseString = await request.Content.ReadAsStringAsync();

                var category = CreateSiteInfoJson(responseString);

                return category;
            }
        }

        private SiteInformation CreateSiteInfoJson(string json)
        {
            var siteInfo = JsonConvert.DeserializeObject<SiteInformation>(json);
            siteInfo.Categorization = RemoveAnchorTagFromCategory(siteInfo.Categorization);

            return siteInfo;
        }

        private string RemoveAnchorTagFromCategory(string category)
        {
            return Regex.Match(category, @"<a [^>]*>(.*?)</a>").Groups[1].Value;
        }
    }
}
