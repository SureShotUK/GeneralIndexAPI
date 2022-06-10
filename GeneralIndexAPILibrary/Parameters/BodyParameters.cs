using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{

    public interface IBodyParameters
    {
        //Dictionary<string, string> SimpleKeyValuePairs { get; }
        void AddToSimpleKeyValuePairs(string Key, string Value);

        string SimpleKeyValuePairsToString();

        //string ToString();
    }
    public class BodyParameters : IBodyParameters
    {
        private Dictionary<string, string> _simpleKeyValuePairs;
        //public Dictionary<string, string> SimpleKeyValuePairs { get { return _simpleKeyValuePairs; } }

        

        public BodyParameters()
        {
            _simpleKeyValuePairs = new();
        }

        public void AddToSimpleKeyValuePairs(string Key, string Value)
        {
            if(_simpleKeyValuePairs.ContainsKey(Key)) _simpleKeyValuePairs[Key] = Value;
            else _simpleKeyValuePairs.Add(Key, Value);
        }

        protected string GetValue(string keyString)
        {
            if (_simpleKeyValuePairs.TryGetValue(keyString, out string result)) return result;
            return string.Empty;
        }

        protected void SetValue(string keyString, string valueString)
        {
            if (_simpleKeyValuePairs.ContainsKey(keyString)) _simpleKeyValuePairs[keyString] = valueString;
            _simpleKeyValuePairs.Add(keyString, valueString);
        }

        public string SimpleKeyValuePairsToString()
        {
            if (_simpleKeyValuePairs.Count <= 0) return string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach(var pair in _simpleKeyValuePairs)
            {
                if (sb.Length > 0) sb.Append(',');
                sb.Append($"\"{pair.Key}\":\"{pair.Value}\"");
            }
            return sb.ToString();
        }

        //public override string ToString()
        //{
        //    return $"{{ {SimpleKeyValuePairsToString()} }}";
        //}
    }

    public class ReTrieveSymbolVariantsBodyParameters : BodyParameters, IBodyParameters 
    {
        public string GroupName 
        { 
            get { return GetValue("groupName"); }
            set { SetValue("groupName", value); } 
        }

        public string Key
        {
            get { return GetValue("key"); }
            set { SetValue("key", value); }
        }

        public ReTrieveSymbolVariantsBodyParameters() : base()
        {
            SetValue("groupName", "Prod_Indexes");
        }

        //public override string ToString()
        //{
        //    return $"{{ {SimpleKeyValuePairsToString()} }}";
        //}
    }
}
