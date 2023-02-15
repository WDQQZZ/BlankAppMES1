using BlankAppMES1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Model
{
    public class HistoryOrderModel:ModelBase
    {
        private string orderNumber;
        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; OnPropertyChanged("OrderNumber"); }
        }
        private string createOrderTime;
        public string CreateOrderTime
        {
            get { return createOrderTime; }
            set { createOrderTime  =value; OnPropertyChanged("CreateOrderTime");}
        }

        private string orderType;
        public string OrderType
        {
            get { return orderType; }
            set { orderType = value; OnPropertyChanged("OrderType"); }
        }
        private int orderNum;
        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; OnPropertyChanged("OrderNum"); }
        }
        private int accomplishNumber;
        public int AccomplishNumber
        {
            get { return accomplishNumber; }
            set { accomplishNumber = value; OnPropertyChanged("AccomplishNumber"); }
        }
        private string orderType1;
        public string OrderType1
        {
            get { return orderType1; }
            set { orderType1 = value; OnPropertyChanged("OrderType1"); }
        }
        private string feedingType;
        public string FeedingType
        {
            get { return feedingType; }
            set { feedingType = value; OnPropertyChanged("FeedingType"); }
        }
        private string blankingType;
        public string BlankingType
        {
            get { return blankingType; }
            set { blankingType = value; OnPropertyChanged("BlankingType"); }
        }
        private decimal trayParameter;
        public decimal TrayParameter
        {
            get { return trayParameter; }
            set { trayParameter = value; OnPropertyChanged("TrayParameter"); }
        }
    }
}
