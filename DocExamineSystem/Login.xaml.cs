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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
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
        /// 权限等级
        /// </summary>
        public int limitType = 0;

        /// <summary>
        /// 数据库连接实例
        /// </summary>
        DBHelper db = new DBHelper();

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登陆按钮的点击事件
        /// 验证密码并跳转界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordText.Text) || String.IsNullOrEmpty(userIdText.Text))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else if (db.IsLoginSucceed(userIdText.Text, passwordText.Text, ref userId, ref userName, ref limitType))
            {
                if (limitType == 1)
                {
                    MessageBox.Show("团队文档审批系统登陆成功");
                    TeamIndex teamIndex = new TeamIndex(userId, userName);
                    teamIndex.Show();
                }
                if (limitType == 2)
                {
                    MessageBox.Show("审批人员管理系统登陆成功");
                    DocManagerIndex docManagerIndex = new DocManagerIndex(userId, userName);
                    docManagerIndex.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        /// <summary>
        /// 跳转注册的Label点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToRegister_LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
