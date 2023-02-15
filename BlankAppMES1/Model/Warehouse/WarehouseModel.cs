using BlankAppMES1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Model.Warehouse
{
    public class WarehouseModel : ModelBase
    {
        /// <summary>
        /// 加工空托盘A0
        /// </summary>
        private int trayAZero;
        public int TrayAZero
        {
            get { return trayAZero; }
            set { trayAZero = value; OnPropertyChanged("TrayAZero"); }
        }
        /// <summary>
        /// 加工毛胚托盘A1
        /// </summary>
        private int trayHairGermAOne;
        public int TrayHairGermAOne
        {
            get { return trayHairGermAOne; }
            set { trayHairGermAOne = value; OnPropertyChanged("TrayHairGermAOne"); }
        }
        /// <summary>
        /// 加工成品托盘A1
        /// </summary>
        private int traySucceedATwo;
        public int TraySucceedATwo
        {
            get { return traySucceedATwo; }
            set { traySucceedATwo = value; OnPropertyChanged("TraySucceedATwo"); }
        }
        /// <summary>
        /// 检测完成托盘A3
        /// </summary>
        private int trayDetectionOkAThree;
        public int TrayDetectionOkAThree
        {
            get { return trayDetectionOkAThree; }
            set { trayDetectionOkAThree = value; OnPropertyChanged("TrayDetectionOkAThree"); }
        }
        /// <summary>
        /// 轴承压装毛胚托盘B1
        /// </summary>
        private int trayBearingBOne;
        public int TrayBearingBOne
        {
            get { return trayBearingBOne; }
            set { trayBearingBOne = value; OnPropertyChanged("TrayBearingBOne"); }
        }
        /// <summary>
        /// 轴承压装成品托盘B2
        /// </summary>
        private int trayBearingBTwo;
        public int TrayBearingBTwo
        {
            get { return trayBearingBTwo; }
            set { trayBearingBTwo = value; OnPropertyChanged("TrayBearingBTwo"); }
        }
        /// <summary>
        /// 轴承压装完成托盘B0
        /// </summary>
        private int trayBearingBZero;
        public int TrayBearingBZero
        {
            get { return trayBearingBZero; }
            set { trayBearingBZero = value; OnPropertyChanged("TrayBearingBZero"); }
        }
        /// <summary>
        /// 拧螺钉空托盘C0
        /// </summary>
        private int trayScrewCZero;
        public int TrayScrewCZero
        {
            get { return trayScrewCZero; }
            set { trayScrewCZero = value; OnPropertyChanged("TrayScrewCZero"); }
        }
        /// <summary>
        /// 拧螺钉打毛胚托盘C1
        /// </summary>
        private int trayScrewCOne;
        public int TrayScrewCOne
        {
            get { return trayScrewCOne; }
            set { trayScrewCOne = value; OnPropertyChanged("TrayScrewCOne"); }
        }
        /// <summary>
        /// 拧螺钉完成托盘C
        /// </summary>
        private int trayScrewBearing;
        public int TrayScrewBearing
        {
            get { return trayScrewBearing; }
            set { trayScrewBearing = value; OnPropertyChanged("TrayScrewBearing"); }
        }
        /// <summary>
        /// 轴承托盘D
        /// </summary>
        private int trayBearingDOne;
        public int TrayBearingDOne
        {
            get { return trayBearingDOne; }
            set { trayBearingDOne = value; OnPropertyChanged("TrayBearingDOne"); }
        }
        /// <summary>
        /// 螺钉托盘E
        /// </summary>
        private int trayBoltEOne;
        public int TrayBoltEOne
        {
            get { return trayBoltEOne; }
            set { trayBoltEOne = value; OnPropertyChanged("TrayBoltEOne"); }
        }
        /// <summary>
        /// 库位无托盘
        /// </summary>
        private int WarehouseNoTray;
        public int warehouseNoTray
        {
            get { return WarehouseNoTray; }
            set { WarehouseNoTray = value; OnPropertyChanged("warehouseNoTray"); }
        }
        private string warehouseId;
        public string WarehouseId
        {
            get { return warehouseId; }
            set { warehouseId = value; OnPropertyChanged("WarehouseId"); }
        }
    }
}
