using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public interface IGIKey
    {
        string groupName { get; set; }
        Symbols symbols { get; set; }
        Columns columns { get; set; }

    }

    public class GIKey : IGIKey
    {
        private string _groupName = "Prod_Indexes";
        private Symbols _symbols;
        private Columns _columns;
        public string groupName
        {
            get { return _groupName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) ResetGroupName();
                else _groupName = value;
            }
        }
        public Symbols symbols { get { return _symbols;  } set { _symbols = value; } }
        public Columns columns { get { return _columns; } set { _columns = value; } }

        private void ResetGroupName()
        {
            _groupName = "Prod_Indexes";
        }
    }
}
