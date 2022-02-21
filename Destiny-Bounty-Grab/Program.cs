
// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net;

namespace Destiny_Bounty_Grab
{
    public class DestinyCheck
    {
        static void Main()
        {
            const string baseUri = "https://www.bungie.net/platform/";

            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("X-API-Key", "7fa7a3ab0ffb44308e112a6ba16ec7c2");

            //    var response = client.GetAsync("https://www.bungie.net/platform/Destiny/Manifest/InventoryItem/1274330687/").Result;
            //    var content = response.Content.ReadAsStringAsync().Result;
            //    dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            //    Console.WriteLine(item.Response.data.inventoryItem.itemName); //Gjallarhorn
            //}


            var dc = new DestinyCheck();
            var result = dc.GetGroup("Valus Ta'aurc the real m9", baseUri);

            Console.WriteLine(result.Result);

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


   