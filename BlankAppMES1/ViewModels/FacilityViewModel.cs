using BlankAppMES1.Common;
using BlankAppMES1.Model.Facility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.ViewModels
{
    public class FacilityViewModel: ModelBase
    {
        //添加
        private FacilityModel _facility;
        public FacilityModel facility
        {
            get { return _facility ?? (_facility = new FacilityModel()); }
            set { _facility = value; OnPropertyChanged("facility"); }
        }
        private CustomCommand _addCmd;//CustomCommand解释：自定义命令，用于绑定到UI上
        public CustomCommand AddCmd
        {
            //可以避免重复创建对象，
            //什么意思？这个类的实例只会创建一次，后面再次调用这个属性时就不会再创建对象了
            //有什么好处？避免重复创建对象，节省内存
            get { return _addCmd ?? (_addCmd = new CustomCommand(Add, CanAdd)); }
        }
        public void Add()
        {
            var xx = JsonConvert.SerializeObject(facility);

            var sss = HttpRequest.PostAsyncJson("https://localhost:44329/api/app/facility", xx);

            //this.GetAll();
        }
        public bool CanAdd()
        {
            return facility != null;//这行代码的意思？当People和person不为空时返回true，否则返回false
        }
    }
}
