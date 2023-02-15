using BlankAppMES1.Common;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace BlankAppMES1.ViewModels
{
    public class MainWindowViewModel : BindableBase //BindableBase 为可绑定的基类 
    {
        private string _title = "Prism Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); } //SetProperty翻译 Set属性 //解释SetProperty 为什么要用这个方法
                                                    // 1. 为了实现属性的绑定
                                                    // 2. 为了实现属性的通知
                                                    // 3. 为了实现属性的验证
        }

        private List<SystemHomePageModel1> _List;

        
        //DelegateCommand 为委托命令
        public DelegateCommand Text { get; set; }

        public DelegateCommand Add { get; set; }

        public List<SystemHomePageModel1> show {
            get { return _List; }
            set { SetProperty(ref _List, value); }
        }

        public MainWindowViewModel() //MainWindowViewModel翻译 主窗口视图模型
        {
            //Binding中文解释 绑定
            //Grid解释 网格
            //Border解释 边框 BorderBrush 边框画刷
            //HorizontalAlignment解释 水平对齐 Center 居中
            //VerticalAlignment解释 垂直对齐 VerticalAlignment的Center解释 垂直对齐的中心
            //Margin解释 边距 Thickness解释 厚度

            //NotifyPropertyChanged解释：当属性值发生变化时，通知绑定的控件更新数据
            Text = new DelegateCommand(GetList);
            Add = new DelegateCommand(AddList);
        }
        List<SystemHomePageModel1> xx = new List<SystemHomePageModel1>();
        public void GetList()
        {
            var list = HttpRequest.HttpHelper.NewGet("https://localhost:44329/api/app/system-home-page/asyncss");
            //SystemHomePageModel1接收list数据
            
            show = JsonConvert.DeserializeObject<List<SystemHomePageModel1>>(list);
        }
        //添加
        public void AddList()
        {
            string ss = "";

            string sss = HttpRequest.HttpHelper.Post("https://localhost:44329/api/app/system-home-page/asyncss", ss, "string");
        }

        //生成HttpHelper帮助类用于请求后台post接口
        


    }

    public class SystemHomePageModel1: ModelBase
    {
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 上料类型
        /// </summary>
        public string FeedingType { get; set; }
        /// <summary>
        /// 料盘参数
        /// </summary>
        public decimal TrayParameter { get; set; }
        /// <summary>
        /// 下料类型
        /// </summary>
        public string BlankingType { get; set; }
    }
}
