using BlankAppMES1.page;
using BlankAppMES1.PageModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.ViewModels
{
    public class MainViewModel : NotifyBase
    {
        // 菜单 集合
        public List<MenuItemModel> TreeList { get; set; }
        // 页面 集合
        public ObservableCollection<PageItemModel> Pages { get; set; }
            = new ObservableCollection<PageItemModel>();

        public MainViewModel()
        {
            #region 菜单初始化
            TreeList = new List<MenuItemModel>();
            {
                MenuItemModel tim = new MenuItemModel();
                
                TreeList.Add(new MenuItemModel
                {
                    Header = "订单管理",
                    TargetView = "MainWindow",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });

                TreeList.Add(new MenuItemModel
                {
                    Header = "生产概括",
                    TargetView = "BlankPage",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });

                TreeList.Add(new MenuItemModel
                {
                    Header = "历史记录",
                    TargetView = "History",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });
                TreeList.Add(new MenuItemModel
                {
                    Header = "立库管理",
                    TargetView = "Warehouse",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });
                TreeList.Add(new MenuItemModel
                {
                    Header = "设备管理",
                    TargetView = "Facility",
                    OpenViewCommand = new Command<MenuItemModel>(OpenView)
                });

            }
            #endregion

            #region 测试  页面初始
            // 所有数据集合都可以 VM中进行控件 （增加和删除）
            //Pages = new ObservableCollection<PageItemModel>();
            //Pages.Add("AAAA");
            //Pages.Add("BBBB");
            //Pages.Add("CCCC");
            //Pages.Add("DDDD");
            #endregion
        }

        private void OpenView(MenuItemModel menu)
        {
            // 两个问题：
            // 1、每点击一次都会有一个新的页面！  解决方案：从集合中判断是否存在
            // 2、新打开一个页面后，不能马上显示 

            //MenuItemModel mim = menu as MenuItemModel;
            // 需要进行页面的打开 
            //Pages.Add("EEEE");

            var page = Pages.ToList().FirstOrDefault(p => p.Header == menu.Header);

            if (page == null)
            {
                Type type = Assembly.GetExecutingAssembly().
                    GetType("BlankAppMES1.Views." + menu.TargetView);
                object p = Activator.CreateInstance(type);

                Pages.Add(new PageItemModel
                {
                    Header = menu.Header,
                    PageView = p,
                    IsSelected = true,
                    CloseTabCommand = new Command<PageItemModel>(ClosePage)
                });
            }
            else
                page.IsSelected = true;
        }

        private void ClosePage(PageItemModel menu)
        {
            Pages.Remove(menu);
        }
    }
}
