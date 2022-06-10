using System.Net;
using System.Text.Json;
using GeneralIndexAPILibrary.Models;
using GeneralIndexAPILibrary.Models.Values.ConvertCSV;
using GeneralIndexAPILibrary.Parameters;


namespace GeneralIndexAPILibrary.Controller
{
    public class GIController
    {

        private readonly GIAPI _client;
        private HttpRequestMessage _message;
        private HttpResponseMessage _response;

        private RetrieveSymbolVariantsRequest _retrieveSymbolVariantsRequest;
        private RetrieveSingleIndexTimeseriesRequest _retrieveSingleIndexTimeseriesRequest;

        public HttpRequestMessage Message { get { return _message; } }
        public RetrieveSymbolVariantsRequest RetrieveSymbolVariantsRequest { get { return _retrieveSymbolVariantsRequest; } }
        public RetrieveSingleIndexTimeseriesRequest RetrieveSingleIndexTimeseriesRequest { get { return _retrieveSingleIndexTimeseriesRequest; } }

        public HttpResponseMessage Response { get { return _response; } }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GIController(HttpMessageReporting Reporting)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _client = new GIAPI(Reporting);
        }

        public async Task StartNewRequest(GIRequestType requestType)
        {
            switch (requestType) 
            {
                case GIRequestType.LOGIN:
                    await LoginAsync();
                    break;
                case GIRequestType.LOGOUT:
                    await LogoutAsync();
                    break;
                case GIRequestType.REFRESH_TOKEN:
                    await RefreshTokenAsync();
                        break;
                case GIRequestType.RETRIEVE_SYMBOL_VARIANTS:
                    RetrieveSymbolVariants();
                    break;
                case GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES:
                    RetrieveSingleIndexTimeSeries();
                    break;
            }
        }

        private async Task LoginAsync()
        {
            await _client.LoginAsync();
        }

        private async Task LogoutAsync() { await _client.LogOutAsync(); }
        private async Task RefreshTokenAsync() { await _client.RefreshTokenAsync(); }

        private void RetrieveSymbolVariants()
        {
            _retrieveSymbolVariantsRequest = new RetrieveSymbolVariantsRequest();
            _retrieveSymbolVariantsRequest.SetBodyParameterGroupName();
            _retrieveSymbolVariantsRequest.SetBodyParameterKey(KeyParamOptions.CODE);
            _retrieveSymbolVariantsRequest.URLParamFrom = 0;
        }

        private void RetrieveSingleIndexTimeSeries()
        {
            _retrieveSingleIndexTimeseriesRequest = new RetrieveSingleIndexTimeseriesRequest();
        }

        private void BuildRetrieveSingleIndexTimeSeriesMessage()
        {
            _message = new HttpRequestMessage(_retrieveSingleIndexTimeseriesRequest.Method, _retrieveSingleIndexTimeseriesRequest.URL);
            _message.Content = _retrieveSingleIndexTimeseriesRequest.Content;
            // Console.WriteLine($"\n\nCONTENT : {_retrieveSymbolVariantsRequest.Content.ToString()}\n\n");
            _client.AddHeadersAndBearerAuthToMessage(_message);
        }

        public async Task<List<string>> SendRetrieveSymbolVariantsMessage()
        {
            List<string> result = new List<string>();
            int from = _retrieveSymbolVariantsRequest.URLParamFrom;
            int limit = _retrieveSymbolVariantsRequest.URLParamLimit;
            SortParamOptions sort = GetAsEnum.SortParamOptionsFromString(_retrieveSymbolVariantsRequest.URLParamSort);

            BuildRetrieveSymbolVariantsMessage();

            _response = await _client.SendMessageAsync(_message);

            if (_response.StatusCode != HttpStatusCode.OK) return result;

            string responseContent = await _response.Content.ReadAsStringAsync();
            RetrieveSymbolVariantsMessageResponse deserializedResponse = JsonSerializer.Deserialize<RetrieveSymbolVariantsMessageResponse>(await _response.Content.ReadAsStringAsync());

            result = deserializedResponse.items.Select(p => p.name).ToList();

            return result;

        }

        public async Task<List<RetrieveSingleIndexTimeSeriesValue>> SendRetrieveSingleIndexTimeSeriesMessage()
        {
            string nextPageToken = _retrieveSingleIndexTimeseriesRequest.URLParamNextPageToken;
            int size = _retrieveSingleIndexTimeseriesRequest.URLParamSize;

            BuildRetrieveSingleIndexTimeSeriesMessage();

            _response = await _client.SendMessageAsync(_message);

            if (_response.StatusCode != HttpStatusCode.OK) return new List<RetrieveSingleIndexTimeSeriesValue>();

            string responseContent = await _response.Content.ReadAsStringAsync();
            ConvertCSVToCSharp<RetrieveSingleIndexTimeSeriesValue> values = new(responseContent);
            List<RetrieveSingleIndexTimeSeriesValue> result = values.CSVAsList;

            return result;

        }


        private void BuildRetrieveSymbolVariantsMessage()
        {
            _message = new HttpRequestMessage(_retrieveSymbolVariantsRequest.Method, _retrieveSymbolVariantsRequest.URL);
            _message.Content = _retrieveSymbolVariantsRequest.Content;
            _client.AddHeadersAndBearerAuthToMessage(_message);
        }



        #region Message Templates - Here is a 'prebuilt' message template
        // The variables introduced in these methods can be easily swapped out to give you a head start on creating some useful message calls really quickly
        

        /// <summary>
        /// Updates all in the List of giCodes from the startDate through to today, all codes must be for the period 1, PeriodType Prompt with TimeRef 1630 !!!
        /// </summary>
        /// <returns></returns>
        private async Task<List<RetrieveSingleIndexTimeSeriesValue>> GetValuesFromSingleIndexTimeSeriesAsync()
        {
            List<string> giCodes = new() { "GX000001", "GX000002" }; //Use an alternative source for the codes or pass them in as a paramter if you prefer?
            foreach (string gxCode in giCodes)
            {
                RetrieveSingleIndexKeys key = new() { symbols = new Symbol() { Code = gxCode, Period = "1", PeriodType = "Prompt", TimeRef = "1630" } };
                _retrieveSingleIndexTimeseriesRequest.AddKeyToBodyParam(key);
            }

            DateTime startDate = DateTime.Today.AddDays(-3);  // Change this to be whenever you want the data from, or pass it in as a parameter if you want to make this dynamic
            _retrieveSingleIndexTimeseriesRequest.BodyParamStartDate = startDate;
            _retrieveSingleIndexTimeseriesRequest.BodyParamendDate = DateTime.Today;
            _retrieveSingleIndexTimeseriesRequest.SetBodyParamFormatType(FormatTypeParamOptions.NCSV);
            List<RetrieveSingleIndexTimeSeriesValue> result = await SendRetrieveSingleIndexTimeSeriesMessage();

            return result;
        }

        #endregion
    }
}
