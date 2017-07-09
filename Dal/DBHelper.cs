using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dal
{
    public class DBHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        static string source = @"server = (local); integrated security = SSPI; database = DocSystem;";

        #region 自创队伍权限方法

        /// <summary>
        /// 注册添加角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        public void InsertRegisterInfo(string userId,string userName,string userPassword) {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string insert = "insert into t_user values('" + userId + "','" + userName + "','" + userPassword + "','001')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 验证账户密码并返回验证结果
        /// </summary>
        /// <param name="userIdText">输入的账户</param>
        /// <param name="passwordText">输入的密码</param>
        /// <param name="userId">保存通过验证的账户</param>
        /// <param name="userName">保存通过验证的用户名称</param>
        /// <param name="limitType">保存通过验证的用户权限等级</param>
        /// <returns></returns>
        public bool IsLoginSucceed(string userIdText, string passwordText, ref string userId, ref string userName, ref int limitType)
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select = "select userId,userName,limitType from t_user,t_limit where t_user.limitId = t_limit.limitId and userId = '" + userIdText + "' and userPassword = '" + passwordText + "'";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    conn.Close();
                    return false;
                }
                else
                {
                    userId = reader[0].ToString();
                    userName = reader[1].ToString();
                    limitType = Convert.ToInt32(reader[2]);
                    conn.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 查找目前登录队伍最新上传的文档
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataSet SelectNewDoc(string userId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select = "select docState,docUploadTime,viewMes,docPath from t_docinfo left join t_opinion on t_docinfo.docId = t_opinion.docId where t_docinfo.userId = '" + userId + "' order by t_docinfo.docUploadTime desc";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //创建DataAdapter数据适配器实例  
                DataSet ds = new DataSet();//创建DataSet实例
                da.Fill(ds, "Newdoc");//使用DataAdapter的Fill方法(填充)，调用SELECT命令    
                conn.Close();//关闭数据库 
                return ds;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 保存上传的文档信息到数据库
        /// 不包含上传文档的功能
        /// </summary>
        /// <param name="docInfo"></param>
        /// <returns></returns>
        public int SaveUploadDocInfo(DocInfo docInfo)
        {
            //将数据结构中的参数与存储过程中的参数一一对应
            string procName = "proc_UploadAndDownload";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@docId",SqlDbType.VarChar,50),
                new SqlParameter("@docName",SqlDbType.VarChar,255),
                new SqlParameter("@docPath",SqlDbType.VarChar,255),
                new SqlParameter("@userId",SqlDbType.VarChar,50),
                new SqlParameter("@docIsLast",SqlDbType.Int),
                new SqlParameter("@docUploadTime",SqlDbType.DateTime),
                new SqlParameter("@docState",SqlDbType.Int),
            };
            sp[0].Value = docInfo.DocId;
            sp[1].Value = docInfo.DocName;
            sp[2].Value = docInfo.DocPath;
            sp[3].Value = docInfo.UserId;
            sp[4].Value = docInfo.DocIsLast;
            sp[5].Value = docInfo.DocUploadTime;
            sp[6].Value = docInfo.DocState;

            //连接数据库存储数据
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(source);
                    conn.Open();

                    //保存附件之前，将所有该用户的文档的docIsLast设置为0
                    string cmdStr = "update t_docinfo set docIsLast = 0 where userId = '" + docInfo.UserId + "'";
                    SqlCommand cmdUpdate = new SqlCommand(cmdStr, conn);
                    cmdUpdate.ExecuteNonQuery();

                    //保存该文档信息到数据库
                    SqlCommand cmd = new SqlCommand(procName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sp != null)
                    {
                        if (sp.Length > 0)
                        {
                            cmd.Parameters.AddRange(sp);
                        }
                    }
                    scope.Complete();
                    return cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 查询以往文档
        /// </summary>
        /// <param name="name"></param>
        /// <returns>返回该账户的所有文档信息</returns>
        public DataSet SelectAllDoc(string userId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select = "select docId,docName,docPath,docUploadTime from t_docinfo where t_docinfo.userId = " + userId + "order by docUploadTime desc";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //创建DataAdapter数据适配器实例    
                DataSet ds = new DataSet();//创建DataSet实例    
                da.Fill(ds, "Alldoc");//使用DataAdapter的Fill方法(填充)，调用SELECT命令    
                conn.Close();//关闭数据库   
                return ds;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        #endregion

        #region 文档审批人员查询方法

        /// <summary>
        /// 查询所有自创队伍最新版的待审查文档
        /// </summary>
        /// <returns></returns>
        public DataSet SelectAllNewDoc()
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select = "select docId,docName,userName,docState,docUploadTime,docPath,t_user.userId from t_user left join v_docnewinfo on t_user.userId = v_docnewinfo.userId where t_user.userId in (select t_user.userId from t_user join t_limit on t_user.limitId = t_limit.limitId where limitType = 1)";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //创建DataAdapter数据适配器实例    
                DataSet ds = new DataSet();//创建DataSet实例    
                da.Fill(ds, "Allnewdoc");//使用DataAdapter的Fill方法(填充)，调用SELECT命令    
                conn.Close();//关闭数据库   
                return ds;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 提交审批意见
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="docId"></param>
        /// <param name="userId"></param>
        /// <param name="viewMes"></param>
        public void SubmitViewMes(string viewId, string docId, string userId, string viewMes)
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select = "insert into t_opinion(viewId,docId,userId,viewMes) values('" + viewId + "','" + docId + "','" + userId + "','" + viewMes + "')";
                SqlCommand cmd = new SqlCommand(select, conn);
                int rowsReturned = cmd.ExecuteNonQuery();
                string select1 = "update t_docinfo set docState = 1 where docId = '" + docId + "'";
                SqlCommand cmd1 = new SqlCommand(select1, conn);
                int rowsReturned1 = cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改文档状态为审核通过
        /// </summary>
        /// <param name="docId"></param>
        public void UpdateRegularDocState(string docId)
        {
            try
            {
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                string select1 = "update t_docinfo set docState = 2 where docId = '" + docId + "'";
                SqlCommand cmd1 = new SqlCommand(select1, conn);
                int rowsReturned1 = cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }

        #endregion


    }
}
