using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Xps.Packaging;

namespace Bll
{
    public class WaysOfWord
    {
        /// <summary>
        /// Word转换为XPS
        /// </summary>
        /// <param name="wordDocName"></param>
        /// <returns></returns>
        public XpsDocument WayOfConvertWordToXPS(string docName)
        {
            FileInfo fi = new FileInfo(docName);
            XpsDocument result = null;
            string xpsDocName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache), fi.Name);
            xpsDocName = xpsDocName.Replace(".docx", ".xps").Replace(".doc", ".xps");
            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                if (!File.Exists(xpsDocName))
                {
                    wordApplication.Documents.Add(docName);
                    Document doc = wordApplication.ActiveDocument;
                    doc.ExportAsFixedFormat(xpsDocName, WdExportFormat.wdExportFormatXPS, false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument, 0, 0, WdExportItem.wdExportDocumentContent, true, true, WdExportCreateBookmarks.wdExportCreateHeadingBookmarks, true, true, false, Type.Missing);
                    result = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                }
                if (File.Exists(xpsDocName))
                {
                    result = new XpsDocument(xpsDocName, FileAccess.Read);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                wordApplication.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
            wordApplication.Quit(WdSaveOptions.wdDoNotSaveChanges);
            return result;
        }

        /// <summary>
        /// 上传文档到服务器
        /// 文档存储地址为默认地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="docPath"></param>
        /// <param name="docName"></param>
        /// <param name="serverDocPath"></param>
        /// <returns>是否上传成功</returns>
        public bool WayOfUploadDoc(string userId, string docPath,ref string docName, ref string serverDocPath)
        {
            //int i = docPath.LastIndexOf("\\");
            //获取上传文件的名称
            //string fileName = docPath.Substring(i + 1);

            //放弃使用原有文件名称，使用命名格式（当前时间字符串形式+队伍账号）
            docName = WaysOfString.ReturnNowTimeString() + userId + ".docx";
            //该应用程序.exe的文件目录
            string allPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            int proPathLength = allPath.Substring(allPath.LastIndexOf("bin") - 1).Length;
            //该应用程序.exe的文件目录的bin之前的目录
            string proPath = allPath.Substring(0, allPath.Length - proPathLength);
            //默认文档上传的目录
            string path = proPath + "\\" + "UpFile" + "\\" + docName;
            serverDocPath = path;
            WebClient web = new WebClient();
            //获取应用程序的系统凭证
            web.Credentials = CredentialCache.DefaultCredentials;
            //初始化上传文件，打开读取
            FileStream fs = new FileStream(docPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);//将文件转化为二进制文件
            byte[] btArray = br.ReadBytes((int)fs.Length);
            Stream upLoadStream = web.OpenWrite(serverDocPath, "PUT");
            if (upLoadStream.CanWrite)
            {
                upLoadStream.Write(btArray, 0, btArray.Length);
                upLoadStream.Close();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 下载文档到本地
        /// </summary>
        /// <param name="docName">文档名称</param>
        /// <param name="docPath">文档服务端存储路径</param>
        public void WayOfDownloadDoc(string docName,string docPath) {
            WebClient webClient = new WebClient();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = docName;
            if (dlg.ShowDialog() == true)
            {
                //获取要保存文件名的完整路径
                string filename = dlg.FileName;
                try
                {
                    webClient.DownloadFile(docPath, filename);
                    MessageBox.Show("文档下载成功！！！");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 下载所有文档到本地
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="docPath"></param>
        public void WayOfDownloadAllDoc(string[] docName, string[] docPath)
        {
            WebClient webClient = new WebClient();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "选择路径后点击保存.docx";
            if (dlg.ShowDialog() == true)
            {
                //获取要保存文件名的完整路径
                string filename = dlg.FileName;
                
                //截取存储路径
                int length = filename.LastIndexOf("\\");
                filename = filename.Substring(0, length + 1);

                try
                {
                    for (int i = 0; i < docName.Length; i++) {
                        if (docName[i] == "") continue;
                        webClient.DownloadFile(docPath[i], filename + docName[i]);
                    }
                    MessageBox.Show("文档下载成功！！！");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
