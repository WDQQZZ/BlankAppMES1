using BlankAppMES1.Common;
using BlankAppMES1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.ViewModels
{
    public class ViewModel: ModelBase
    {
        //BindingList解释：绑定列表，用于绑定到UI上，这个类是WPF中的类，用于绑定到UI上
        private BindingList<SystemHomePageModel> _people;
        public BindingList<SystemHomePageModel> People//这行代码是用于绑定到UI上的
        {
            //解释：这里使用了C#的空合并运算符，如果_people不为空则返回_people，否则返回new BindingList<Person>()，
            //为什么这么写？因为这样可以避免重复创建对象，
            //这行代码的意思是：如果_people为空则创建一个新的对象并赋值给_people，然后返回_people
            get { return _people ?? (_people = new BindingList<SystemHomePageModel>()); }
            //这行代码的意思是：当_people发生变化时通知UI更新，UI会根据_people的变化来更新自己，而不需要手动更新
            set { _people = value; OnPropertyChanged("People"); }
        }

        public ViewModel()
        {
            People = GetAll();
        }

        public BindingList<SystemHomePageModel> GetAll()
        {
            var list = HttpRequest.HttpHelper.NewGet("https://localhost:44329/api/app/system-home-page/asyncss");
            //SystemHomePageModel1接收list数据

           var show = JsonConvert.DeserializeObject<BindingList<SystemHomePageModel>>(list);

            return show;
        }

        //添加
        private SystemHomePageModel _person;
        public SystemHomePageModel person
        {
            get { return _person ?? (_person = new SystemHomePageModel()); }
            set { _person = value; OnPropertyChanged("person"); }
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
            var xx = JsonConvert.SerializeObject(person);

            var sss = HttpRequest.PostAsyncJson("https://localhost:44329/api/app/system-home-page", xx);
            People.Add(person);

            //this.GetAll();
        }
        public bool CanAdd()
        {
            return People != null && person != null;//这行代码的意思？当People和person不为空时返回true，否则返回false
        }
    }
}
