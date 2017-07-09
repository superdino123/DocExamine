using Bll;
using Dal;
using Microsoft.Win32;
using Model;
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
    /// TeamIndex.xaml 的交互逻辑
    /// </summary>
    public partial class TeamIndex : Window
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string userId = string.Empty;

        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName = string.Empty;

        /// <summary>
        /// 文档路径
        /// </summary>
        public string docPath = string.Empty;

        /// <summary>
        /// 数据库连接实例
        /// </summary>
        public DBHelper db = new DBHelper();

        /// <summary>
        /// 文档选择窗口实例
        /// </summary>
        OpenFileDialog ofd = new OpenFileDialog();

        /// <summary>
        /// 操作Word方法的实例
        /// </summary>
        WaysOfWord waysOfWord = new WaysOfWord();

        public TeamIndex(string userId, string userName)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
            userNameLabel.Content = userName;
            LoadDocInfo();
        }

        /// <summary>
        /// 加载最新上传的文档信息
        /// 文档审批状态/审批意见/存储路径
        /// </summary>
        public void LoadDocInfo()
        {
            DataSet newDoc = db.SelectNewDoc(userId);
            if (newDoc.Tables[0].Rows.Count != 0)
            {
                //确定审批状态
                DataRow row = newDoc.Tables[0].Rows[0];
                switch ((int)row[0])
                {
                    case 0:
                        docStateLabel.Content = "待审核";
                        break;
                    case 1:
                        docStateLabel.Content = "待修改";
                        break;
                    case 2:
                        docStateLabel.Content = "审核通过";
                        break;
                    default:
                        docStateLabel.Content = "状态未知";
                        break;
                }
                //确定审批意见
                string viewMes = row[2].ToString();
                string[] viewMess = viewMes.Split('。');
                List<string> viewMesList = new List<string>();
                foreach (string mes in viewMess)
                {
                    viewMesList.Add(mes);
                }
                examineProblemListBox.ItemsSource = viewMesList;
                //确定存储路径
                docPath = row[3].ToString();
                documentViewer.Document = waysOfWord.WayOfConvertWordToXPS(docPath).GetFixedDocumentSequence();
                documentViewer.FitToWidth();
            }
            else{
                MessageBox.Show("您还没有上传过文档！");
            }
        }

        /// <summary>
        /// 在word中打开文档的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDocInWord_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (docPath == "")
            {
                MessageBox.Show("没有可以打开的文档！");
            }
            else
            {
                System.Diagnostics.Process.Start(docPath);
            }
        }

        /// <summary>
        /// 上传文档的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            string uploadDocName = string.Empty;
            if (ofd.ShowDialog() == true)
            {
                uploadDocName = ofd.FileName;
            }
            if (uploadDocName != "")
            {
                string docPath = uploadDocName;
                string ServerPath = string.Empty;
                string docName = string.Empty;
                //如果执行上传操作成功，将文件信息添加到数据库中
                if (waysOfWord.WayOfUploadDoc(userId, docPath, ref docName, ref ServerPath) == true)
                {
                    DocInfo docInfo = new DocInfo();
                    docInfo.DocId = WaysOfString.ReturnNowTimeString();
                    docInfo.DocName = docName;//更改文档名称为当前时间+队伍账号
                    docInfo.DocPath = ServerPath;
                    docInfo.UserId = userId;
                    docInfo.DocIsLast = 1;//上传后为最新版本
                    docInfo.DocUploadTime = DateTime.Now;
                    docInfo.DocState = 0;
                    db.SaveUploadDocInfo(docInfo);//插入数据库文件名和时间
                    MessageBox.Show("上传成功！");
                }
            }
            //上传文档后重新加载页面
            LoadDocInfo();
        }

        /// <summary>
        /// 以往版本的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            AllDoc allDoc = new AllDoc(userId, userName);
            allDoc.Show();
            this.Close();
        }

        /// <summary>
        /// 首页的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToIndex_ButtonClick(object sender, RoutedEventArgs e)
        {
            LoadDocInfo();
        }
    }
}
