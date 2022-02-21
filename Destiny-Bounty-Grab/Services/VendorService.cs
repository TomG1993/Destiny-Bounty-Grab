using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny_Bounty_Grab.Services
{
    public class VendorService
    {
        public string GetVendors(string destnyUri)
        {
            // {membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/

            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", "7fa7a3ab0ffb44308e112a6ba16ec7c2");

                var response = client.GetAsync(destnyUri + "1/profile/4611686018430018099/Character/2305843009425476432/Vendors?Components=VendorSales").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                Console.WriteLine(item.Response.data.inventoryItem.itemName); //Gjallarhorn
            }
            return "";
        }
    }
}
