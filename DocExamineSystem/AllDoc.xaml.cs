using Bll;
using Dal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DocExamineSystem
{
    /// <summary>
    /// AllDoc.xaml 的交互逻辑
    /// </summary>
    public partial class AllDoc : Window
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string userId = string.Empty;

        /// <summary>
        /// 队伍名称
        /// </summary>
        public string userName = string.Empty;
        
        /// <summary>
        /// 文档路径
        /// </summary>
        public string docPath = string.Empty;

        /// <summary>
        /// 数据库连接实例
        /// </summary>
        DBHelper db = new DBHelper();

        /// <summary>
        /// 数据库查询结果集
        /// </summary>
        DataTable dbDataTable = null;

        /// <summary>
        /// 操作WORD的方法实例
        /// </summary>
        WaysOfWord waysOfWord = new WaysOfWord();

        public AllDoc(string userId,string userName)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
            LoadAllDoc();
        }

        /// <summary>
        /// 加载所有文档信息，显示在DataGrid中
        /// </summary>
        public void LoadAllDoc() {
            //获取数据库查询结果集
            dbDataTable = db.SelectAllDoc(userId).Tables[0];
            //前端绑定数据的自定义结果集
            DataTable dt = new DataTable();
            dt.Columns.Add("docId", typeof(string));
            dt.Columns.Add("docName", typeof(string));
            dt.Columns.Add("docPath", typeof(string));
            dt.Columns.Add("docUploadTime", typeof(string));
            //数据库查询结果集赋值给自定义结果集
            foreach (DataRow row in dbDataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["docId"] = row["docId"];
                newRow["docName"] = row["docName"];
                newRow["docPath"] = row["docPath"];
                newRow["docUploadTime"] = row["docUploadTime"];
                dt.Rows.Add(newRow);
            }
            dataGrid.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// 首页的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToIndex_ButtonClick(object sender, RoutedEventArgs e)
        {
            TeamIndex teamIndex = new TeamIndex(userId, userName);
            teamIndex.Show();
            this.Close();
        }

        /// <summary>
        /// 以往版本的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            LoadAllDoc();
        }

        /// <summary>
        /// 刷新的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_ButtonClick(object sender, RoutedEventArgs e)
        {
            LoadAllDoc();
        }

        /// <summary>
        /// 文档下载的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                string docName = ((DataRowView)dataGrid.SelectedItem)["docName"].ToString();
                string docPath = ((DataRowView)dataGrid.SelectedItem)["docPath"].ToString();
                waysOfWord.WayOfDownloadDoc(docName, docPath);
            }
            else {
                MessageBox.Show("请选择需要下载的文档！");
            }
        }
    }
}
