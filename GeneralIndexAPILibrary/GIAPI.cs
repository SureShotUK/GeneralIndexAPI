using GeneralIndexAPILibrary.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace GeneralIndexAPILibrary
{
    public class GIAPI
    {
        private readonly HttpClient _gi;
        private AuthorizationTokens _authTokens;
        private IGIRequest _giRequest;

        public IGIRequest Request { get { return _giRequest; } }
        public GIAPI(HttpMessageReporting HttpReporting)
        {
            if(HttpReporting == HttpMessageReporting.VERBOSE) _gi = new(new LoggingHandler(new HttpClientHandler()));
            else _gi = new();
            _gi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        #region Get Requests

        #region Login, Logout and Refresh
        public async Task<HttpResponseMessage> LoginAsync()
        {
            GIRequestType requestType = GIRequestType.LOGIN;
            string userName = "ENTER YOUR GI USERNAME";
            string password = "ENTER YOUR GI PASSWORD";

            string creds = URLParamsHelper.EncodeCredentials(userName, password);
            HttpRequestMessage message = new(GIURLS.GetHttpMethodFromRequestType(requestType), GIURLS.GetUrlFromRequestType(requestType));

            message.Headers.Add("Authorization", creds);

            var productValue = new ProductInfoHeaderValue(".NET", "6.0");
            message.Headers.UserAgent.Add(productValue);

            HttpResponseMessage response = await _gi.SendAsync(message);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jwttokens = await response.Content.ReadAsStringAsync();
                _authTokens = JsonConvert.DeserializeObject<AuthorizationTokens>(jwttokens) ?? new AuthorizationTokens(); ;
            }
            // Could add a section to deal with login failures here ??
            return response;
        }

        public async Task<HttpResponseMessage> RefreshTokenAsync()
        {
            HttpRequestMessage message = new(HttpMethod.Post, "https://api.g-x.co/auth/refresh");

            var productValue = new ProductInfoHeaderValue(".NET", "6.0");
            message.Headers.UserAgent.Add(productValue);
            //message.Content = new StringContent(JsonConvert.SerializeObject(_authTokens.refreshToken));
            message.Content = JsonContent.Create(new { refreshToken = _authTokens.refreshToken });


            HttpResponseMessage response = await _gi.SendAsync(message);
            Console.WriteLine("Refresh response " + response.StatusCode);
            if (response.StatusCode == HttpStatusCode.OK) _authTokens = JsonConvert.DeserializeObject<AuthorizationTokens>(await response.Content.ReadAsStringAsync());
            return response;
        }


        public async Task<HttpResponseMessage?> LogOutAsync()
        {
            HttpRequestMessage message = new(HttpMethod.Post, "https://api.g-x.co/auth/logout");
            message.Headers.Add("Authorization", $"Bearer {_authTokens.token}");
            message.Content = JsonContent.Create(new { refreshToken = _authTokens.refreshToken });
            HttpResponseMessage response = await _gi.SendAsync(message);
            if (response.StatusCode == HttpStatusCode.OK) return response;
            //This could be used for handeling logout errors
            return null;
        }
        #endregion

        public void AddHeadersAndBearerAuthToMessage(HttpRequestMessage message)
        {
            var productValue = new ProductInfoHeaderValue(".NET", "6.0");
            message.Headers.UserAgent.Add(productValue);
            message.Headers.Add("Authorization", "Bearer " + _authTokens.token);
            message.Headers.Add("Accept", "application/json");
        }

        public async Task<HttpResponseMessage> SendMessageAsync(HttpRequestMessage message)
        {
            return await _gi.SendAsync(message);
        }

        #endregion

        //   API Calls that need making are as follows
        //          Retrieve Symbol Variants = DONE
        //              This endpoint retrieves the symbols available and variants.
        //          Search Index Series Data - TODO
        //              This endpoint returns the symbols and metadata for index timeseries data.
        //          Retrieve Symbols For Alias - TODO
        //              The endpoint can also be used to return the symbols for a particular GX Alias.
        //          Retrieve Single Index Timeseries - DONE
        //              This endpoint retrieves index timeseries data for specific symbols in the provided time range. If the symbol does not exist, column is not displayed.
        //          Retrieve Multiple Timeseries for an Index Series - TODO
        //              This endpoint retrieves multiple timeseries (for example multiple timestamps denoted by different TimeRef) for a particular Index Series.
    }


}
