using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public static class URLParamsHelper
    {

        #region Encoding
        public static string EncodeCredentials(string username, string password)
        {
            string credentials = username + ":" + password;
            string base64_enc = Base64Encode(credentials);
            return "Basic " + base64_enc;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        #endregion
        #region URI Query Strings
        public static string GetUriFromParams(string requestUri,
            Dictionary<string, string> queryStringParams)
        {
            if (queryStringParams == null || queryStringParams.Count == 0) return requestUri;
            bool addFirstChar = true;
            if (requestUri[requestUri.Length - 1] == '=') addFirstChar = false;
            bool startingQuestionMarkAdded = false;
            var sb = new StringBuilder();
            sb.Append(requestUri);
            foreach (var parameter in queryStringParams)
            {
                if (parameter.Value == null || parameter.Value == "empty")
                {
                    continue;
                }

                if(addFirstChar) sb.Append(startingQuestionMarkAdded ? '&' : '?');
                addFirstChar = true;

                sb.Append(parameter.Key);
                sb.Append('=');
                sb.Append(parameter.Value);
                startingQuestionMarkAdded = true;
            }
            return sb.ToString();
        }


        //public static string GetSearchUriWithQueryString(string requestUri,
        //    Dictionary<string, string> queryStringParams)
        //{
        //    if (queryStringParams == null || queryStringParams.Count == 0) return requestUri;
        //    bool startingQuestionMarkAdded = false;
        //    var sb = new StringBuilder();
        //    sb.Append(requestUri);
        //    foreach (var parameter in queryStringParams)
        //    {
        //        if (parameter.Value == null || parameter.Value == "empty")
        //        {
        //            continue;
        //        }

        //        sb.Append(startingQuestionMarkAdded ? '&' : "?query=");
        //        sb.Append(parameter.Key);
        //        sb.Append('=');
        //        sb.Append(parameter.Value);
        //        startingQuestionMarkAdded = true;
        //    }
        //    return sb.ToString();
        //}
        #endregion URI Query Strings
    }
}
