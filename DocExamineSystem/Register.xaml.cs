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
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        /// <summary>
        /// 数据库连接实例
        /// </summary>
        DBHelper db = new DBHelper();

        public Register()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册的按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void register_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordText.Text) || String.IsNullOrEmpty(userNameText.Text))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else if(String.IsNullOrEmpty(passwordAgainText.Text)) {
                MessageBox.Show("请确认密码！");
            }else if (passwordText.Text.Equals(passwordAgainText.Text))
            {
                string userId = WaysOfString.ReturnNowTimeString();
                db.InsertRegisterInfo(userId, userNameText.Text, passwordText.Text);
                MessageBox.Show("登陆成功！您的账号是" + userId + "。请牢记！");
            }
            else {
                MessageBox.Show("两次输入密码不一致！");
            }
        }

        string ToHexString(byte[] bytes)
        {
            var hex = new StringBuilder();
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }


        /// <summary>
        /// 跳转登录的Label点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToIndex_LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
