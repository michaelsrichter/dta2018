using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DTA2018.Helpers
{
    public class UserInfo
    {
        static HttpClient client = new HttpClient();
        private readonly string meJson;

        public UserInfo(Uri uri)
        {
            LoadMe(uri);
        }

        internal async Task LoadMe(Uri uri)
        {
            string meJson;
            var meUri = new Uri(uri.Scheme + "://" + uri.Authority + "/.auth/me");
            var response = await client.GetAsync(meUri);
            if (response.IsSuccessStatusCode)
            {
                meJson = await response.Content.ReadAsStringAsync();
                GetProperties(meJson);
            }

        }

        private void GetProperties(string meJson)
        {
            Id = JArray.Parse(meJson).First["user_id"].Value<string>();
        }

        public UserInfo(string MeJsonFileLocation)
        {

            meJson = File.ReadAllText(MeJsonFileLocation);
            GetProperties(meJson);
        }

        public string Id { get; set; }
    }
}