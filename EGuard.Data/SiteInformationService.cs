using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EGuard.Data.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace EGuard.Data
{
    public class SiteInformationService : ISiteInformationService
    {
        public async Task<SiteInformation> GetSiteInformationAsync(string url)
        {
            var content = GetPostContent(url);

            var responseAsJson = await GetSiteInformationJson(content);
            var category = CreateSiteInformationObjectFromJson(responseAsJson);

            return category;
        }

        private FormUrlEncodedContent GetPostContent(string url)
        {
            var values = new Dictionary<string, string>
            {
                { "url", url }
            };

            return new FormUrlEncodedContent(values);
        }

        private async Task<string> GetSiteInformationJson(FormUrlEncodedContent content)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.ExpectContinue = false;

                var request = await client.PostAsync("http://sitereview.bluecoat.com/rest/categorization", content);
                var responseAsJson = await request.Content.ReadAsStringAsync();

                return responseAsJson;
            }
        }

        private SiteInformation CreateSiteInformationObjectFromJson(string json)
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
