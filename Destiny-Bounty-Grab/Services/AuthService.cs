using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace Destiny_Bounty_Grab.Services
{
    public class AuthService
    {
        public async void Auth(string authUri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", "7fa7a3ab0ffb44308e112a6ba16ec7c2");

                //GET https://www.bungie.net/en/oauth/authorize?client_id=12345&response_type=code&state=6i0mkLx79Hp91nzWVeHrzHG4

                var response = await client.GetAsync(authUri + "authorize?ClientId=39385&response_type=code&state=2558test");
                var query = response.RequestMessage.RequestUri;

                var queryDecode = HttpUtility.UrlDecode(query.Query);
                var content = response.Content.ReadAsStringAsync();
                //dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                //Console.WriteLine(item.Response.data.inventoryItem.itemName); //Gjallarhorn
            }
        }
    }
}
