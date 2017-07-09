using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DocInfo
    {
        private string _docId;
        /// <summary>
        /// 文档编号
        /// </summary>
        public string DocId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        private string _docName;
        /// <summary>
        /// 文档名称
        /// </summary>
        public string DocName
        {
            get { return _docName; }
            set { _docName = value; }
        }

        private string _docPath;
        /// <summary>
        /// 文档路径
        /// </summary>
        public string DocPath
        {
            get { return _docPath; }
            set { _docPath = value; }
        }

        private string _userId;
        /// <summary>
        /// 所属账户
        /// </summary>
        public string UserId {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _docIsLast;
        /// <summary>
        /// 是否最新上传文档
        /// </summary>
        public int DocIsLast {
            get { return _docIsLast; }
            set { _docIsLast = value; }
        }

        private DateTime _docUploadTime;
        /// <summary>
        /// 文档上传时间
        /// </summary>
        public DateTime DocUploadTime
        {
            get { return _docUploadTime; }
            set { _docUploadTime = value; }
        }

        private int _docState;
        /// <summary>
        /// 文档审批状态
        /// </summary>
        public int DocState
        {
            get { return _docState; }
            set { _docState = value; }
        }      
    }
}
