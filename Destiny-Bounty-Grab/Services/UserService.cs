using Destiny_Bounty_Grab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny_Bounty_Grab.Services
{
    public class UserService
    {
       public async Task<List<CharacterData>> GetCharacters(string destinyUri)
        {
            /// Destiny2 /{ membershipType}/ Profile /{ destinyMembershipId}/
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", "7fa7a3ab0ffb44308e112a6ba16ec7c2");

                var response = client.GetAsync(destinyUri + "1/profile/4611686018430018099?Components=Characters").Result;
                var profileResult = await response.Content.ReadAsStringAsync();
                try
                {
                    var item = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileCharacterRoot>(profileResult);
                    return item.Response.characters.data.Values.ToList();
                }
                catch (Exception e)
                {
                    var test = e.Data;
                    throw;
                }


                return null; 
            }
        }
    }
}
