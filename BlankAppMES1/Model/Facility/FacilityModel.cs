using BlankAppMES1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Model.Facility
{
    public class FacilityModel : ModelBase
    {
        /// <summary>
        /// 动作类型
        /// </summary>
        private string typeOfAction;
        public string TypeOfAction
        {
            get { return typeOfAction; }
            set { typeOfAction = value; OnPropertyChanged("TypeOfAction"); }
        }
        /// <summary>
        /// 库位号
        /// </summary>
        private int warehouseNumber;
        public int WarehouseNumber
        {
            get { return warehouseNumber; }
            set { warehouseNumber = value; OnPropertyChanged("WarehouseNumber"); }
        }
        /// <summary>
        /// 托盘类型
        /// </summary>
        private string trayType;
        public string TrayType
        {
            get { return trayType; }
            set { trayType = value; OnPropertyChanged("TrayType"); }
        }
        /// <summary>
        /// 起点地图点
        /// </summary>
        private string originMap;
        public string OriginMap
        {
            get { return originMap; }
            set { originMap = value; OnPropertyChanged("OriginMap"); }
        }
        /// <summary>
        /// 终止地图点
        /// </summary>
        private string terminationMap;
        public string TerminationMap
        {
            get { return terminationMap; }
            set { terminationMap = value; OnPropertyChanged("TerminationMap"); }
        }
    }
}
