using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlankAppMES1.PageModel
{
    public class MenuItemModel
    {
        public string IconCode { get; set; }
        public string Header { get; set; }
        public string TargetView { get; set; }

        public ICommand OpenViewCommand { get; set; }

        public List<MenuItemModel> Children { get; set; } = new List<MenuItemModel>();

    }
}
