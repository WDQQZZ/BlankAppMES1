using BlankAppMES1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Model
{
    public class SystemHomePageModel:ModelBase
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType;
        public string OrderType1 //为什么这么写？因为这样可以避免重复创建对象
        { 
            get { return OrderType; }
            set { OrderType = value; OnPropertyChanged("OrderType1"); }//这行代码的意思是：当_OrderType发生变化时通知UI更新，UI会根据_OrderType的变化来更新自己，而不需要手动更新
        }
        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderNum;
        public int OrderNum1
        {
            get { return OrderNum; }
            set { OrderNum = value;OnPropertyChanged("OrderNum1"); }
        }
        /// <summary>
        /// 上料类型
        /// </summary>
        public string FeedingType;
        public string FeedingType1
        {
            get { return FeedingType; }
            set { FeedingType = value; OnPropertyChanged("FeedingType1"); }
        }
        /// <summary>
        /// 料盘参数
        /// </summary>
        public decimal TrayParameter;
        public decimal TrayParameter1
        {
            get { return TrayParameter; }
            set { TrayParameter = value; OnPropertyChanged("TrayParameter1"); }
        }
        /// <summary>
        /// 下料类型
        /// </summary>
        public string BlankingType;
        public string BlankingType1
        {
            get { return BlankingType; }
            set { BlankingType = value; OnPropertyChanged("BlankingType1"); }
        }
    }
}
