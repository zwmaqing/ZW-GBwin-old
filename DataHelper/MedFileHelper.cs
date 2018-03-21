using Shell32;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataHelper
{
    //以后考虑统一至FilesSystemHelper,或者 C#基类库

    public class MediaFileHelper
    {

        /// <summary>
        /// Gets the file properties.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Dictionary{System.StringSystem.String}.</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        private static Dictionary<string, string> GetFileProperties(string filePath)
        {
            //要获取属性的文件路径

            //初始化Shell接口
            Shell32.Shell shell = new Shell32.ShellClass();
            //获取文件所在父目录对象
            Folder folder = shell.NameSpace(filePath.Substring(0, filePath.LastIndexOf('\\')));
            //获取文件对应的FolderItem对象
            FolderItem item = folder.ParseName(filePath.Substring(filePath.LastIndexOf('\\') + 1));
            //字典存放属性名和属性值的键值关系对
            Dictionary<string, string> Properties = new Dictionary<string, string>();
            int i = 0;
            while (true)
            {
                //获取属性名称
                string key = folder.GetDetailsOf(null, i);
                if (string.IsNullOrEmpty(key))
                {
                    //当无属性可取时，推出循环
                    break;
                }
                //获取属性值
                string value = folder.GetDetailsOf(item, i);
                //保存属性
                Properties.Add(key, value);
                i++;
            }
            return Properties;
        }

        /// <summary>
        /// 获取媒体文件播放时长 (主要使用)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetMediaTimeLen(string path)
        {
            try
            {
                Shell32.Shell shell = new Shell32.ShellClass();
                //文件路径
                Shell32.Folder folder = shell.NameSpace(path.Substring(0, path.LastIndexOf("\\")));
                //文件名称
                Shell32.FolderItem folderItem = folder.ParseName(path.Substring(path.LastIndexOf("\\") + 1));
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return folder.GetDetailsOf(folderItem, 27);
                }
                else
                {
                    return folder.GetDetailsOf(folderItem, 21);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the media time len for win32.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.String.</returns>
        /// <remarks>SAP_SchoolSystem</remarks>
        public static string GetMediaTimeLenForWin32(string filePath)
        {
            Dictionary<string, string> fileProperties = new Dictionary<string, string>();
            fileProperties = GetFileProperties(filePath);
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    return fileProperties["长度"]; ;
                }
                else
                {
                    return fileProperties["持续时间"]; //长度
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Gets the dir file list.
        /// .mp3/.wav/.wma
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.String[][].</returns>
        public static List<string> GetDirVoiceFileList(string path)
        {
            string[] strBuffTotal = Directory.GetFiles(path);
            List<string> voiceFileList = new List<string>();
            foreach (string filePathName in strBuffTotal)
            {
                //这里判断diSourceSubDir根据diSourceSubDir.Name来决定放在哪个集合中。

                var extension = Path.GetExtension(filePathName);
                if (extension != null)
                {
                    string filesExtension = extension.ToLower();
                    if (filesExtension == ".mp3" || filesExtension == ".wav" || filesExtension == ".wma")
                    {
                        voiceFileList.Add (Path.GetFileName(filePathName));
                    }
                }
            }
            return voiceFileList;
        }
    }
}
