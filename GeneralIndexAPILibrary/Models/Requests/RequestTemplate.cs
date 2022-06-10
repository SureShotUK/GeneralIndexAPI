using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


using GeneralIndexAPILibrary.Models;

namespace GeneralIndexAPILibrary.Requests
{
    public class RequestTemplate : GIRequest, IGIRequest   // 1
    {

//      1. Inherit from GIRequrest and Implement the interface IGIRequest
//      2. Add the bodyParameters field and make the RequestBodyParameters class
//      3. Add any URL parameters properties
//      4. Add any body properties
//      5. For those params that require a choice make the enums for those choices and chenge the properties to only use Get, make the set into a method
//      6. Add the enums to handle the cohoices for the URL or body parameters
//      7. Add the HttpContent property


        private ReTrieveSymbolVariantsBodyParameters _bodyParameters;   //  2

        // for each URL Param we need to enter a property to handle get and set
        public int URLParamLimit                                        //3
        {
            get { return GetIntURLParameter("limit"); }
            set { if (value >= 0) SetURLParameter("limit", value); }
        }

        public string URLParamSort                          //  4
        {
            get { return GetURLParameter("sort"); }
        }

        public new HttpContent Content               //  7
        {
            get
            {
                _httpContent = JsonContent.Create(_bodyParameters);
                return _httpContent;
            }
        }


        public void SetURLParameterSort(SortParamOptions param)     //  5
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

        public void SetBodyParameterKey(KeyParamOptions KeyParamOption)     //  5
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


    }
}
