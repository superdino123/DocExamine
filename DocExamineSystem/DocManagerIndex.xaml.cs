using Bll;
using Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// DocManagerIndex.xaml 的交互逻辑
    /// </summary>
    public partial class DocManagerIndex : Window
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string userId = string.Empty;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName = string.Empty;

        /// <summary>
        /// 文档编号
        /// </summary>
        public string docId = string.Empty;

        /// <summary>
        /// 文档名称
        /// </summary>
        public string docName = string.Empty;

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
        /// 操作WORD方法实例
        /// </summary>
        WaysOfWord waysOfWord = new WaysOfWord();

        public DocManagerIndex(string userId, string userName)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
            LoadDataGrid();
        }

        /// <summary>
        /// 加载所有队伍的文档信息
        /// </summary>
        public void LoadDataGrid() {
            dbDataTable = db.SelectAllNewDoc().Tables[0];
            DataTable dt = new DataTable();
            dt.Columns.Add("docId", typeof(string));
            dt.Columns.Add("docName", typeof(string));
            dt.Columns.Add("userName", typeof(string));
            dt.Columns.Add("docState", typeof(string));
            dt.Columns.Add("docUploadTime", typeof(string));
            dt.Columns.Add("docPath", typeof(string));
            dt.Columns.Add("userId", typeof(string));
            foreach (DataRow row in dbDataTable.Rows)
            {
                DataRow newRow = dt.NewRow();
                newRow["docId"] = row["docId"];
                newRow["docName"] = row["docName"];
                newRow["userName"] = row["userName"];
                if (row["docState"].ToString().Equals("0")) {
                    newRow["docState"] = "待审核";
                }
                if (row["docState"].ToString().Equals("1"))
                {
                    newRow["docState"] = "待修改";
                }
                if (row["docState"].ToString().Equals("2"))
                {
                    newRow["docState"] = "审核通过";
                }
                newRow["docUploadTime"] = row["docUploadTime"];
                newRow["docPath"] = row["docPath"];
                newRow["userId"] = row["userId"];
                dt.Rows.Add(newRow);
            }
            dataGrid.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// 下载文档的按钮点击事件
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
            else
            {
                MessageBox.Show("请选择需要下载的文档！");
            }
        }

        /// <summary>
        /// 审批文档的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExamineDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                //文档所属队伍账号
                string userId = ((DataRowView)dataGrid.SelectedItem)["userId"].ToString();
                string docId = ((DataRowView)dataGrid.SelectedItem)["docId"].ToString();
                string docName = ((DataRowView)dataGrid.SelectedItem)["docName"].ToString();
                string docPath = ((DataRowView)dataGrid.SelectedItem)["docPath"].ToString();
                if (docName != "")
                {
                    ExamineDoc examineDoc = new ExamineDoc(userId, userName, docId, docPath);
                    examineDoc.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("该用户没有上传文档！");
                }
            }
            else
            {
                MessageBox.Show("请选择需要审批的文档！");
            }
        }

        /// <summary>
        /// 下载所有文档的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadAllDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (dbDataTable != null)
            {
                string[] docNameStr = new string[dbDataTable.Rows.Count];
                string[] docPathStr = new string[dbDataTable.Rows.Count];
                int i = 0;
                foreach (DataRow row in dbDataTable.Rows)
                {
                    docNameStr[i] = row["docName"].ToString();
                    docPathStr[i] = row["docPath"].ToString();
                    i++;
                }
                waysOfWord.WayOfDownloadAllDoc(docNameStr, docPathStr);
            }
            else {
                MessageBox.Show("没有人员上传文档！");
            }
        }

        /// <summary>
        /// 刷新的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_ButtonClick(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }
    }
}
