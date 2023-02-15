using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlankAppMES1.Common
{
    public class CustomCommand : ICommand
    {
        private Action _executeMethod;//Action 解释：委托，用于执行方法
        private Func<bool> _canExecuteMethod;//Func 解释：委托，用于判断是否可以执行方法
        public CustomCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null)
            {
                throw new ArgumentNullException("executeMethod");//ArgumentNullException 解释：参数为空异常 
            }
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged; //EventHandler 解释：事件处理程序，用于通知UI更新
        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod == null) return true;
            return _canExecuteMethod();
        }
        public void Execute(object parameter)
        {
            if (_executeMethod != null)
                _executeMethod();
        }
    }
}
