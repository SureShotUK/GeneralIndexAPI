using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary.Parameters
{
    public class RetrieveSingleIndexTimeSeriesBodyParameters : BodyParameters, IBodyParameters
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? timeZone { get; set; }
        public bool? corrections { get; set; } 
        public string? order { get; set; }
        public DateTime? onDateTime { get; set; }
        public string? formatType { get; set; } 
        public bool? metadata { get; set; }
        public int? decimalPrecision { get; set; } 
        public bool? delta { get; set; }

        private List<RetrieveSingleIndexKeys> _keys = new() { new RetrieveSingleIndexKeys() };
        public List<RetrieveSingleIndexKeys> keys { get { return _keys; } } 
        private bool _addKey = false;

        public void AddNewKey(RetrieveSingleIndexKeys key)
        {
            if (_addKey)
            {
                _keys.Add(key);
            }
            else
            {
                _keys = new() { key };
                _addKey = true;
            }
        }

        

    }


    public class RetrieveSingleIndexKeys
    {
        public string groupName { get; set; } = "Prod_Indexes";
        public Symbol symbols { get; set; } = new();
        public List<string>? columns { get; set; }

        public void AddNewColumn(string columnToAdd)
        {
            if (string.IsNullOrWhiteSpace(columnToAdd)) return;
            if (columns == null) columns = new();
            if(!columns.Contains(columnToAdd)) columns.Add(columnToAdd);
        }
    }
}
