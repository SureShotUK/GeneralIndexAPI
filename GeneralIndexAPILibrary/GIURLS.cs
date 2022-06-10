using GeneralIndexAPILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public static class GIURLS
    {
        public static string GetUrlFromRequestType(GIRequestType requestType) => requestType switch
        {
            GIRequestType.LOGIN => "https://api.g-x.co/auth/login",                        // GET
            GIRequestType.LOGOUT => "https://api.g-x.co/auth/logout",                      // POST
            GIRequestType.REFRESH_TOKEN => "https://api.g-x.co/auth/refresh",              // POST
            GIRequestType.SUBMIT_FILE => "https://api.g-x.co/file",                        // POST
            GIRequestType.RETRIEVE_SYMBOL_VARIANTS => "https://api.g-x.co/ts/symbol/values", // POST
            GIRequestType.SEARCH_INDEX_SERIES_DATA => "https://api.g-x.co/ts/symbol/search?query=", // GET - the URL has to end in an '=' in order to not add add a & or ? when passing to URLParamsHelper.GetUriFromParams()
            GIRequestType.RETRIEVE_SYMBOLS_FOR_ALIAS => "https://api.g-x.co/ts/symbol/search?query=", // GET
            GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES => "https://api.g-x.co/ts",     // POST
            GIRequestType.RETRIEVE_MULTIPLE_TIMESERIES_FOR_AN_INDEX_SERIES => "https://api.g-x.co/ts", // POST
            _ => throw new ArgumentOutOfRangeException(nameof(GIRequestType), $"Not expected GIRequestType value: {requestType}"),
        };

        public static HttpMethod GetHttpMethodFromRequestType(GIRequestType requestType) => requestType switch
        {
            GIRequestType.LOGIN => HttpMethod.Get,                        // GET
            GIRequestType.LOGOUT => HttpMethod.Post,                      // POST
            GIRequestType.REFRESH_TOKEN => HttpMethod.Post,              // POST
            GIRequestType.SUBMIT_FILE => HttpMethod.Post,                        // POST
            GIRequestType.RETRIEVE_SYMBOL_VARIANTS => HttpMethod.Post, // POST
            GIRequestType.SEARCH_INDEX_SERIES_DATA => HttpMethod.Get, // GET
            GIRequestType.RETRIEVE_SYMBOLS_FOR_ALIAS => HttpMethod.Get, // GET
            GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES => HttpMethod.Post,     // POST
            GIRequestType.RETRIEVE_MULTIPLE_TIMESERIES_FOR_AN_INDEX_SERIES => HttpMethod.Post, // POST
            _ => throw new ArgumentOutOfRangeException(nameof(GIRequestType), $"Not expected GIRequestType value: {requestType}"),
        };


        public static Dictionary<string, string> GetUrlParametersFromRequestType(GIRequestType requestType) => requestType switch
        {
            GIRequestType.LOGIN => new Dictionary<string, string>(),                        // GET
            GIRequestType.LOGOUT => new Dictionary<string, string>(),                      // POST
            GIRequestType.REFRESH_TOKEN => new Dictionary<string, string>(),              // POST
            GIRequestType.SUBMIT_FILE => new Dictionary<string, string>(),                        // POST
            GIRequestType.RETRIEVE_SYMBOL_VARIANTS => new Dictionary<string, string>() 
            { 
                ["from"] = "empty", 
                ["limit"] = "empty", 
                ["sort"] = "empty" 
            }, // POST
            GIRequestType.SEARCH_INDEX_SERIES_DATA => new Dictionary<string, string>()
            {
                ["groupName"] = "Prod_indexes",
                ["symbols.Code"] = "empty",
                ["symbols.PeriodType"] = "empty",
                ["symbols.TimeRef"] = "empty",
                ["symbols.Period"] = "empty",
                ["size"] = "empty",
                ["from"] = "empty",
                ["tokenExpiration"] = "empty",
                ["nextPageToken"] = "empty"
            }, // GET
            GIRequestType.RETRIEVE_SYMBOLS_FOR_ALIAS => new Dictionary<string, string>()
            {
                ["groupName"] = "Prod_Indexes",
                ["metadata.Alias"] = "empty"
            }, // GET
            GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES => new Dictionary<string, string>()
            {
                ["nextPageToken"] = "empty",
                ["size"] = "empty"
            },     // POST
            GIRequestType.RETRIEVE_MULTIPLE_TIMESERIES_FOR_AN_INDEX_SERIES => new Dictionary<string, string>()
            {
                ["nextPageToken"] = "empty",
                ["size"] = "empty"
            }, // POST
            _ => new Dictionary<string, string>(),
        };





        //public string Login { get { return GetUrlFromRequestType(GIRequestTypes.LOGIN); } }
        //public string Logout { get { return GetUrlFromRequestType(GIRequestTypes.LOGOUT); } }
        //public string Refresh { get { return GetUrlFromRequestType(GIRequestTypes.REFRESH_TOKEN); } }
        //public string SubmitFile { get { return GetUrlFromRequestType(GIRequestTypes.SUBMIT_FILE); } }
        //public string RetrieveSymbolVariants { get { return GetUrlFromRequestType(GIRequestTypes.RETRIEVE_SYMBOL_VARIANTS); } }
        //public string SearchIndexSeriesData { get { return GetUrlFromRequestType(GIRequestTypes.SEARCH_INDEX_SERIES_DATA); } }
        //public string retrieveSymbolsForAlias { get { return GetUrlFromRequestType(GIRequestTypes.RETRIEVE_SYMBOLS_FOR_ALIAS); } }
        //public string RetrieveSingleIndexTimeSeries { get { return GetUrlFromRequestType(GIRequestTypes.RETRIEVE_SINGLE_INDEX_TIMESERIES); } }
        //public string RetrieveMultipleTimeseriesForAnIndexSeries { get { return GetUrlFromRequestType(GIRequestTypes.RETRIEVE_MULTIPLE_TIMESERIES_FOR_AN_INDEX_SERIES); } }



    }
}
