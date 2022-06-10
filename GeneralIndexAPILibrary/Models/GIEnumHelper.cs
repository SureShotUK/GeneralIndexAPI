using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary.Models
{
    public static class GetAsEnum
    {
        public static SortParamOptions SortParamOptionsFromString(string sort)
        {
            switch (sort.ToLower())
            {
                case "asc":
                    return SortParamOptions.ASC;
                case "desc":
                    return SortParamOptions.DESC;
                case "empty":
                    return SortParamOptions.ASC;
                default:
                    throw new ArgumentException($"There is no SortParamOptions with the value {sort}.");
            }
        }
    }
}
