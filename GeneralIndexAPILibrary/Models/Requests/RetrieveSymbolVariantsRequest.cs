using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GeneralIndexAPILibrary.Models;

namespace GeneralIndexAPILibrary
{
    #region RetrieveSymbol Variants

    public class RetrieveSymbolVariantsRequest : GIRequest, IGIRequest
    {
        private ReTrieveSymbolVariantsBodyParameters _bodyParameters;

        public new HttpContent Content
        {
            get
            {
                UpdateBodyWithHttpContent();
                return _httpContent;
            }
        }

        
        public int URLParamFrom
        {
            get { return GetIntURLParameter("from"); }
            set { if (value >= 0) SetURLParameter("from", value); }
        }
        public int URLParamLimit
        {
            get { return GetIntURLParameter("limit"); }
            set { if (value >= 0) SetURLParameter("limit", value); }
        }

        public string URLParamSort
        {
            get { return GetURLParameter("sort"); }
        }

        public RetrieveSymbolVariantsRequest() : base(GIRequestType.RETRIEVE_SYMBOL_VARIANTS)
        {
            _bodyParameters = new ReTrieveSymbolVariantsBodyParameters();
        }

        public void SetURLParameterSort(SortParamOptions param)
        {
            switch (param)
            {
                case SortParamOptions.ASC:
                    SetURLParameter("sort", "ASC");
                    break;
                case SortParamOptions.DESC:
                    SetURLParameter("sort", "DESC");
                    break;
            }
        }

        public void SetBodyParameterKey(KeyParamOptions KeyParamOption)
        {
            switch (KeyParamOption)
            {
                case (KeyParamOptions.CODE):
                    _bodyParameters.AddToSimpleKeyValuePairs("key", "Code");
                    break;
                case (KeyParamOptions.PERIODTYPE):
                    _bodyParameters.AddToSimpleKeyValuePairs("key", "PeriodType");
                    break;
                case (KeyParamOptions.PERIOD):
                    _bodyParameters.AddToSimpleKeyValuePairs("key", "Period");
                    break;
                case (KeyParamOptions.TIMEREF):
                    _bodyParameters.AddToSimpleKeyValuePairs("key", "TimeRef");
                    break;
            }
        }

        public void SetBodyParameterGroupName(string groupName = "Prod_Indexes")
        {
            _bodyParameters.AddToSimpleKeyValuePairs("groupName", groupName);
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

    #endregion
}
