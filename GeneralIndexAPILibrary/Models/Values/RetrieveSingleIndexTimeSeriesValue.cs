using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralIndexAPILibrary
{
    public class RetrieveSingleIndexTimeSeriesValue
    {
        [DisplayName("Code")]
        public string? Code { get; set; }
        [DisplayName("Period")]
        public int? Period { get; set; }
        [DisplayName("Period Type")]
        public string? PeriodType { get; set; }
        [DisplayName("Time Ref")]
        public string? TimeRef { get; set; }
        [DisplayName("Date")]
        public DateTime? Date { get; set; }
        [DisplayName("Factsheet Version")]
        public double? FactsheetVersion { get; set; }
        [DisplayName("High")]
        public double? High { get; set; }
        [DisplayName("Low")]
        public double? Low { get; set; }
        [DisplayName("Mid")]
        public double? Mid { get; set; }
        [DisplayName("Absolute Period")]
        public string? PeriodAbs { get; set; }
        [DisplayName("End Period")]
        public DateTime? PeriodEnd { get; set; }
        [DisplayName("Relative Period")]
        public int? PeriodRel { get; set; }
        [DisplayName("Start Period")]
        public DateTime? PeriodStart { get; set; }
        [DisplayName("Record Status")]
        public string? RecordStatus { get; set; }
    }
}
