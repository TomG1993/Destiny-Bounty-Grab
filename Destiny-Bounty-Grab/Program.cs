
// See https://aka.ms/new-console-template for more information
using Destiny_Bounty_Grab.Services;
using Newtonsoft.Json;
using System.Net;

namespace Destiny_Bounty_Grab
{
    public class DestinyCheck
    {
        static void Main()
        {
            const string baseUri = "https://www.bungie.net/platform/";
            const string destinyUri = "https://www.bungie.net/platform/Destiny2/";
            const string authUri = "https://www.bungie.net/en/oauth/";

            //var dc = new DestinyCheck();
            //var result = dc.GetGroup("Valus Ta'aurc the real m9", baseUri);

            var authService = new AuthService();
            authService.Auth(authUri);

            var userSerivce = new UserService();
            var profile = userSerivce.GetCharacters(destinyUri);

            var vendorService = new VendorService();
            var vendors = vendorService.GetVendors(destinyUri);

            Console.WriteLine(profile);

            Console.ReadLine();
        }


        async Task<string> GetGroup(string groupName, string baseUri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", "7fa7a3ab0ffb44308e112a6ba16ec7c2");

                //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, ToString());

                var m9Clan = new GroupQuery()
                {
                    name = groupName,
                    groupType = 1,
                    //tagText = groupName
                };

                string json = JsonConvert.SerializeObject(m9Clan);

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = client.PostAsync(baseUri + "GroupV2/Search/", httpContent).Result;

                var contents = await response.Content.ReadAsStringAsync();


                Root results = JsonConvert.DeserializeObject<Root>(contents);


                var clanResponse = client.GetAsync(baseUri + "GroupV2/" + results.Response.results.FirstOrDefault().groupId + "/Members/").Result;

                var clan = await clanResponse.Content.ReadAsStringAsync();
                var clanResults = JsonConvert.DeserializeObject<RootUser>(clan);

                var players = clanResults.Response.results;

                return results.Response.results.FirstOrDefault().clanInfo.clanCallsign;
            }

            return null;
        }
    }
}


   