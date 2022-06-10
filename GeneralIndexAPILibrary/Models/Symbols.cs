using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public class SingleIndexTimeSeriesContent
    {

        public DateTime startDate = new DateTime(2022, 4, 1, 0, 0, 0, 0);    //"2022-04-01T00:00:00.000";
        //public string endDate;
        public string timeZone = "Europe/London";
        public bool corrections = true;
        public string order = "desc";
        //public string onDateTime;
        public string formatType = "STANDARD";
        //public List<Key> keys = new List<Key>() { new Key() { columns = new List<string>() { "Index" }, groupName= "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", PeriodType = "Month", Period = "1", TimeRef = "1630" } } };
        public List<Key> keys = new List<Key>() { new Key() { groupName = "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", PeriodType = "Month", Period = 1, TimeRef = "1630" } } };

    }

    public class SingleIndexTimeSeriesKey
    {
        public string groupName = "Prod_Indexes";
        public Symbol symbols = new Symbol();
    }

    public class Symbol
    {
        [JsonPropertyName("Code")]
        public string Code { get; set; } = "GX0000257";  //"GX0000093";
        [JsonPropertyName("PeriodType")]
        public string PeriodType { get; set; }  = "Prompt";
        [JsonPropertyName("Period")] 
        public string Period { get; set; } = "1";
        [JsonPropertyName("TimeRef")] 
        public string TimeRef { get; set; } = "1630";
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Symbols
    {
        private string _periodType = "";
        private int _period = 0;
        private string _code = "";
        private string _timeRef = "";
        public string PeriodType { get { return _periodType; } set { if (!string.IsNullOrEmpty(value)) _periodType = value; } }
        public int Period { get { return _period; } set { _period = value; } }
        public string Code { get { return _code; } set { if (!string.IsNullOrEmpty(value)) _code = value; } }
        public string TimeRef { get { return _timeRef; } set { if (!string.IsNullOrEmpty(value)) _timeRef = value; } }

        public Symbols()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            if (!string.IsNullOrWhiteSpace(_code))
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append($"\"Code\":\"{_code}\"");
            }
            if (!string.IsNullOrWhiteSpace(_timeRef))
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append($"\"TimeRef\":\"{_timeRef}\"");
            }
            if (!string.IsNullOrWhiteSpace(_periodType))
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append($"\"PeriodType\":\"{_periodType}\"");
            }
            if (_period != 0)
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append($"\"Period\":\"{_period}\"");
            }
            return sb.ToString();
        }
    }

    public class Key
    {
        private bool? _pattern = null;
        private string _groupName = "Prod_Indexes";
        private Symbols _symbols;
        private Columns? _columns;
        public Symbols symbols { get { return _symbols; } set { _symbols = value; } }
        public string groupName { get { return _groupName; } set { if (!string.IsNullOrEmpty(value)) _groupName = value; } }
        public bool? Pattern { get { return _pattern; } set { _pattern = value; } }
        public Columns? columns { get { return _columns; } set { _columns = value; } }


        public Key()
        {
            _symbols = new();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            if (!string.IsNullOrWhiteSpace(groupName))
            {
                if (sb.Length > 0) sb.Append(',');
                sb.Append($"\"groupName\":\"{groupName}\"");
            }
            string symbol = symbols.ToString();
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                if (sb.Length > 0) sb.Append(',');
                sb.Append($"\"symbols\": {{ {symbol} }}");
            }
            if(_pattern != null)
            {
                if (sb.Length > 0) sb.Append(',');
                if (_pattern.Value) sb.Append($"\"pattern\":true");
                else sb.Append($"\"pattern\":false");
            }
            if(_columns != null)
            {
                string columnsString = _columns.ToString();
                if (!string.IsNullOrWhiteSpace(columnsString))
                {
                    if (sb.Length > 0) sb.Append(',');
                    sb.Append($"\"columns\": {columnsString}");
                }
            }
            if (sb.Length == 0) return string.Empty;
            return $"{{ {sb.ToString()} }}";
        }
    }

    public class Columns
    {
        public string FactsheetVersion = "";
        public string PeriodAbs = "";
        public string PeriodRel = "";
        public string PeriodStart = "";
        public string PeriodEnd = "";
        public string RecordStatus = ""; // N = New, C= Correction, D = Deleted

        public string Title = "";
        public string Alias = "";
        public string TimeZone = "";
        public string Currency = "";
        public string Units = "";
        public string HolidayCalendar = "";
        public string Source = "";
        public string DeliveryBasis = "";
        public string PricingBasis = "";
        public string Tradinghub = "";
        public string Commodity = "";
        public string Frequency = "";

        public Columns()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(FactsheetVersion)) sb.Append(FactsheetVersion);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(PeriodAbs)) sb.Append(PeriodAbs);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(PeriodRel)) sb.Append(PeriodRel);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(PeriodStart)) sb.Append(PeriodStart);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(PeriodEnd)) sb.Append(PeriodEnd);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(RecordStatus)) sb.Append(RecordStatus);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Title)) sb.Append(Title);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Alias)) sb.Append(Alias);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(TimeZone)) sb.Append(TimeZone);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Currency)) sb.Append(Currency);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Units)) sb.Append(Units);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(HolidayCalendar)) sb.Append(HolidayCalendar);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Source)) sb.Append(Source);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(DeliveryBasis)) sb.Append(DeliveryBasis);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(PricingBasis)) sb.Append(PricingBasis);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Tradinghub)) sb.Append(Tradinghub);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Commodity)) sb.Append(Commodity);
            if (sb.Length > 0) sb.Append(',');
            if (!string.IsNullOrWhiteSpace(Frequency)) sb.Append(Frequency);
            if (sb.Length == 0) return String.Empty;
            return "[" + sb.ToString() + "]";
        }

        public void AddFactsheetVersion() { FactsheetVersion = "\"" + nameof(FactsheetVersion) + "\""; }
        public void AddPeriodAbs() { PeriodAbs = "\"" + nameof(PeriodAbs) + "\""; }
        public void AddPeriodRel() { PeriodRel = "\"" + nameof(PeriodRel) + "\""; }
        public void AddPeriodStart() { PeriodStart = "\"" + nameof(PeriodStart) +"\""; }
        public void AddPeriodEnd() { PeriodEnd = "\"" + nameof(PeriodEnd) + "\""; }
        public void AddRecordStatus() { RecordStatus = "\"" + nameof(RecordStatus) +"\""; }
        public void AddTitle() { Title = "\"" + nameof(Title) + "\""; }
        public void AddAlias() {  Alias = "\"" + nameof(Alias) + "\""; }
        public void AddTimeZone() { TimeZone = "\"" + nameof(TimeZone) + "\""; }
        public void AddCurrency() { Currency = "\"" + nameof(Currency) + "\""; }
        public void AddUnits() { Units = "\"" + nameof(Units) + "\""; }
        public void AddHolidayCalendar() { HolidayCalendar = "\"" + nameof(HolidayCalendar) + "\""; }
        public void AddSource() { Source = "\"" + nameof(Source) + "\""; }
        public void AddDeliveryBasis() { DeliveryBasis = "\"" + nameof(DeliveryBasis) + "\""; }
        public void AddPricingBasis() { PricingBasis = "\"" + nameof(PricingBasis) + "\""; }
        public void AddTradinghub() { Tradinghub = "\"" + nameof(Tradinghub) + "\""; }
        public void AddCommodity() { Commodity = "\"" + nameof(Commodity) + "\""; }
        public void AddFrequency() { Frequency = "\"" + nameof(Frequency) + "\""; }

        public void RemoveFactsheetVersion() { FactsheetVersion = ""; }
        public void RemovePeriodAbs() { PeriodAbs = ""; }
        public void RemovePeriodRel() { PeriodRel = ""; }
        public void RemovePeriodStart() { PeriodStart = ""; }
        public void RemovePeriodEnd() { PeriodEnd = ""; }
        public void RemoveRecordStatus() { RecordStatus = ""; }
        public void RemoveTitle() { Title = ""; }
        public void RemoveAlias() { Alias = ""; }
        public void RemoveTimeZone() { TimeZone = ""; }
        public void RemoveCurrency() { Currency = ""; }
        public void RemoveUnits() { Units = ""; }
        public void RemoveHolidayCalendar() { HolidayCalendar = ""; }
        public void RemoveSource() { Source = ""; }
        public void RemoveDeliveryBasis() { DeliveryBasis = ""; }
        public void RemovePricingBasis() { PricingBasis = ""; }
        public void RemoveTradinghub() { Tradinghub = ""; }
        public void RemoveCommodity() { Commodity = ""; }
        public void RemoveFrequency() { Frequency = ""; }

    }




    public class Root
    {
        public string timeZone { get; set; }
        public string formatType { get; set; }
        public DateTime startDate { get; set; }
        public bool corrections { get; set; }
        public string order { get; set; }
        public List<Key> keys { get; set; }
    }

    public static class GetObjectsToSerialize
    {
        public static Root GetSingleTimeSeriesObject()
        {
            Root root = new Root()
            {
                timeZone = "Europe/London",
                formatType = "STANDARD",
                startDate = new DateTime(2020, 7, 1, 10, 1, 3, 999),
                corrections = true,
                order = "desc",
                // keys = new List<Key>() { new Key() { columns = new List<string> { "Index" }, groupName = "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", Period = "Month", PeriodType = "1", TimeRef = "1630" } } }
                keys = new List<Key>() { new Key() { groupName = "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", PeriodType = "Month", Period = 1, TimeRef = "1630" } } }
            };
            return root;
        }

        public static Root GetMultipleTimeSeriesForAnIndexSeriesObject()
        {
            Root root = new Root()
            {
                timeZone = "Europe/London",
                formatType = "STANDARD",
                startDate = new DateTime(2020, 7, 1, 10, 1, 3, 999),
                corrections = true,
                order = "desc",
                //keys = new List<Key>() { new Key() { columns = new List<string> { "Index" }, groupName = "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", Period = "Month", PeriodType = "1", TimeRef = "1630" } } }
                keys = new List<Key>() { new Key() { groupName = "Prod_Indexes", symbols = new Symbols() { Code = "GX0000001", PeriodType = "Month", Period = 1, TimeRef = "1630" } } }
            };
            return root;
        }
    }

}
