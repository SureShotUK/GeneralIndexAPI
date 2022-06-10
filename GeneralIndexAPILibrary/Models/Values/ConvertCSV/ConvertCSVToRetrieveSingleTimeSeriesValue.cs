using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary.Models.Values.ConvertCSV
{
    public class ConvertCSVToCSharp<T> where T : class
    {
        private List<T> rowsAsObjects;

        private Dictionary<int, string> _headers;

        private ConvertCSVToValue<T>? _converter;

        public List<T> CSVAsList { get { return rowsAsObjects; } }

        public ConvertCSVToCSharp(string csvString)
        {
            _headers = new Dictionary<int, string>();
            rowsAsObjects = new List<T>();

            if (!string.IsNullOrWhiteSpace(csvString))
            {
                using StringReader sr = new StringReader(csvString);
                string? line = sr.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    SetHeaders(line);
                }
                if (_headers.Count > 0)
                {
                    _converter = new(_headers);
                    line = sr.ReadLine();

                    while (!string.IsNullOrWhiteSpace(line))
                    {
                        AddLineToRows(line);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        private void SetHeaders(string headerRow)
        {
            if (string.IsNullOrWhiteSpace(headerRow)) return;
            string[] columnNames = headerRow.Split(',');
            if (columnNames.Length <= 0) return;

            List<string> propertyNames = GetPropertyNames();
            int columnIndex = 0;

            foreach (var columnName in columnNames)
            {
                if (propertyNames.Contains(columnName))
                {
                    if (_headers.ContainsKey(columnIndex)) _headers[columnIndex] = columnName;
                    else _headers.Add(columnIndex, columnName);
                }
                else
                {
                    foreach (var propertyName in propertyNames)
                    {
                        string colName = (propertyName.Length > columnName.Length) ?
                            columnName : columnName.Substring(0, propertyName.Length).ToLower();
                        string propName = (propertyName.Length < columnName.Length) ?
                            propertyName.ToLower() : propertyName.Substring(0, columnName.Length).ToLower();

                        if (propName == colName)
                        {
                            // Check to see if the propertyName is already in the dictionary, then check to see if the column index is in the dictionary
                            if (!_headers.Any(p => p.Value == propertyName))
                            {
                                if (!_headers.ContainsKey(columnIndex)) _headers.Add(columnIndex, propertyName);
                            }
                        }
                    }
                }
                columnIndex++;
            }
        }

        private void AddLineToRows(string csvRow)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            T? t = (T)Activator.CreateInstance(typeof(T));
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (t == null) return;
            t = _converter.ConvertCSVLine(csvRow, t);
            if (t is not null) rowsAsObjects.Add(t);
        }

        private static List<string> GetPropertyNames()
        {
            List<string> propertyNames = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                propertyNames.Add(property.Name);
            }
            return propertyNames;
        }
    }



    public class ConvertCSVToValue<T> where T : class
    {
        private T _value;

        private readonly Dictionary<int, string> _headers;

        public ConvertCSVToValue(Dictionary<int, string> Headers)
        {
            _headers = Headers;
        }

        public T? ConvertCSVLine(string csvLine, T RowObject)
        {
            _value = RowObject;
            if (string.IsNullOrWhiteSpace(csvLine)) return null;
            int columnCounter = 0;

            foreach (var column in csvLine.Split(','))
            {
                string propertyName = _headers.GetValueOrDefault(columnCounter);
                if (string.IsNullOrWhiteSpace(propertyName) || string.IsNullOrWhiteSpace(column))
                {
                    columnCounter++;
                    continue;
                }
                PropertyInfo? property = typeof(T).GetProperty(propertyName);
                if (property is null)
                {
                    columnCounter++;
                    continue;
                }
                AssignValueToProperty(property, column);
                columnCounter++;
            }
            return _value;
        }

        private void AssignValueToProperty(PropertyInfo propertyInfo, string valueToAssign)
        {
            Type propertyType = GetPropertyTypeAsType(propertyInfo);
            TypeCode typeCode = Type.GetTypeCode(propertyType);
            switch (typeCode)
            {
                case TypeCode.String:
                    propertyInfo.SetValue(_value, valueToAssign);
                    break;
                case TypeCode.Char:
                    char valueAsChar = Convert.ToChar(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsChar);
                    break;
                case TypeCode.Boolean:
                    bool valueAsBoolean = Convert.ToBoolean(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsBoolean);
                    break;
                case TypeCode.DateTime:
                    DateTime valueAsDateTime =
                        DateTime.Parse(valueToAssign, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
                    propertyInfo.SetValue(_value, valueAsDateTime);
                    break;
                case TypeCode.Int16:
                    Int16 valueAsInt16 = Convert.ToInt16(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsInt16);
                    break;
                case TypeCode.Int32:
                    Int32 valueAsInt32 = Convert.ToInt32(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsInt32);
                    break;

                case TypeCode.Int64:
                    Int64 valueAsInt64 = Convert.ToInt64(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsInt64);
                    break;
                case TypeCode.Decimal:
                    Decimal valueAsDecimal = Convert.ToDecimal(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsDecimal);
                    break;
                case TypeCode.Double:
                    Double valueAsDouble = Convert.ToDouble(valueToAssign);
                    propertyInfo.SetValue(_value, valueAsDouble);
                    break;
                default:
                    propertyInfo.SetValue(_value, valueToAssign);
                    break;
            }
        }


        private static Type GetPropertyTypeAsType(PropertyInfo propertyInfo)
        {
            Type? underlyingType = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
            if (underlyingType is null) return propertyInfo.PropertyType;
            return underlyingType;
        }
        
    }
}
