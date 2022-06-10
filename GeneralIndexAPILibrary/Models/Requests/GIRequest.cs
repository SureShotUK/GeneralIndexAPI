using GeneralIndexAPILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    //          Retrieve Symbol Variants
    //              This endpoint retrieves the symbols available and variants.
    //          Search Index Series Data
    //              This endpoint returns the symbols and metadata for index timeseries data.
    //          Retrieve Symbols For Alias
    //              The endpoint can also be used to return the symbols for a particular GX Alias.
    //          Retrieve Single Index Timeseries
    //              This endpoint retrieves index timeseries data for specific symbols in the provided time range. If the symbol does not exist, column is not displayed.
    //          Retrieve Multiple Timeseries for an Index Series
    //              This endpoint retrieves multiple timeseries (for example multiple timestamps denoted by different TimeRef) for a particular Index Series.

    public class GIRequest : IGIRequest
    {
        private readonly GIRequestType _gIRequestType;
        private IBodyParameters _bodyParameters;
        protected string _url;
        protected Dictionary<string, string>? _urlParams;
        private string _finalURL;
        protected HttpContent _httpContent;

        public IBodyParameters BodyParameters { get { return _bodyParameters; } }

        public HttpMethod Method { get { return GIURLS.GetHttpMethodFromRequestType(_gIRequestType); } }
        public HttpContent Content { get {
                UpdateBodyWithHttpContent();
                return _httpContent; } 
        }

        public string URL
        {
            get
            {
                UpdateURLWithParameters();
                return _finalURL;
            }
        }

        public GIRequest(GIRequestType RequestType = GIRequestType.REFRESH_TOKEN)
        {
            _gIRequestType = RequestType;
            _urlParams = GIURLS.GetUrlParametersFromRequestType(RequestType);
            _url = GIURLS.GetUrlFromRequestType(RequestType);
            _finalURL = String.Empty;
            _bodyParameters = new BodyParameters();
        }

        protected void UpdateURLWithParameters()
        {
            if (_urlParams != null && _urlParams.Count > 0) _finalURL = URLParamsHelper.GetUriFromParams(_url, _urlParams);
        }

        private void UpdateBodyWithHttpContent()
        {
            //_httpContent = JsonContent.Create(_bodyParameters);
        }

        protected string GetURLParameter(string KeyString)
        {
            if (_urlParams.TryGetValue(KeyString, out string result)) return result;
            return string.Empty;
        }

        protected int GetIntURLParameter(string KeyString)
        {
            string valueString = GetURLParameter(KeyString);
            if(string.IsNullOrEmpty(valueString)) return 0;
            if (int.TryParse(valueString, out int result)) return result;
            return 0;
        }

        protected void SetURLParameter(string KeyString, string ValueString)
        {
            if (_urlParams.ContainsKey(KeyString)) _urlParams[KeyString] = ValueString;
            else _urlParams.Add(KeyString, ValueString);
        }

        protected void SetURLParameter(string KeyString, int ValueString)
        {
            SetURLParameter(KeyString, ValueString.ToString());
        }
    }
}
