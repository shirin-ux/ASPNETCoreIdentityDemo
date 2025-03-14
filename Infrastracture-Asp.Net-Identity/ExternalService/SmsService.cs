using ASPNETCoreIdentityDemo_Application.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture_Asp.Net_Identity.ExternalService
{
    public class SmsService(IConfiguration configuration,IHttpClientFactory httpClientFactory) : ISmsService
    {
        private readonly IHttpClientFactory _httpClientFactory=httpClientFactory;
        private readonly IConfiguration _configuration = configuration;
        public async Task<bool> SendSmsAsync(string phoneNumber, string code)
        {
            var apiKey = _configuration["SmsSettings:ApiKey"];
            var baseUrl = _configuration["SmsSettings:BaseUrl"];
            var requestUrl = $"{baseUrl}/send?to={phoneNumber}&text={code}&apiKey={apiKey}";
            var client = _httpClientFactory.CreateClient("SmsApiClient"); 

            var response = await client.GetAsync(requestUrl);
            return response.IsSuccessStatusCode;
        }
    }
}
