using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Model.QueryDTO
{
    public class HistoryOrderQueryDto
    {
        public DateTime? createTime { get; set; }
        public DateTime? eddTime { get; set; }
        public string OrderTypeOne { get; set; }
        public string orderType { get; set; }
    }
}
