using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public class RetrieveSymbolVariantsResponse
    {
        private List<string> _allItems;
        public List<string> AllItems { get { return _allItems; } }

        public RetrieveSymbolVariantsResponse()
        {
            _allItems = new List<string>();
        }

        public void AddNewItemsToAllItems(List<string> items)
        {
            foreach (var item in items)
            {
                _allItems.Add(item);
            }
        }

        public void AddResponseItemsToRetrieveSymbolVariantsResponse(GIResponse response)
        {

            if (response != null) AddNewItemsToAllItems(response.items);
        }

    }
}
