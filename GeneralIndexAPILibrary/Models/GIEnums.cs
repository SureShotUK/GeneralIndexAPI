
namespace GeneralIndexAPILibrary.Models
{
    #region enums

    public enum GIRequestType
    {
        LOGIN,
        LOGOUT,
        REFRESH_TOKEN,
        SUBMIT_FILE,
        RETRIEVE_SYMBOL_VARIANTS,
        SEARCH_INDEX_SERIES_DATA,
        RETRIEVE_SYMBOLS_FOR_ALIAS,
        RETRIEVE_SINGLE_INDEX_TIMESERIES,
        RETRIEVE_MULTIPLE_TIMESERIES_FOR_AN_INDEX_SERIES
    }

    public enum SortParamOptions
    {
        ASC,
        DESC
    }

    
    public enum OrderParamOptions
    {
        ASC,
        DESC
    }

    public enum KeyParamOptions
    {
        CODE,
        TIMEREF,
        PERIODTYPE,
        PERIOD
    }

    public enum FormatTypeParamOptions
    {
        STANDARD,
        PANDAS,
        NCSV
    }

    public enum HttpMessageReporting 
    { 
        VERBOSE,
        OFF
    }


    #endregion

}
