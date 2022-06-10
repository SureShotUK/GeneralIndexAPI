using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public interface IGIResponse 
    { 
        int from { get; }
        int totalSize { get; }
        List<string> items { get; }
    }

    public class GIResponse : IGIResponse
    {
        public int from { get; set; }
        public List<string> items { get; set; }
        public int totalSize { get; set; }
    }

    public class RetrieveSymbolVariantsMessageResponse
    {
        public int from { get; set; }
        public List<RetrieveSymbolVariantsMessageResponseItem> items { get; set; }
        public int totalSize { get; set; }
    }

    public class RetrieveSingleIndexTimeSeriesResponse
    {
        public int from { get; set; }
        public List<RetrieveSymbolVariantsMessageResponseItem> items { get; set; }
        public int totalSize { get; set; }
    }

    public class RetrieveSymbolVariantsMessageResponseItem 
    {
        public string name { get; set; }
        public string type { get; set; }
    }



}
