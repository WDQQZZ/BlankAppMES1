using BlankAppMES1.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace BlankAppMES1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            //InitializeComponent解释：初始化组件，这个方法是WPF中的方法，用于初始化UI
            InitializeComponent();

            this.DataContext = new ViewModel();//这行代码是用于绑定到UI上的
            //lbTodoList.ItemsSource = items;
            
        }
       

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
