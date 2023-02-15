using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.Common
{
    //INotifyPropertyChanged：属性更改通知用于通知UI更新
    //这个接口是MVVM中的核心当属性发生变化时通知UI更新
    //这样UI就可以根据属性的变化来更新自己，而不需要手动更新
    public class ModelBase : INotifyPropertyChanged
    {
        //PropertyChangedEventHandler解释：属性更改事件处理程序，用于通知UI更新，event关键字表示这是一个事件
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                //PropertyChangedEventArgs解释：属性更改事件参数，用于通知UI更新
                //这里的propertyName是属性的名称,这个参数是用来告诉UI哪个属性发生了变化
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            //什么是索引的最右匹配原则？
        }
    }
}
