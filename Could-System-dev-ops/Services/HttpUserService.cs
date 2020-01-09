using Cloud_System_dev_ops.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Services 
{
    public class HttpUserService : IUserService
    {
        private readonly HttpClient _Client;
        private IHttpContextAccessor _Context;

        public HttpUserService(HttpClient Client, IHttpContextAccessor Context)
        {
            _Client = Client;
            _Context = Context;
        }
        private async Task SetAccessToken()
        {
            if (_Client != null && _Context != null)
            {
                string accessToken = await _Context.HttpContext.GetTokenAsync("access_token");
                _Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }
        public async Task<UserMetaData> Edituser(UserMetaData User)
        {

            string uri = "api/Users/EditUsers";
            try
            {
                await SetAccessToken();
                HttpResponseMessage responseMessage = await _Client.PostAsJsonAsync(uri, User);
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserMetaData>(responseContent);
            }
            catch(Exception ex)
            {
                return null;
            }
               
        }
    }
}
