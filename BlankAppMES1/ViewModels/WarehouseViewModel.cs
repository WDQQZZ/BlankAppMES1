using BlankAppMES1.Common;
using BlankAppMES1.Model.Warehouse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.ViewModels
{
    public class WarehouseViewModel : ModelBase
    {
        //BindingList解释：绑定列表，用于绑定到UI上，这个类是WPF中的类，用于绑定到UI上
        private WarehouseModel _warehouse;
        public WarehouseModel Warehouse//这行代码是用于绑定到UI上的
        {
            get { return _warehouse ?? (_warehouse = new WarehouseModel()); }
            set { _warehouse = value; OnPropertyChanged("Warehouse"); }
        }
        
        public WarehouseViewModel()
        {
            Warehouse = GetAll();
        }

        public WarehouseModel GetAll()
        {
            var list = HttpRequest.HttpHelper.NewGet("https://localhost:44329/api/app/warehouse/query");
            //SystemHomePageModel1接收list数据

            var show = JsonConvert.DeserializeObject<BindingList<WarehouseModel>>(list);

            return show[0];
        }


    }
}
