using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using GeneralIndexAPILibrary.Models;
using GeneralIndexAPILibrary.Parameters;
using Newtonsoft.Json;

namespace GeneralIndexAPILibrary
{
    public class RetrieveSingleIndexTimeseriesRequest : GIRequest, IGIRequest
    {

        //      1. Inherit from GIRequrest and Implement the interface IGIRequest
        //      2. Add the bodyParameters field
        //      3. Add any URL parameters properties
        //      4. Add any body properties
        //      5. For those params that require a choice make the enums for those choices and chenge the properties to only use Get, make the set into a method
        //      6. Add the enums to handle the cohoices for the URL or body parameters
        //      7. Add the HttpContent property


        private RetrieveSingleIndexTimeSeriesBodyParameters _bodyParameters;

        public DateTime? BodyParamStartDate { get { return _bodyParameters.startDate; } set { _bodyParameters.startDate = value; } }
        public DateTime? BodyParamendDate { get { return _bodyParameters.endDate; } set { _bodyParameters.endDate = value; } }
        public DateTime? BodyParamOndDateTime { get { return _bodyParameters.onDateTime; } set { _bodyParameters.onDateTime = value; } }

        public bool? BodyParamCorrections { get { return _bodyParameters.corrections; } set { _bodyParameters.corrections = value; } }
        public bool? BodyParamMetadata { get { return _bodyParameters.metadata; } set { _bodyParameters.metadata = value; } }
        public bool? BodyParamDelta { get { return _bodyParameters.delta; } set { _bodyParameters.delta = value; } }

        public string? BodyParamTimeZone { get { return _bodyParameters.timeZone; } set { if (!string.IsNullOrWhiteSpace(value)) _bodyParameters.timeZone = value; } }

        public string? BodyParamFormatType { get { return _bodyParameters.formatType; } }

        public int? BodyParamDecimalPrecision { get { return _bodyParameters.decimalPrecision; } set { if (value >= 0) _bodyParameters.decimalPrecision = value; } }
        public string? BodyParamOrder { get { return _bodyParameters.order; } }

        

        public int URLParamSize
        {
            get { return GetIntURLParameter("size"); }
            set { if (value >= 0) SetURLParameter("size", value); }
        }

        public string URLParamNextPageToken
        {
            get { return GetURLParameter("nextPageToken"); }
        }

        public new HttpContent Content
        {
            get
            {
                UpdateBodyWithHttpContent();
                return _httpContent;
            }
        }


        public RetrieveSingleIndexTimeseriesRequest(string NextPageToken = "empty") : base(GIRequestType.RETRIEVE_SINGLE_INDEX_TIMESERIES)
        {
            _bodyParameters = new RetrieveSingleIndexTimeSeriesBodyParameters();
            if (NextPageToken != "empty") SetURLParameter("nextPageToken", NextPageToken);
        }

        public void AddKeyToBodyParam(RetrieveSingleIndexKeys key)
        {
            _bodyParameters.AddNewKey(key);
        }

        public void SetBodyParamOrder(OrderParamOptions order)
        {
            switch (order)
            {
                case OrderParamOptions.ASC:
                    _bodyParameters.order = "asc";
                    break;
                case OrderParamOptions.DESC:
                    _bodyParameters.order = "desc";
                    break;
            }
        }

        public void SetBodyParamFormatType(FormatTypeParamOptions formatType)
        {
            switch (formatType)
            {
                case FormatTypeParamOptions.STANDARD:
                    _bodyParameters.formatType = "STANDARD";
                    break;
                case FormatTypeParamOptions.PANDAS:
                    _bodyParameters.formatType = "PANDAS";
                    break;
                case FormatTypeParamOptions.NCSV:
                    _bodyParameters.formatType = "NCSV";
                    break;
            }
        }

        private void UpdateBodyWithHttpContent()
        {

            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
            };

            var mediaType = new MediaTypeHeaderValue("application/json");
            _httpContent = JsonContent.Create(_bodyParameters, mediaType, options);

        }


    }

    
}
