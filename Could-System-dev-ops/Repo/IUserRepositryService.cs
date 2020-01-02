using Cloud_System_dev_ops.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Repo
{
    public class LocalHostUserService : IUserRepositry
    {
        private readonly HttpClient _Client;

        public LocalHostUserService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:57376");
            client.Timeout = TimeSpan.FromSeconds(5);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<UserMetaData> Edituser(UserMetaData User)
        {
            string uri = "api/Users/EditUsers";
            HttpResponseMessage responseMessage = await _Client.PostAsJsonAsync(uri, User);
            string responseContent = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserMetaData>(responseContent);
        }
    }
}
