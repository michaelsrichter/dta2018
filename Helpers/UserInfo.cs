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

        public UserInfo()
        {
     
        }

        internal async Task LoadMe()
        {
            string meJson;
            var response = await client.GetAsync("/.auth/me");
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