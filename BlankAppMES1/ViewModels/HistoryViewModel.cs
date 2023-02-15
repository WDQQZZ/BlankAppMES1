using BlankAppMES1.Common;
using BlankAppMES1.Model;
using BlankAppMES1.Model.QueryDTO;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankAppMES1.ViewModels
{
    public class HistoryViewModel: ModelBase
    {
        //BindingList解释：绑定列表，用于绑定到UI上，这个类是WPF中的类，用于绑定到UI上
        private BindingList<HistoryOrderModel> _history;
        public BindingList<HistoryOrderModel> History//这行代码是用于绑定到UI上的
        {
            get { return _history ?? (_history = new BindingList<HistoryOrderModel>()); }
            set { _history = value; OnPropertyChanged("History"); }
        }

        private HistoryOrderQueryDto _historyOrderQuery;
        public HistoryOrderQueryDto HistoryOrderQuery
        {
            get { return _historyOrderQuery ?? (_historyOrderQuery = new HistoryOrderQueryDto()); }
            set { _historyOrderQuery = value; OnPropertyChanged("HistoryOrderQuery"); }
        }

        private CustomCommand _QueryCmd;
        //CustomCommand
        public CustomCommand QueryCmd
        {
            get { return _QueryCmd ?? (_QueryCmd = new CustomCommand(Query, CanAdd)); }
        }

        private CustomCommand _ExcelCmd;
        //CustomCommand
        public CustomCommand ExcelCmd
        {
            get { return _ExcelCmd ?? (_ExcelCmd = new CustomCommand(Excel, CanAdd)); }
        }

        public HistoryViewModel()
        {
            History = GetAll();
        }

        //查询
        public void Query()
        {

            History = GetAll();

        }

        public BindingList<HistoryOrderModel> GetAll()
        {
            var jsonaddQuery = JsonConvert.SerializeObject(HistoryOrderQuery);

            
            var list = HttpRequest.HttpHelper.NewGet($"https://localhost:44329/api/app/order/query-condition-two?createTime=" +
                $"{HistoryOrderQuery.createTime}&eddTime={HistoryOrderQuery.eddTime}" +
                $"&OrderTypeOne={HistoryOrderQuery.OrderTypeOne}&orderType={HistoryOrderQuery.orderType}");
            //SystemHomePageModel1接收list数据

            var show = JsonConvert.DeserializeObject<BindingList<HistoryOrderModel>>(list);

            return show;
        }

        //Excel导出
        public void Excel()
        {
            List<HistoryOrderModel> HistoryOrder = History.ToList();

            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = (HSSFSheet)workbook.CreateSheet("历史记录表");

            //创建第一行

            IRow title = sheet.CreateRow(0);
            title.CreateCell(0).SetCellValue("订单号");
            title.CreateCell(1).SetCellValue("下单时间");
            title.CreateCell(2).SetCellValue("订单类型");
            title.CreateCell(3).SetCellValue("订单数量");
            title.CreateCell(4).SetCellValue("完成数量");
            title.CreateCell(5).SetCellValue("订单类型1");
            title.CreateCell(6).SetCellValue("上料类型");
            title.CreateCell(7).SetCellValue("下料类型");
            title.CreateCell(8).SetCellValue("料盘参数");

            int i = 0;

            foreach (var item in HistoryOrder)
            {
                IRow title2 = sheet.CreateRow(i++);
                title2.CreateCell(0).SetCellValue(item.OrderNumber);
                title2.CreateCell(1).SetCellValue(item.CreateOrderTime);
                title2.CreateCell(2).SetCellValue(item.OrderType);
                title2.CreateCell(3).SetCellValue(item.OrderNum);
                title2.CreateCell(4).SetCellValue(item.AccomplishNumber);
                title2.CreateCell(5).SetCellValue(item.OrderType1);
                title2.CreateCell(6).SetCellValue(item.FeedingType);
                title2.CreateCell(7).SetCellValue(item.BlankingType);
                title2.CreateCell(8).SetCellValue((double)item.TrayParameter);
            }

           

            string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";

            using (FileStream fileStream = new FileStream($@"F:\实训二\导出Excel\{FileName}.xls", FileMode.Create))
            {
                workbook.Write(fileStream);
            }
        }

        //Excel导入
        public void ExcelIn()
        {
            //打开文件
            FileStream fileStream = new FileStream(@"F:\实训二\导出Excel\20230210205739.xls.xls", FileMode.Open, FileAccess.Read);

            //创建工作簿
            HSSFWorkbook workbook = new HSSFWorkbook(fileStream);

            //获取第一个工作表
            ISheet sheet = workbook.GetSheetAt(0);

            //获取表中的数据行数
            int rows = sheet.LastRowNum;

            //遍历行
            for (int i = 1; i <= rows; i++)
            {
                //获取行
                IRow row = sheet.GetRow(i);

                //获取行中的数据列数
                int cells = row.LastCellNum;

                //遍历列
                for (int j = 0; j < cells; j++)
                {
                    //获取列
                    ICell cell = row.GetCell(j);

                    //获取列中的数据
                    string value = cell.ToString();

                    //输出数据
                    List<HistoryOrderModel> historyOrderModels = new List<HistoryOrderModel>();
                    //把value的值存入List<HistoryOrderModel>
                    
                }
            }
        }


        public bool CanAdd()
        {
            return History != null && HistoryOrderQuery != null;
        }
    }
}
