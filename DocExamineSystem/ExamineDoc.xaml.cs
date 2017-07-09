using Bll;
using Dal;
using System;
using System.Collections.Generic;
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
    /// ExamineDoc.xaml 的交互逻辑
    /// </summary>
    public partial class ExamineDoc : Window
    {
        /// <summary>
        /// 文档所属账号
        /// </summary>
        public string userId = string.Empty;
        
        /// <summary>
        /// 队长名称
        /// </summary>
        public string userName = string.Empty;

        /// <summary>
        /// 文档编号
        /// </summary>
        public string docId = string.Empty;

        /// <summary>
        /// 文档路径
        /// </summary>
        public string docPath = string.Empty;

        /// <summary>
        /// 数据库连接实例
        /// </summary>
        DBHelper db = new DBHelper();

        /// <summary>
        /// 操作Word方法实例
        /// </summary>
        WaysOfWord waysOfWord = new WaysOfWord();

        public ExamineDoc(string userId, string userName, string docId, string docPath)
        {
            InitializeComponent();
            this.userId = userId;
            this.userName = userName;
            this.docId = docId;
            this.docPath = docPath;
            documentViewer.Document = waysOfWord.WayOfConvertWordToXPS(docPath).GetFixedDocumentSequence();
            documentViewer.FitToWidth();
        }

        /// <summary>
        /// 提交审批的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitProblem_ButtonClick(object sender, RoutedEventArgs e)
        {
            string viewId = WaysOfString.ReturnNowTimeString();
            //添加意见到数据库，并更改该文档审批状态
            db.SubmitViewMes(viewId, docId, userId, problemTextBox.Text);
            MessageBox.Show("审批意见提交成功");
        }

        /// <summary>
        /// 审批通过的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegularDoc_ButtonClick(object sender, RoutedEventArgs e)
        {
            db.UpdateRegularDocState(docId);
            MessageBox.Show("文档审批合格");
        }

        /// <summary>
        /// 首页的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToIndex_ButtonClick(object sender, RoutedEventArgs e)
        {
            DocManagerIndex docManagerIndex = new DocManagerIndex(userId, userName);
            docManagerIndex.Show();
            this.Close();
        }
    }
}
